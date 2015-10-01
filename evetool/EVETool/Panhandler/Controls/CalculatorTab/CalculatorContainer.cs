using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.FSharp.Collections;
using System.Globalization;
using FunEve.Interop;
using FunEve.MarketDomain;

namespace Panhandler.CalculatorTab
{
    public partial class CalculatorContainer : UserControl
    {
        List<ComboBox> MaterialBoxList { get; set; }
        List<string> RawOre { get; set; }
        List<string> RawIce { get; set; }
        List<string> Minerals { get; set; }
        List<string> IceProducts { get; set; }

        public List<Tuple<Label, string>> MarketPriceControls { get; set; }

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

            oreCombobox.Items.AddRange(Data.Ore.Names.ToArray<object>());
            compOreCombobox.Items.AddRange(Data.Ore.Names.ToArray<object>());
            iceCombobox.Items.AddRange(Data.Ice.Names.ToArray<object>());
            compIceCombobox.Items.AddRange(Data.Ice.Names.ToArray<object>());
            mineralsCombobox.Items.AddRange(Data.Mineral.Names.ToArray<object>());
            iceProductCombobox.Items.AddRange(Data.IceProduct.Names.ToArray<object>());

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

            totalLabel.Click += totalLabel_Click;
            calculateButton.Click += calculate_Click;
            removeItemButton.Click += removeItem_Click;
            addItemButton.Click += addItem_Click;
            refreshPriceButton.Click += refresh_Click;

            this.RawOre = FunEve.Interop.Data.Ore.Names.ToList();
            this.RawIce = FunEve.Interop.Data.Ice.Names.ToList();
            this.Minerals = FunEve.Interop.Data.Mineral.Names.ToList();
            this.IceProducts = FunEve.Interop.Data.IceProduct.Names.ToList();

        }

        protected async void refresh_Click(object sender, EventArgs e)
        {
            loadingLabel.Text = "Loading...";
            loadingLabel.Refresh();

            var priceLabels = this.MarketPriceControls;

            var allItems = await loadItems();
            foreach (var pair in priceLabels)
                pair.Item1.Text = allItems.Find(x => x.Id.Value == LoadIdByName(pair.Item2)).Value.Value.ToString();

            loadingLabel.Text = "";
        }

        private static int LoadIdByName(string name)
        {
            var allItems = Market.MaterialNameIdList.ToList();
            return allItems.Find(x => x.Name.Value == name).Id.Value;
        }

        private async Task<List<Market.MaterialData>> loadItems()
        {
            return Market.LoadRefinedMaterialPricesLowSell().ToList();
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
            // this.Parent.Focus();
            await addItems(amount);
        }

        private async Task addItems(int amount)
        {
            foreach (var box in MaterialBoxList)
            {
                if (box.SelectedIndex <= 0)
                    continue;

                var name = box.SelectedItem.ToString();
                box.SelectedIndex = 0;

                var isOre = RawOre.Contains(name);
                var isIce = RawIce.Contains(name);
                var isIceProduct = IceProducts.Contains(name);
                var isMineral = Minerals.Contains(name);

                // skips unknown items in the list
                var isKnown = isOre || isIce || isIceProduct || isMineral;
                if (isKnown == false) continue;

                switch (box.Name)
                {
                    case "compOreCombobox":
                    case "compIceCombobox":
                        AddItemToInventory(amount, "Compressed " + name, isOre);
                        break;
                    case "oreCombobox":
                    case "iceCombobox":
                    default:                            
                        AddItemToInventory(amount, name, isOre);
                        break;
                }
            }
        }

        private void AddItemToInventory(int amount, string name, bool isOre)
        {
            string tName;
            if (isOre)
            {
                var ores = FunEve.Interop.Data.Ore.OreNames.ToList();
                var ore = ores.Find(x => x.Item1 == name);

                if (isCommonOre.Checked)
                    tName = ore.Item1;
                else if (isUncommonOre.Checked)
                    tName = ore.Item2;
                else
                    tName = ore.Item3;
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
            var nonSelectedItems = inventory.Items.OfType<string>().ToList();

            if (selectedItems.Count <= 0 || nonSelectedItems.Count <= 0) 
                return;

            foreach (var listItem in selectedItems)
                nonSelectedItems.Remove(listItem);

            inventory.Items.Clear();
            foreach (var item in nonSelectedItems)
                inventory.Items.Add(item);
        }

        private static async Task<double> CalculateEstimate(List<string> pSplitLines)
        {
            var tSplitLines = ListModule.OfArray(pSplitLines.ToArray());
            return FunEve.MarketDomain.Market.CalculateEstimateOre(tSplitLines);
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

        private void refreshPriceButton_Click(object sender, EventArgs e)
        {

        }
    }
}
