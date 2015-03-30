using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EveOnline.MarketDomain;

namespace Panhandler.MarketTab
{
    public partial class MarketContainer : UserControl
    {
        public MarketContainer()
        {
            InitializeComponent();
        }

        private async void refresh_Click(object sender, EventArgs e)
        {
            loadingLabel.Text = "Loading...";
            loadingLabel.Refresh();

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
                , Tuple.Create(ozoneValue, "Liquid Ozone")
                , Tuple.Create(strontiumClathratesValue, "Strontium Clathrates")
                , Tuple.Create(heliumIsotopeValue, "Helium Isotopes")
                , Tuple.Create(hydrogenIsotopeValue, "Hydrogen Isotopes")
                , Tuple.Create(oxygenIsotopeValue, "Oxygen Isotopes")
                , Tuple.Create(nitrogenIsotopeValue, "Nitrogen Isotopes")
            };

            var allItems = await loadItems();
            foreach (var pair in priceLabels)
                pair.Item1.Text = allItems.Find(x => x.Id == LoadIdByName(pair.Item2)).Value.ToString();

            loadingLabel.Text = "";
        }

        private static int LoadIdByName(string name)
        {
            var allItems = Market.MaterialNameIdList.ToList();
            return allItems.Find(x => x.Name == name).Id;
        }

        private async Task<List<Market.MaterialData>> loadItems()
        {
            return Market.LoadRefinedMaterialPricesLowSell().ToList();
        }
    }
}
