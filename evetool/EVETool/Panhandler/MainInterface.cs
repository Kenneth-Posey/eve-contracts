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
            
            label7.Text = "+0%";
            label8.Text = "+5%";
            label9.Text = "+10%";

            this.MaterialBoxList = new List<ComboBox>() {
                  oreCombobox
                , compOreCombobox
                , iceCombobox
                , compIceCombobox
                , mineralsCombobox
                , iceProductCombobox
            };

            foreach (var box in this.MaterialBoxList)
            {
                box.Items.Insert(0, "Select One");
                box.SelectedIndex = 0;
                box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                box.SelectedIndexChanged += combox_SelectedIndexChanged;
            }
            
            Add.Text = "Add";
            Remove.Text = "Remove";
            Calculate.Text = "Calculate";

            this.RawOre = CollectionsProvider.OreList.OreNames.ToList();
            this.RawIce = CollectionsProvider.IceList.IceNames.ToList();
            this.IceProducts = CollectionsProvider.IceProductList.IceProductNames.ToList();
            this.Minerals = CollectionsProvider.MineralList.MineralNames.ToList();

            oreCombobox.Items.AddRange(this.RawOre.ToArray<object>());
            compOreCombobox.Items.AddRange(this.RawOre.ToArray<object>());
            iceCombobox.Items.AddRange(this.RawIce.ToArray<object>());
            compIceCombobox.Items.AddRange(this.RawIce.ToArray<object>());
            mineralsCombobox.Items.AddRange(this.Minerals.ToArray<object>());
            iceProductCombobox.Items.AddRange(this.IceProducts.ToArray<object>());

            inventory.SelectionMode = SelectionMode.MultiExtended;
        }

        protected void combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int baseAmount = 0;
            int base5Amount = 0;
            int base10Amount = 0;

            bool validBase = false;
            bool validBase5 = false;
            bool validBase10 = false;

            var baseValue = textBox1.Text.Trim();
            var base5Value = textBox2.Text.Trim();
            var base10Value = textBox3.Text.Trim();

            validBase = Int32.TryParse(baseValue, out baseAmount);
            validBase5 = Int32.TryParse(base5Value, out base5Amount);
            validBase10 = Int32.TryParse(base10Value, out base10Amount);

            var selectedItems = new List<Tuple<string, bool>>();

            foreach (var box in this.MaterialBoxList)
            {
                if (box.SelectedIndex != 0)
                {
                    // Non-compressed ore/ice
                    if (box.Name == "comboBox1" || box.Name == "comboBox3")
                        selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), false));
                    // Compressed ore/ice
                    else if (box.Name == "comboBox2" || box.Name == "comboBox4")
                        selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), true));
                    else
                        selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), false));
                }
            }

            var ores = CollectionsProvider.AllOreList.OreList.ToList();

            foreach (var item in selectedItems)
            {
                var itemName = item.Item1.Trim();
                var itemCompressed = item.Item2;

                if (this.RawOre.Contains(itemName))
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
                else if (this.RawIce.Contains(itemName))
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
                else if (this.IceProducts.Contains(itemName) || this.Minerals.Contains(itemName))
                {
                    AddToListbox(baseAmount, itemName);
                }
            }

            foreach (var box in this.MaterialBoxList)
            {
                box.SelectedIndex = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void AddToListbox(int baseAmount, string itemName)
        {

            string itemString = String.Format("{0}\t{1}", itemName, baseAmount);
            inventory.Items.Add(itemString);
        }

        private void PopulateListbox(  int baseAmount
                                     , int base5Amount
                                     , int base10Amount
                                     , bool validBase
                                     , bool validBase5
                                     , bool validBase10
                                     , List<EveData.Ore.Types.IRawOre> ores
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
            List<string> selectedItems = inventory.SelectedItems.OfType<string>().ToList();
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
            var tSplitLines = Microsoft.FSharp.Collections.ListModule.OfArray(pSplitLines.ToArray());
            return Market.Functions.CalculateEstimate(tSplitLines);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> tItems = inventory.Items.OfType<string>().ToList();
            var estimate = CalculateEstimate(tItems);
            nocxiumValue.Text = estimate.ToString("N2", CultureInfo.InvariantCulture);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
