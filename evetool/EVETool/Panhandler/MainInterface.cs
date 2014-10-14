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
using EveData;
using EveOnlineInterop;
using Market;
using Microsoft.FSharp.Collections;

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
        }

        protected void combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1 != null) textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baseAmount = 0;
            var base5Amount = 0;
            var base10Amount = 0;

            var validBase = false;
            var validBase5 = false;
            var validBase10 = false;

            var baseValue = textBox1.Text.Trim();
            var base5Value = textBox2.Text.Trim();
            var base10Value = textBox3.Text.Trim();

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
                        PopulateListbox(baseAmount, base5Amount, base10Amount, validBase, validBase5, validBase10, ores, itemName);
                    }
                    // Compressed ore
                    else
                    {
                        itemName = "Compressed " + itemName;
                        PopulateListbox(baseAmount, base5Amount, base10Amount, validBase, validBase5, validBase10, ores, itemName);
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
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedItems = inventory.SelectedItems.OfType<string>().ToList();
            var copiedItems = inventory.Items.OfType<string>().ToList();

            if (selectedItems.Count > 0 && copiedItems.Count > 0)
            {
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
        }

        private double CalculateEstimate(List<string> pSplitLines)
        {
            var tSplitLines = ListModule.OfArray(pSplitLines.ToArray());
            return Functions.CalculateEstimate(tSplitLines);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tItems = inventory.Items.OfType<string>().ToList();
            var estimate = CalculateEstimate(tItems);
            nocxiumValue.Text = estimate.ToString("N2", CultureInfo.InvariantCulture);
        }

        private int LoadIdByName(string name)
        {
            var allItems = EveData.Collections.RawIceIDPairs.ToList();
            allItems.AddRange(EveData.Collections.MineralIDPairs.ToList());
            allItems.AddRange(EveData.Collections.RawIceIDPairs.ToList());
            allItems.AddRange(EveData.Collections.IceProductIDPairs.ToList());

            return allItems.Find(x => x.Item1 == name).Item2;
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
