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

namespace Panhandler
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
            
            // We sometimes want to share properties from one control to another
            // so they can manipulate each other
            this.calculator.MarketPriceControls = this.market.PriceControls;

        }

        // Tab control flicker nerf
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
