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
                box.SelectedIndexChanged += combox_SelectedIndexChanged;
            }

            oreCombobox.SelectedIndexChanged += combox_SelectedIndexChanged;
            compOreCombobox.SelectedIndexChanged += combox_SelectedIndexChanged;

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

            oreBase0DefaultCheck.Checked = true;
        }

        protected void itemCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemQty != null) itemQty.Focus();
            if (this.defaultOreBox != null) this.defaultOreBox.Focus();
        }

        protected void iceCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iceQty != null) iceQty.Focus();
            if (this.defaultOreBox != null) this.defaultOreBox.Focus();
        }

        protected void combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oreBase0Qty != null || this.defaultOreBox == null) oreBase0Qty.Focus();
            if (this.defaultOreBox != null) this.defaultOreBox.Focus();
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            var baseAmount = 0;
            var base5Amount = 0;
            var base10Amount = 0;

            var validBase = false;
            var validBase5 = false;
            var validBase10 = false;

            var baseValue = oreBase0Qty.Text.Trim();
            var base5Value = oreBase5Qty.Text.Trim();
            var base10Value = oreBase10Qty.Text.Trim();

            validBase = Int32.TryParse(baseValue, out baseAmount);
            validBase5 = Int32.TryParse(base5Value, out base5Amount);
            validBase10 = Int32.TryParse(base10Value, out base10Amount);

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
                        PopulateListbox(baseAmount
                            , base5Amount
                            , base10Amount
                            , validBase
                            , validBase5
                            , validBase10
                            , ores
                            , itemName);
                    }
                    // Compressed ore
                    else
                    {
                        itemName = "Compressed " + itemName;
                        PopulateListbox(baseAmount
                            , base5Amount
                            , base10Amount
                            , validBase
                            , validBase5
                            , validBase10
                            , ores
                            , itemName);
                    }
                }
                else if (RawIce.Contains(itemName))
                {
                    if (itemCompressed == false)
                    {
                        AddToListbox(baseAmount, itemName);
                    }
                    else
                    {
                        itemName = "Compressed " + itemName;
                        AddToListbox(baseAmount, itemName);
                    }
                }
                else if (IceProducts.Contains(itemName) || Minerals.Contains(itemName))
                {
                    AddToListbox(baseAmount, itemName);
                }
            }

            foreach (var box in MaterialBoxList)
            {
                box.SelectedIndex = 0;
                oreBase0Qty.Text = "";
                oreBase5Qty.Text = "";
                oreBase10Qty.Text = "";
            }
        }

        private void AddToListbox(int baseAmount, string itemName)
        {
            var itemString = String.Format("{0}\t{1}", itemName, baseAmount);
            inventory.Items.Add(itemString);
        }

        private void PopulateListbox(  int baseAmount
                                     , int base5Amount
                                     , int base10Amount
                                     , bool validBase
                                     , bool validBase5
                                     , bool validBase10
                                     , List<Ore.Types.IRawOre> ores
                                     , string itemName)
        {
            if (validBase)
            {
                var oreName = ores.Find(x => x.GetName() == itemName).GetName();
                AddToListbox(baseAmount, oreName);
            }

            if (validBase5)
            {
                var oreName = ores.Find(x => x.GetName() == itemName).GetName5();
                AddToListbox(base5Amount, oreName);
            }

            if (validBase10)
            {
                var oreName = ores.Find(x => x.GetName() == itemName).GetName10();
                AddToListbox(base10Amount, oreName);
            }
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

        private void oreBase0DefaultCheck_Checked(object sender, EventArgs e)
        {
            if (!oreBase0DefaultCheck.Checked) return;

            oreBase5DefaultCheck.CheckState = CheckState.Unchecked;
            oreBase10DefaultCheck.CheckState = CheckState.Unchecked;
            this.defaultOreBox = oreBase0Qty;
        }

        private void oreBase5DefaultCheck_Checked(object sender, EventArgs e)
        {
            if (oreBase5DefaultCheck.Checked)
            {
                oreBase0DefaultCheck.CheckState = CheckState.Unchecked;
                oreBase10DefaultCheck.CheckState = CheckState.Unchecked;

                this.defaultOreBox = oreBase5Qty;
            }
            else
            {
                oreBase0DefaultCheck.CheckState = CheckState.Checked;
                oreBase10DefaultCheck.CheckState = CheckState.Unchecked;
                this.defaultOreBox = oreBase0Qty;
            }
        }

        private void oreBase10DefaultCheck_Checked(object sender, EventArgs e)
        {
            if (oreBase10DefaultCheck.Checked)
            {
                oreBase0DefaultCheck.CheckState = CheckState.Unchecked;
                oreBase5DefaultCheck.CheckState = CheckState.Unchecked;

                this.defaultOreBox = oreBase10Qty;
            }
            else
            {
                oreBase0DefaultCheck.CheckState = CheckState.Checked;
                oreBase5DefaultCheck.CheckState = CheckState.Unchecked;
                this.defaultOreBox = oreBase0Qty;
            }
        }

        public TextBox defaultOreBox { get; set; }
    }
}
