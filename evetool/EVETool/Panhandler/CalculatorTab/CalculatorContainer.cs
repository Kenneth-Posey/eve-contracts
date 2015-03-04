using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EveOnlineInterop;
using Microsoft.FSharp.Collections;
using System.Globalization;

namespace Panhandler.CalculatorTab
{
    public partial class CalculatorContainer : UserControl
    {
        List<ComboBox> MaterialBoxList { get; set; }
        List<string> RawOre { get; set; }
        List<string> RawIce { get; set; }
        List<string> Minerals { get; set; }
        List<string> IceProducts { get; set; }

        public CalculatorContainer()
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
            
            oreCombobox.TabIndex = 0;
            compOreCombobox.TabIndex = 1;
            iceCombobox.TabIndex = 2;
            compIceCombobox.TabIndex = 3;
            mineralsCombobox.TabIndex = 4;
            iceProductCombobox.TabIndex = 5;
            oreRadioButtonPanel.TabIndex = 6;
            qty.TabIndex = 7;
            Add.TabIndex = 8;
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
            isCommonOre.Focus();
        }

        private async void addItem_Click(object sender, EventArgs e)
        {
            var amount = 0;
            var successfulParse = Int32.TryParse(qty.Text.Trim(), out amount);
            var selectedItems = new List<Tuple<string, bool>>();

            qty.Text = "";
            this.Parent.Focus();

            var success = await addItems(selectedItems, amount);
        }

        private async Task<bool> addItems(List<Tuple<string, bool>> selectedItems, int amount)
        {
            foreach (var box in MaterialBoxList)
            {
                if (box.SelectedIndex != 0)
                {
                    switch (box.Name)
                    {
                        case "comboBox3":
                        case "comboBox1":
                            // Non-compressed ore/ice
                            selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), false));
                            break;
                        case "comboBox4":
                        case "comboBox2":
                            // Compressed ore/ice
                            selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), true));
                            break;
                        default:
                            selectedItems.Add(Tuple.Create(box.SelectedItem.ToString(), false));
                            break;
                    }

                    box.SelectedIndex = 0;
                }
            }

            foreach (var item in selectedItems)
            {
                var itemName = item.Item1.Trim();
                var itemCompressed = item.Item2;

                bool isValidItem = RawOre.Contains(itemName) || RawIce.Contains(itemName) || IceProducts.Contains(itemName) || Minerals.Contains(itemName);

                if (!isValidItem) continue;

                if (RawOre.Contains(itemName))
                {
                    if (itemCompressed == false)
                        AddOreToInventory(amount, itemName);
                    else
                        AddOreToInventory(amount, "Compressed " + itemName);
                }
                else
                {
                    if (itemCompressed == false)
                        AddItemToInventory(amount, itemName);
                    else
                        AddItemToInventory(amount, "Compressed " + itemName);
                }
            }

            return true;
        }

        private void AddOreToInventory(int amount, string name)
        {
            var ores = CollectionsProvider.AllOreList.OreList.ToList();
            var oreName = "";
            if (isCommonOre.Checked)
                oreName = ores.Find(x => x.GetName() == name).GetName();
            else if (isUncommonOre.Checked)
                oreName = ores.Find(x => x.GetName() == name).GetName5();
            else
                oreName = ores.Find(x => x.GetName() == name).GetName10();

            AddItemToInventory(amount, oreName);
        }

        private void AddItemToInventory(int amount, string name)
        {
            inventory.Items.Add(string.Format("{0}\t{1}", name, amount));
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            var selectedItems = inventory.SelectedItems.OfType<string>().ToList();
            var copiedItems = inventory.Items.OfType<string>().ToList();

            if (selectedItems.Count <= 0 || copiedItems.Count <= 0) return;

            foreach (var listItem in selectedItems)
                copiedItems.Remove(listItem);

            inventory.Items.Clear();

            foreach (var item in copiedItems)
                inventory.Items.Add(item);
        }

        private static async Task<double> CalculateEstimate(List<string> pSplitLines)
        {
            var tSplitLines = ListModule.OfArray(pSplitLines.ToArray());
            return Market.Functions.CalculateEstimate(tSplitLines);
        }

        private async void calculate_Click(object sender, EventArgs e)
        {
            var tItems = inventory.Items.OfType<string>().ToList();
            var estimate = await CalculateEstimate(tItems);
            totalBox.Text = estimate.ToString("N2", CultureInfo.InvariantCulture);
        }

        private void totalLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(totalBox.Text);
        }

        public TextBox defaultOreBox { get; set; }
    }
}
