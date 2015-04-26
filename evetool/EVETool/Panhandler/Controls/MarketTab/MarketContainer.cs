using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunEve.MarketDomain;

namespace Panhandler.MarketTab
{
    public partial class MarketContainer : UserControl
    {
        public List<Tuple<Label, string>> PriceControls { get; set; }

        public MarketContainer()
        {
            InitializeComponent();

            this.PriceControls = new List<Tuple<Label, string>>() {
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
        }
    }
}
