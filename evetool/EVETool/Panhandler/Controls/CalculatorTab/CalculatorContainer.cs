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
                box.SelectedIndexChanged += materialCombobox_SelectedIndexChanged;
            }

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
            qtyTextbox.TabIndex = 7;
            addItemButton.TabIndex = 8;

            this.totalLabel.Click += totalLabel_Click;
            this.calculateButton.Click += calculate_Click;
            this.removeItemButton.Click += removeItem_Click;
            this.addItemButton.Click += addItem_Click;
        }
        
        protected void materialCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oreCombobox.SelectedIndex >= 1 || compOreCombobox.SelectedIndex >= 1)
                isCommonOre.Focus();
            else
                qtyTextbox.Focus();
        }
        
        private async void addItem_Click(object sender, EventArgs e)
        {
            var amount = 0;
            var successfulParse = Int32.TryParse(qtyTextbox.Text.Trim(), out amount);
            qtyTextbox.Text = "";
            this.Parent.Focus();
            await addItems(amount);
        }

        private async Task addItems(int amount)
        {
            var selectedItems = new List<Tuple<string, bool>>();
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

                var isOre = RawOre.Contains(itemName);
                var isIce = RawIce.Contains(itemName);
                var isIceProduct = IceProducts.Contains(itemName);
                var isMineral = Minerals.Contains(itemName);

                bool isValidItem = isOre || isIce || isIceProduct || isMineral;

                // skips unknown items in the list
                if (!isValidItem) continue;

                if (itemCompressed == false)
                    AddItemToInventory(amount, itemName, isOre);
                else
                    AddItemToInventory(amount, "Compressed " + itemName, isOre);
            }
        }

        private void AddItemToInventory(int amount, string name, bool isOre)
        {
            string tName;
            if (isOre)
            {
                var ores = CollectionsProvider.AllOreList.OreList.ToList();
                if (isCommonOre.Checked)
                    tName = ores.Find(x => x.GetName() == name).GetName();
                else if (isUncommonOre.Checked)
                    tName = ores.Find(x => x.GetName() == name).GetName5();
                else
                    tName = ores.Find(x => x.GetName() == name).GetName10();
            }
            else
            {
                tName = name;
            }

            inventory.Items.Add(string.Format("{0}\t{1}", tName, amount));
        }

        private void removeItem_Click(object sender, EventArgs e)
        {
            var selectedItems = inventory.SelectedItems.OfType<string>().ToList();
            var copiedItems = inventory.Items.OfType<string>().ToList();

            if (selectedItems.Count <= 0 || copiedItems.Count <= 0) 
                return;

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
