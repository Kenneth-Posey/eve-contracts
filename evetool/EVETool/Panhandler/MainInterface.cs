using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.FSharp.Collections;
using Panhandler.Objects;
using EveData;
using EveOnlineInterop;

namespace Panhandler
{
    public partial class MainInterface : Form
    {
        List<ComboBox> MaterialBoxList { get; set; }
        List<string> RawOre { get; set; }
        List<string> RawIce { get; set; }
        List<string> Minerals { get; set; }
        List<string> IceProducts { get; set; }

        public MainInterface()
        {
            InitializeComponent();

            loadingLabel.Text = "";

            MaterialBoxList = new List<ComboBox>() {
                  oreCombobox
                , compOreCombobox
                , iceCombobox
                , compIceCombobox
                , mineralsCombobox
                , iceProductCombobox
            };

            foreach (var box in MaterialBoxList)
            {
                box.Items.Insert(0, "Select One");
                box.SelectedIndex = 0;
                box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                // box.SelectedIndexChanged += combox_SelectedIndexChanged;
            }

            oreCombobox.SelectedIndexChanged += oreCombobox_SelectedIndexChanged;
            compOreCombobox.SelectedIndexChanged += oreCombobox_SelectedIndexChanged;

            iceCombobox.SelectedIndexChanged += iceCombobox_SelectedIndexChanged;
            compIceCombobox.SelectedIndexChanged += iceCombobox_SelectedIndexChanged;

            mineralsCombobox.SelectedIndexChanged += itemCombobox_SelectedIndexChanged;
            iceProductCombobox.SelectedIndexChanged += itemCombobox_SelectedIndexChanged;

            Add.Text = "Add";
            Remove.Text = "Remove";
            Calculate.Text = "Calculate";

            RawOre = CollectionsProvider.OreList.OreNames.ToList();
            RawIce = CollectionsProvider.IceList.IceNames.ToList();
            IceProducts = CollectionsProvider.IceProductList.IceProductNames.ToList();
            Minerals = CollectionsProvider.MineralList.MineralNames.ToList();

            oreCombobox.Items.AddRange(RawOre.ToArray<object>());
            compOreCombobox.Items.AddRange(RawOre.ToArray<object>());
            iceCombobox.Items.AddRange(RawIce.ToArray<object>());
            compIceCombobox.Items.AddRange(RawIce.ToArray<object>());
            mineralsCombobox.Items.AddRange(Minerals.ToArray<object>());
            iceProductCombobox.Items.AddRange(IceProducts.ToArray<object>());

            inventory.SelectionMode = SelectionMode.MultiExtended;

            calculatorTabPage.Text = "Calculator";
            memberTabPage.Text = "Members";

            memberListbox.Text = "";
            memberListbox.SelectedIndexChanged += memberListbox_SelectedIndexChanged;

        }

        protected void itemCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qty.Focus();
        }

        protected void iceCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qty.Focus();
        }

        protected void oreCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            qty.Focus();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            var oreAmount = 0;
            var validOre = false;
            var oreValue = qty.Text.Trim();
            validOre = Int32.TryParse(oreValue, out oreAmount);
            var selectedItems = new List<Tuple<string, bool>>();

            foreach (var box in MaterialBoxList)
            {
                if (box.SelectedIndex != 0)
                {
                    // Non-compressed ore/ice
                    switch (box.Name)
                    {
                        case "comboBox3":
                        case "comboBox1":
                            selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), false));
                            break;
                        case "comboBox4":
                        case "comboBox2":
                            selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), true));
                            break;
                        default:
                            selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), false));
                            break;
                    }
                }
            }

            var ores = CollectionsProvider.AllOreList.OreList.ToList();

            foreach (var item in selectedItems)
            {
                var itemName = item.Item1.Trim();
                var itemCompressed = item.Item2;

                if (RawOre.Contains(itemName))
                {
                    // Uncompressed ore
                    if (itemCompressed == false)
                    {
                        AddOreToInventory(oreAmount
                            , validOre
                            , ores
                            , itemName);
                    }
                    // Compressed ore
                    else
                    {
                        itemName = "Compressed " + itemName;
                        AddOreToInventory(oreAmount
                            , validOre
                            , ores
                            , itemName);
                    }
                }
                else if (RawIce.Contains(itemName))
                {
                    if (itemCompressed == false)
                        AddItemToInventory(oreAmount, itemName);
                    else
                        AddItemToInventory(oreAmount, "Compressed " + itemName);
                }
                else if (IceProducts.Contains(itemName) || Minerals.Contains(itemName))
                {
                    AddItemToInventory(oreAmount, itemName);
                }
            }

            foreach (var box in MaterialBoxList)
            {
                box.SelectedIndex = 0;
            }

            qty.Text = "";
        }

        private void AddItemToInventory(int baseAmount, string itemName)
        {
            inventory.Items.Add(String.Format("{0}\t{1}", itemName, baseAmount));
        }

        private void AddOreToInventory( int baseAmount
                                      , bool validBase
                                      , List<Ore.Types.IRawOre> ores
                                      , string itemName)
        {
            if (validBase)
            {
                var oreName = ores.Find(x => x.GetName() == itemName).GetName();
                AddItemToInventory(baseAmount, oreName);
            }

            //if (validBase5)
            //{
            //    var oreName = ores.Find(x => x.GetName() == itemName).GetName5();
            //    AddItemToInventory(base5Amount, oreName);
            //}

            //if (validBase10)
            //{
            //    var oreName = ores.Find(x => x.GetName() == itemName).GetName10();
            //    AddItemToInventory(base10Amount, oreName);
            //}
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            var selectedItems = inventory.SelectedItems.OfType<string>().ToList();
            var copiedItems = inventory.Items.OfType<string>().ToList();

            if (selectedItems.Count <= 0 || copiedItems.Count <= 0) return;

            foreach (var listItem in selectedItems)
            {
                copiedItems.Remove(listItem);
            }

            inventory.Items.Clear();

            foreach (var item in copiedItems)
            {
                inventory.Items.Add(item);
            }
        }

        private static double CalculateEstimate(List<string> pSplitLines)
        {
            var tSplitLines = ListModule.OfArray(pSplitLines.ToArray());
            return Market.Functions.CalculateEstimate(tSplitLines);
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            var tItems = inventory.Items.OfType<string>().ToList();
            var estimate = CalculateEstimate(tItems);
            totalBox.Text = estimate.ToString("N2", CultureInfo.InvariantCulture);
        }

        private static int LoadIdByName(string name)
        {
            var allItems = EveData.Collections.RawIceIDPairs.ToList();
            allItems.AddRange(EveData.Collections.MineralIDPairs.ToList());
            allItems.AddRange(EveData.Collections.RawIceIDPairs.ToList());
            allItems.AddRange(EveData.Collections.IceProductIDPairs.ToList());

            return allItems.Find(x => x.Item1 == name).Item2;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            loadingLabel.Text = "Loading...";

            var allItems = Market.Functions.LoadAllItemsForParser().ToList();

            var priceLabels = new List<Tuple<Label, string>>()
            {
                  Tuple.Create(tritaniumValue, "Tritanium")
                , Tuple.Create(pyeriteValue, "Pyerite")
                , Tuple.Create(megacyteValue, "Megacyte")
                , Tuple.Create(mexallonValue, "Mexallon")
                , Tuple.Create(isogenValue, "Isogen")
                , Tuple.Create(morphiteValue, "Morphite")
                , Tuple.Create(nocxiumValue, "Nocxium")
                , Tuple.Create(zydrineValue, "Zydrine")

                , Tuple.Create(heavyWaterValue, "Heavy Water")
                , Tuple.Create(liquidOzoneValue, "Liquid Ozone")
                , Tuple.Create(strontiumClathratesValue, "Strontium Clathrates")
                , Tuple.Create(heliumIsotopeValue, "Helium Isotopes")
                , Tuple.Create(hydrogenIsotopeValue, "Hydrogen Isotopes")
                , Tuple.Create(oxygenIsotopeValue, "Oxygen Isotopes")
                , Tuple.Create(nitrogenIsotopeValue, "Nitrogen Isotopes")
            };

            foreach (var pair in priceLabels)
            {
                pair.Item1.Text = allItems.Find(x => x.id == LoadIdByName(pair.Item2)).price.ToString();
            }

            loadingLabel.Text = "";
        }

        private void addPerson_Click(object sender, EventArgs e)
        {
            if (playerNameBox.Text.Trim().Length <= 0 || playerMultiplierBox.Text.Trim().Length <= 0) return;

            var playerName = playerNameBox.Text.Trim();
            var playerMultiplier = Decimal.Parse(playerMultiplierBox.Text.Trim()).ToString();
            var playerGuid = Guid.NewGuid().ToString();

            var player = String.Format("{0,-35}|{1,-5}|{2}", new string[]{
                playerName, playerMultiplier, playerGuid
            });

            memberListbox.Items.Add(player);
            SortPlayers();
        }

        private void SortPlayers()
        {
            var userItems = memberListbox.Items.Cast<string>();
            var sortedUsers = userItems                                
                                .Select(x => new User(x).userName)
                                .ToList();

            sortedUsers.Sort();

            var sortedList = sortedUsers
                                .Select(x => new User(userItems
                                                        .Where(y => y.Contains(x))
                                                        .FirstOrDefault().Trim()))
                                .Select(x => x.ToString())
                                .ToArray();

            memberListbox.Items.Clear();
            memberListbox.Items.AddRange(sortedList);
        }

        private void removePerson_Click(object sender, EventArgs e)
        {
            var selectedIndex = memberListbox.SelectedIndex;
            memberListbox.Items.RemoveAt(selectedIndex);
            SortPlayers();
        }

        private void updatePerson_Click(object sender, EventArgs e)
        {
            if (playerNameBox.Text.Trim().Length <= 0 
                || playerMultiplierBox.Text.Trim().Length <= 0 
                || playerCodeBox.Text.Trim().Length <= 0) return;
            var selectedIndex = memberListbox.SelectedIndex;
            var playerName = playerNameBox.Text.Trim();
            var playerMultiplier = Decimal.Parse(playerMultiplierBox.Text.Trim()).ToString();
            var playerGuid = playerCodeBox.Text.Trim();

            var player = String.Format("{0,-35}|{1,-5}|{2}", new string[]{
                playerName, playerMultiplier, playerGuid
            });

            memberListbox.Items.RemoveAt(selectedIndex);
            memberListbox.Items.Add(player);
            SortPlayers();
        }

        protected void memberListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (memberListbox.SelectedItem == null || memberListbox.SelectedIndex < 0) return;

            var currentUser = new User(memberListbox.SelectedItem.ToString());

            playerNameBox.Text = currentUser.userName;
            playerMultiplierBox.Text = currentUser.multiplier.ToString();
            playerCodeBox.Text = currentUser.userId;
        }
        
        private void LoadUserStringIntoList(string userList)
        {
            memberListbox.Items.Clear();

            foreach (var user in userList.Split(new char[] { '\n' }))
            {
                var currentUser = new User(user);
                var player = String.Format("{0,-35}|{1,-5}|{2}", new string[]{
                    currentUser.userName, currentUser.multiplier.ToString(), currentUser.userId
                });
                memberListbox.Items.Add(player);
            }

            SortPlayers();
        }

        private void totalLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(totalBox.Text);
        }

        public TextBox defaultOreBox { get; set; }
    }
}
