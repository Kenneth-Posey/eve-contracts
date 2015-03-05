namespace Panhandler.MarketTab
{
    partial class MarketContainer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.marketPricePanel = new System.Windows.Forms.Panel();

            this.pricesTabControl = new System.Windows.Forms.TabControl();
            this.mineralPriceTab = new System.Windows.Forms.TabPage();
            this.iceProductPriceTab = new System.Windows.Forms.TabPage();

            this.mineralValuePanel = new System.Windows.Forms.Panel();
            this.pyeriteLabel = new System.Windows.Forms.Label();
            this.isogenLabel = new System.Windows.Forms.Label();
            this.zydrineLabel = new System.Windows.Forms.Label();
            this.nocxiumValue = new System.Windows.Forms.Label();
            this.tritaniumLabel = new System.Windows.Forms.Label();
            this.mexallonLabel = new System.Windows.Forms.Label();
            this.nocxiumLabel = new System.Windows.Forms.Label();
            this.morphiteLabel = new System.Windows.Forms.Label();
            this.megacyteLabel = new System.Windows.Forms.Label();
            this.morphiteValue = new System.Windows.Forms.Label();
            this.megacyteValue = new System.Windows.Forms.Label();
            this.isogenValue = new System.Windows.Forms.Label();
            this.mexallonValue = new System.Windows.Forms.Label();
            this.pyeriteValue = new System.Windows.Forms.Label();
            this.tritaniumValue = new System.Windows.Forms.Label();
            this.zydrineValue = new System.Windows.Forms.Label();

            this.iceProductValuePanel = new System.Windows.Forms.Panel();
            this.strontiumLabel = new System.Windows.Forms.Label();
            this.nitrogenLabel = new System.Windows.Forms.Label();
            this.hydrogenLabel = new System.Windows.Forms.Label();
            this.ozoneLabel = new System.Windows.Forms.Label();
            this.heliumLabel = new System.Windows.Forms.Label();
            this.oxygenLabel = new System.Windows.Forms.Label();
            this.heavyWaterLabel = new System.Windows.Forms.Label();
            this.nitrogenIsotopeValue = new System.Windows.Forms.Label();
            this.heliumIsotopeValue = new System.Windows.Forms.Label();
            this.oxygenIsotopeValue = new System.Windows.Forms.Label();
            this.strontiumClathratesValue = new System.Windows.Forms.Label();
            this.hydrogenIsotopeValue = new System.Windows.Forms.Label();
            this.heavyWaterValue = new System.Windows.Forms.Label();
            this.ozoneValue = new System.Windows.Forms.Label();

            this.loadingLabel = new System.Windows.Forms.Label();

            this.marketPricePanel.SuspendLayout();
            this.pricesTabControl.SuspendLayout();
            this.mineralPriceTab.SuspendLayout();
            this.mineralValuePanel.SuspendLayout();
            this.iceProductPriceTab.SuspendLayout();
            this.iceProductValuePanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // marketPricePanel
            // 
            this.marketPricePanel.Controls.Add(this.pricesTabControl);
            this.marketPricePanel.Location = new System.Drawing.Point(3, 3);
            this.marketPricePanel.Name = "marketPricePanel";
            this.marketPricePanel.Size = new System.Drawing.Size(259, 350);
            this.marketPricePanel.TabIndex = 1;

            // 
            // pricesTabControl
            // 
            this.pricesTabControl.Controls.Add(this.mineralPriceTab);
            this.pricesTabControl.Controls.Add(this.iceProductPriceTab);
            this.pricesTabControl.Location = new System.Drawing.Point(3, 3);
            this.pricesTabControl.Name = "pricesTabControl";
            this.pricesTabControl.SelectedIndex = 0;
            this.pricesTabControl.Size = new System.Drawing.Size(249, 335);
            this.pricesTabControl.TabIndex = 128;

            // 
            // mineralPriceTab
            // 
            this.mineralPriceTab.Controls.Add(this.mineralValuePanel);
            this.mineralPriceTab.Location = new System.Drawing.Point(4, 22);
            this.mineralPriceTab.Name = "mineralPriceTab";
            this.mineralPriceTab.Padding = new System.Windows.Forms.Padding(3);
            this.mineralPriceTab.Size = new System.Drawing.Size(241, 309);
            this.mineralPriceTab.TabIndex = 0;
            this.mineralPriceTab.Text = "Minerals";
            this.mineralPriceTab.UseVisualStyleBackColor = true;

            // 
            // iceProductPriceTab
            // 
            this.iceProductPriceTab.Controls.Add(this.iceProductValuePanel);
            this.iceProductPriceTab.Location = new System.Drawing.Point(4, 22);
            this.iceProductPriceTab.Name = "iceProductPriceTab";
            this.iceProductPriceTab.Padding = new System.Windows.Forms.Padding(3);
            this.iceProductPriceTab.Size = new System.Drawing.Size(241, 309);
            this.iceProductPriceTab.TabIndex = 1;
            this.iceProductPriceTab.Text = "Ice Products";
            this.iceProductPriceTab.UseVisualStyleBackColor = true;
            
            // 
            // mineralValuePanel
            // 
            this.mineralValuePanel.Controls.Add(this.loadingLabel);

            this.mineralValuePanel.Controls.Add(this.morphiteValue);
            this.mineralValuePanel.Controls.Add(this.megacyteValue);
            this.mineralValuePanel.Controls.Add(this.isogenValue);
            this.mineralValuePanel.Controls.Add(this.mexallonValue);
            this.mineralValuePanel.Controls.Add(this.pyeriteValue);
            this.mineralValuePanel.Controls.Add(this.tritaniumValue);
            this.mineralValuePanel.Controls.Add(this.zydrineValue);
            this.mineralValuePanel.Controls.Add(this.nocxiumValue);

            this.mineralValuePanel.Controls.Add(this.morphiteLabel);
            this.mineralValuePanel.Controls.Add(this.megacyteLabel);
            this.mineralValuePanel.Controls.Add(this.pyeriteLabel);
            this.mineralValuePanel.Controls.Add(this.isogenLabel);
            this.mineralValuePanel.Controls.Add(this.zydrineLabel);
            this.mineralValuePanel.Controls.Add(this.tritaniumLabel);
            this.mineralValuePanel.Controls.Add(this.mexallonLabel);
            this.mineralValuePanel.Controls.Add(this.nocxiumLabel);

            this.mineralValuePanel.Location = new System.Drawing.Point(6, 6);
            this.mineralValuePanel.Name = "mineralValuePanel";
            this.mineralValuePanel.Size = new System.Drawing.Size(224, 292);
            this.mineralValuePanel.TabIndex = 16;
            
            // 
            // iceProductValuePanel
            // 
            this.iceProductValuePanel.Controls.Add(this.strontiumLabel);
            this.iceProductValuePanel.Controls.Add(this.nitrogenLabel);
            this.iceProductValuePanel.Controls.Add(this.hydrogenLabel);
            this.iceProductValuePanel.Controls.Add(this.ozoneLabel);
            this.iceProductValuePanel.Controls.Add(this.heliumLabel);
            this.iceProductValuePanel.Controls.Add(this.oxygenLabel);
            this.iceProductValuePanel.Controls.Add(this.heavyWaterLabel);
            this.iceProductValuePanel.Controls.Add(this.nitrogenIsotopeValue);
            this.iceProductValuePanel.Controls.Add(this.heliumIsotopeValue);
            this.iceProductValuePanel.Controls.Add(this.oxygenIsotopeValue);
            this.iceProductValuePanel.Controls.Add(this.strontiumClathratesValue);
            this.iceProductValuePanel.Controls.Add(this.hydrogenIsotopeValue);
            this.iceProductValuePanel.Controls.Add(this.heavyWaterValue);
            this.iceProductValuePanel.Controls.Add(this.ozoneValue);
            this.iceProductValuePanel.Location = new System.Drawing.Point(6, 6);
            this.iceProductValuePanel.Name = "iceProductValuePanel";
            this.iceProductValuePanel.Size = new System.Drawing.Size(215, 301);
            this.iceProductValuePanel.TabIndex = 0;

            // 
            // morphiteLabel
            // 
            this.morphiteLabel.AutoSize = true;
            this.morphiteLabel.Location = new System.Drawing.Point(10, 122);
            this.morphiteLabel.Name = "morphiteLabel";
            this.morphiteLabel.Size = new System.Drawing.Size(48, 13);
            this.morphiteLabel.TabIndex = 134;
            this.morphiteLabel.Text = "Morphite";
            // 
            // morphiteValue
            // 
            this.morphiteValue.AutoSize = true;
            this.morphiteValue.Location = new System.Drawing.Point(98, 122);
            this.morphiteValue.Name = "morphiteValue";
            this.morphiteValue.Size = new System.Drawing.Size(55, 13);
            this.morphiteValue.TabIndex = 132;
            this.morphiteValue.Text = "10,000.00";

            // 
            // megacyteLabel
            // 
            this.megacyteLabel.AutoSize = true;
            this.megacyteLabel.Location = new System.Drawing.Point(10, 55);
            this.megacyteLabel.Name = "megacyteLabel";
            this.megacyteLabel.Size = new System.Drawing.Size(54, 13);
            this.megacyteLabel.TabIndex = 133;
            this.megacyteLabel.Text = "Megacyte";
            // 
            // megacyteValue
            // 
            this.megacyteValue.AutoSize = true;
            this.megacyteValue.Location = new System.Drawing.Point(98, 55);
            this.megacyteValue.Name = "megacyteValue";
            this.megacyteValue.Size = new System.Drawing.Size(55, 13);
            this.megacyteValue.TabIndex = 131;
            this.megacyteValue.Text = "10,000.00";

            // 
            // isogenLabel
            // 
            this.isogenLabel.AutoSize = true;
            this.isogenLabel.Location = new System.Drawing.Point(10, 99);
            this.isogenLabel.Name = "isogenLabel";
            this.isogenLabel.Size = new System.Drawing.Size(39, 13);
            this.isogenLabel.TabIndex = 124;
            this.isogenLabel.Text = "Isogen";
            // 
            // isogenValue
            // 
            this.isogenValue.AutoSize = true;
            this.isogenValue.Location = new System.Drawing.Point(98, 99);
            this.isogenValue.Name = "isogenValue";
            this.isogenValue.Size = new System.Drawing.Size(55, 13);
            this.isogenValue.TabIndex = 130;
            this.isogenValue.Text = "10,000.00";

            // 
            // mexallonLabel
            // 
            this.mexallonLabel.AutoSize = true;
            this.mexallonLabel.Location = new System.Drawing.Point(10, 77);
            this.mexallonLabel.Name = "mexallonLabel";
            this.mexallonLabel.Size = new System.Drawing.Size(49, 13);
            this.mexallonLabel.TabIndex = 120;
            this.mexallonLabel.Text = "Mexallon";
            // 
            // mexallonValue
            // 
            this.mexallonValue.AutoSize = true;
            this.mexallonValue.Location = new System.Drawing.Point(98, 77);
            this.mexallonValue.Name = "mexallonValue";
            this.mexallonValue.Size = new System.Drawing.Size(55, 13);
            this.mexallonValue.TabIndex = 129;
            this.mexallonValue.Text = "10,000.00";

            // 
            // pyeriteLabel
            // 
            this.pyeriteLabel.AutoSize = true;
            this.pyeriteLabel.Location = new System.Drawing.Point(10, 32);
            this.pyeriteLabel.Name = "pyeriteLabel";
            this.pyeriteLabel.Size = new System.Drawing.Size(39, 13);
            this.pyeriteLabel.TabIndex = 125;
            this.pyeriteLabel.Text = "Pyerite";
            // 
            // pyeriteValue
            // 
            this.pyeriteValue.AutoSize = true;
            this.pyeriteValue.Location = new System.Drawing.Point(98, 32);
            this.pyeriteValue.Name = "pyeriteValue";
            this.pyeriteValue.Size = new System.Drawing.Size(55, 13);
            this.pyeriteValue.TabIndex = 128;
            this.pyeriteValue.Text = "10,000.00";

            // 
            // tritaniumLabel
            // 
            this.tritaniumLabel.AutoSize = true;
            this.tritaniumLabel.Location = new System.Drawing.Point(10, 10);
            this.tritaniumLabel.Name = "tritaniumLabel";
            this.tritaniumLabel.Size = new System.Drawing.Size(50, 13);
            this.tritaniumLabel.TabIndex = 121;
            this.tritaniumLabel.Text = "Tritanium";
            // 
            // tritaniumValue
            // 
            this.tritaniumValue.AutoSize = true;
            this.tritaniumValue.Location = new System.Drawing.Point(98, 10);
            this.tritaniumValue.Name = "tritaniumValue";
            this.tritaniumValue.Size = new System.Drawing.Size(55, 13);
            this.tritaniumValue.TabIndex = 127;
            this.tritaniumValue.Text = "10,000.00";

            // 
            // zydrineLabel
            // 
            this.zydrineLabel.AutoSize = true;
            this.zydrineLabel.Location = new System.Drawing.Point(11, 170);
            this.zydrineLabel.Name = "zydrineLabel";
            this.zydrineLabel.Size = new System.Drawing.Size(42, 13);
            this.zydrineLabel.TabIndex = 123;
            this.zydrineLabel.Text = "Zydrine";
            // 
            // zydrineValue
            // 
            this.zydrineValue.AutoSize = true;
            this.zydrineValue.Location = new System.Drawing.Point(98, 170);
            this.zydrineValue.Name = "zydrineValue";
            this.zydrineValue.Size = new System.Drawing.Size(55, 13);
            this.zydrineValue.TabIndex = 126;
            this.zydrineValue.Text = "10,000.00";

            // 
            // nocxiumLabel
            // 
            this.nocxiumLabel.AutoSize = true;
            this.nocxiumLabel.Location = new System.Drawing.Point(11, 148);
            this.nocxiumLabel.Name = "nocxiumLabel";
            this.nocxiumLabel.Size = new System.Drawing.Size(48, 13);
            this.nocxiumLabel.TabIndex = 119;
            this.nocxiumLabel.Text = "Nocxium";
            // 
            // nocxiumValue
            // 
            this.nocxiumValue.AutoSize = true;
            this.nocxiumValue.Location = new System.Drawing.Point(98, 148);
            this.nocxiumValue.Name = "nocxiumValue";
            this.nocxiumValue.Size = new System.Drawing.Size(55, 13);
            this.nocxiumValue.TabIndex = 122;
            this.nocxiumValue.Text = "10,000.00";

            // 
            // strontiumLabel
            // 
            this.strontiumLabel.AutoSize = true;
            this.strontiumLabel.Location = new System.Drawing.Point(24, 162);
            this.strontiumLabel.Name = "strontiumLabel";
            this.strontiumLabel.Size = new System.Drawing.Size(101, 13);
            this.strontiumLabel.TabIndex = 139;
            this.strontiumLabel.Text = "Strontium Clathrates";
            // 
            // strontiumClathratesValue
            // 
            this.strontiumClathratesValue.AutoSize = true;
            this.strontiumClathratesValue.Location = new System.Drawing.Point(131, 162);
            this.strontiumClathratesValue.Name = "strontiumClathratesValue";
            this.strontiumClathratesValue.Size = new System.Drawing.Size(55, 13);
            this.strontiumClathratesValue.TabIndex = 129;
            this.strontiumClathratesValue.Text = "10,000.00";

            // 
            // hydrogenLabel
            // 
            this.hydrogenLabel.AutoSize = true;
            this.hydrogenLabel.Location = new System.Drawing.Point(24, 117);
            this.hydrogenLabel.Name = "hydrogenLabel";
            this.hydrogenLabel.Size = new System.Drawing.Size(96, 13);
            this.hydrogenLabel.TabIndex = 137;
            this.hydrogenLabel.Text = "Hydrogen Isotopes";
            // 
            // hydrogenIsotopeValue
            // 
            this.hydrogenIsotopeValue.AutoSize = true;
            this.hydrogenIsotopeValue.Location = new System.Drawing.Point(131, 117);
            this.hydrogenIsotopeValue.Name = "hydrogenIsotopeValue";
            this.hydrogenIsotopeValue.Size = new System.Drawing.Size(55, 13);
            this.hydrogenIsotopeValue.TabIndex = 128;
            this.hydrogenIsotopeValue.Text = "10,000.00";

            // 
            // ozoneLabel
            // 
            this.ozoneLabel.AutoSize = true;
            this.ozoneLabel.Location = new System.Drawing.Point(24, 94);
            this.ozoneLabel.Name = "ozoneLabel";
            this.ozoneLabel.Size = new System.Drawing.Size(69, 13);
            this.ozoneLabel.TabIndex = 136;
            this.ozoneLabel.Text = "Liquid Ozone";
            // 
            // liquidOzoneValue
            // 
            this.ozoneValue.AutoSize = true;
            this.ozoneValue.Location = new System.Drawing.Point(131, 94);
            this.ozoneValue.Name = "liquidOzoneValue";
            this.ozoneValue.Size = new System.Drawing.Size(55, 13);
            this.ozoneValue.TabIndex = 126;
            this.ozoneValue.Text = "10,000.00";

            // 
            // heliumLabel
            // 
            this.heliumLabel.AutoSize = true;
            this.heliumLabel.Location = new System.Drawing.Point(23, 48);
            this.heliumLabel.Name = "heliumLabel";
            this.heliumLabel.Size = new System.Drawing.Size(82, 13);
            this.heliumLabel.TabIndex = 135;
            this.heliumLabel.Text = "Helium Isotopes";
            // 
            // heliumIsotopeValue
            // 
            this.heliumIsotopeValue.AutoSize = true;
            this.heliumIsotopeValue.Location = new System.Drawing.Point(131, 48);
            this.heliumIsotopeValue.Name = "heliumIsotopeValue";
            this.heliumIsotopeValue.Size = new System.Drawing.Size(55, 13);
            this.heliumIsotopeValue.TabIndex = 131;
            this.heliumIsotopeValue.Text = "10,000.00";

            // 
            // oxygenLabel
            // 
            this.oxygenLabel.AutoSize = true;
            this.oxygenLabel.Location = new System.Drawing.Point(23, 71);
            this.oxygenLabel.Name = "oxygenLabel";
            this.oxygenLabel.Size = new System.Drawing.Size(86, 13);
            this.oxygenLabel.TabIndex = 134;
            this.oxygenLabel.Text = "Oxygen Isotopes";
            // 
            // oxygenIsotopeValue
            // 
            this.oxygenIsotopeValue.AutoSize = true;
            this.oxygenIsotopeValue.Location = new System.Drawing.Point(131, 71);
            this.oxygenIsotopeValue.Name = "oxygenIsotopeValue";
            this.oxygenIsotopeValue.Size = new System.Drawing.Size(55, 13);
            this.oxygenIsotopeValue.TabIndex = 130;
            this.oxygenIsotopeValue.Text = "10,000.00";

            // 
            // heavyWaterLabel
            // 
            this.heavyWaterLabel.AutoSize = true;
            this.heavyWaterLabel.Location = new System.Drawing.Point(23, 25);
            this.heavyWaterLabel.Name = "heavyWaterLabel";
            this.heavyWaterLabel.Size = new System.Drawing.Size(70, 13);
            this.heavyWaterLabel.TabIndex = 133;
            this.heavyWaterLabel.Text = "Heavy Water";
            // 
            // heavyWaterValue
            // 
            this.heavyWaterValue.AutoSize = true;
            this.heavyWaterValue.Location = new System.Drawing.Point(131, 25);
            this.heavyWaterValue.Name = "heavyWaterValue";
            this.heavyWaterValue.Size = new System.Drawing.Size(55, 13);
            this.heavyWaterValue.TabIndex = 127;
            this.heavyWaterValue.Text = "10,000.00";
            
            // 
            // label28
            // 
            this.nitrogenLabel.AutoSize = true;
            this.nitrogenLabel.Location = new System.Drawing.Point(24, 140);
            this.nitrogenLabel.Name = "label28";
            this.nitrogenLabel.Size = new System.Drawing.Size(90, 13);
            this.nitrogenLabel.TabIndex = 138;
            this.nitrogenLabel.Text = "Nitrogen Isotopes";
            // 
            // nitrogenIsotopeValue
            // 
            this.nitrogenIsotopeValue.AutoSize = true;
            this.nitrogenIsotopeValue.Location = new System.Drawing.Point(131, 140);
            this.nitrogenIsotopeValue.Name = "nitrogenIsotopeValue";
            this.nitrogenIsotopeValue.Size = new System.Drawing.Size(55, 13);
            this.nitrogenIsotopeValue.TabIndex = 132;
            this.nitrogenIsotopeValue.Text = "10,000.00";

            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(14, 202);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(22, 13);
            this.loadingLabel.TabIndex = 135;
            this.loadingLabel.Text = "loading...";

            // 
            // ContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.marketPricePanel);
            this.Name = "ContainerControl";
            this.Size = new System.Drawing.Size(266, 356);
            this.marketPricePanel.ResumeLayout(false);
            this.pricesTabControl.ResumeLayout(false);
            this.mineralPriceTab.ResumeLayout(false);
            this.mineralValuePanel.ResumeLayout(false);
            // this.mineralValuePanel.PerformLayout();
            this.iceProductPriceTab.ResumeLayout(false);
            this.iceProductValuePanel.ResumeLayout(false);
            // this.iceProductValuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel marketPricePanel;
        private System.Windows.Forms.TabControl pricesTabControl;

        private System.Windows.Forms.TabPage mineralPriceTab;
        private System.Windows.Forms.Panel mineralValuePanel;
        private System.Windows.Forms.Label morphiteValue;
        private System.Windows.Forms.Label megacyteValue;
        private System.Windows.Forms.Label isogenValue;
        private System.Windows.Forms.Label mexallonValue;
        private System.Windows.Forms.Label pyeriteValue;
        private System.Windows.Forms.Label tritaniumValue;
        private System.Windows.Forms.Label zydrineValue;
        private System.Windows.Forms.Label nocxiumValue;
        private System.Windows.Forms.Label morphiteLabel;
        private System.Windows.Forms.Label megacyteLabel;
        private System.Windows.Forms.Label pyeriteLabel;
        private System.Windows.Forms.Label isogenLabel;
        private System.Windows.Forms.Label zydrineLabel;
        private System.Windows.Forms.Label tritaniumLabel;
        private System.Windows.Forms.Label mexallonLabel;
        private System.Windows.Forms.Label nocxiumLabel;

        private System.Windows.Forms.TabPage iceProductPriceTab;
        private System.Windows.Forms.Panel iceProductValuePanel;
        private System.Windows.Forms.Label strontiumLabel;
        private System.Windows.Forms.Label nitrogenLabel;
        private System.Windows.Forms.Label hydrogenLabel;
        private System.Windows.Forms.Label ozoneLabel;
        private System.Windows.Forms.Label heliumLabel;
        private System.Windows.Forms.Label oxygenLabel;
        private System.Windows.Forms.Label heavyWaterLabel;
        private System.Windows.Forms.Label nitrogenIsotopeValue;
        private System.Windows.Forms.Label heliumIsotopeValue;
        private System.Windows.Forms.Label oxygenIsotopeValue;
        private System.Windows.Forms.Label strontiumClathratesValue;
        private System.Windows.Forms.Label hydrogenIsotopeValue;
        private System.Windows.Forms.Label heavyWaterValue;
        private System.Windows.Forms.Label ozoneValue;
        private System.Windows.Forms.Label loadingLabel;
    }
}
