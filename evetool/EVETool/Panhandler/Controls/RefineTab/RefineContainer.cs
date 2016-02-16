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
using Microsoft.FSharp.Collections;

namespace Panhandler.RefineTab
{
    public partial class RefineContainer : UserControl
    {
        public List<Tuple<Label, string>> PriceControls { get; set; }

        public RefineContainer()
        {
            InitializeComponent();
        }

        private void cIceValueRefreshButton_Click(object sender, EventArgs e)
        {
            var tList = ListModule.OfArray(new[] { "White Glaze\t1" });
            cWhiteGlazeValue.Text = (FunEve.MarketDomain.Market.CalculateEstimate(tList) * 0.696).ToString();
        }
    }
}
