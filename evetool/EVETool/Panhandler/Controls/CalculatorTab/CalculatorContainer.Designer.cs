namespace Panhandler.CalculatorTab
{
    partial class CalculatorContainer
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
            this.oreRadioButtonPanel = new System.Windows.Forms.Panel();
            this.isCommonOre = new System.Windows.Forms.RadioButton();
            this.isUncommonOre = new System.Windows.Forms.RadioButton();
            this.isRareOre = new System.Windows.Forms.RadioButton();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.refreshPriceButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.qtyLabel = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.ListBox();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.qtyTextbox = new System.Windows.Forms.TextBox();
            this.iceProductLabel = new System.Windows.Forms.Label();
            this.iceProductCombobox = new System.Windows.Forms.ComboBox();
            this.mineralLabel = new System.Windows.Forms.Label();
            this.mineralsCombobox = new System.Windows.Forms.ComboBox();
            this.compIceLabel = new System.Windows.Forms.Label();
            this.compIceCombobox = new System.Windows.Forms.ComboBox();
            this.iceLabel = new System.Windows.Forms.Label();
            this.iceCombobox = new System.Windows.Forms.ComboBox();
            this.compOreLabel = new System.Windows.Forms.Label();
            this.compOreCombobox = new System.Windows.Forms.ComboBox();
            this.oreLabel = new System.Windows.Forms.Label();
            this.oreCombobox = new System.Windows.Forms.ComboBox();
            this.oreRadioButtonPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // oreRadioButtonPanel
            // 
            this.oreRadioButtonPanel.Controls.Add(this.isCommonOre);
            this.oreRadioButtonPanel.Controls.Add(this.isUncommonOre);
            this.oreRadioButtonPanel.Controls.Add(this.isRareOre);
            this.oreRadioButtonPanel.Location = new System.Drawing.Point(5, 100);
            this.oreRadioButtonPanel.Name = "oreRadioButtonPanel";
            this.oreRadioButtonPanel.Size = new System.Drawing.Size(145, 26);
            this.oreRadioButtonPanel.TabIndex = 154;

            // 
            // isCommonOre
            // 
            this.isCommonOre.AutoSize = true;
            this.isCommonOre.Location = new System.Drawing.Point(3, 3);
            this.isCommonOre.Name = "isCommonOre";
            this.isCommonOre.Size = new System.Drawing.Size(45, 17);
            this.isCommonOre.TabIndex = 66;
            this.isCommonOre.TabStop = true;
            this.isCommonOre.Text = "+0%";
            this.isCommonOre.UseVisualStyleBackColor = true;
            // 
            // isUncommonOre
            // 
            this.isUncommonOre.AutoSize = true;
            this.isUncommonOre.Location = new System.Drawing.Point(50, 3);
            this.isUncommonOre.Name = "isUncommonOre";
            this.isUncommonOre.Size = new System.Drawing.Size(45, 17);
            this.isUncommonOre.TabIndex = 67;
            this.isUncommonOre.TabStop = true;
            this.isUncommonOre.Text = "+5%";
            this.isUncommonOre.UseVisualStyleBackColor = true;
            // 
            // isRareOre
            // 
            this.isRareOre.AutoSize = true;
            this.isRareOre.Location = new System.Drawing.Point(95, 3);
            this.isRareOre.Name = "isRareOre";
            this.isRareOre.Size = new System.Drawing.Size(51, 17);
            this.isRareOre.TabIndex = 68;
            this.isRareOre.TabStop = true;
            this.isRareOre.Text = "+10%";
            this.isRareOre.UseVisualStyleBackColor = true;

            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(180, 279);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(54, 13);
            this.loadingLabel.TabIndex = 153;
            this.loadingLabel.Text = "Loading...";

            // 
            // refreshPriceButton
            // 
            this.refreshPriceButton.Location = new System.Drawing.Point(251, 249);
            this.refreshPriceButton.Name = "refreshPriceButton";
            this.refreshPriceButton.Size = new System.Drawing.Size(75, 23);
            this.refreshPriceButton.TabIndex = 152;
            this.refreshPriceButton.Text = "Refresh";
            this.refreshPriceButton.UseVisualStyleBackColor = true;

            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(59, 299);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(100, 20);
            this.totalLabel.TabIndex = 151;
            this.totalLabel.Text = "Total Value";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalBox
            // 
            this.totalBox.Location = new System.Drawing.Point(174, 300);
            this.totalBox.Name = "totalBox";
            this.totalBox.Size = new System.Drawing.Size(189, 20);
            this.totalBox.TabIndex = 150;

            // 
            // qtyLabel
            // 
            this.qtyLabel.AutoSize = true;
            this.qtyLabel.Location = new System.Drawing.Point(160, 106);
            this.qtyLabel.Name = "qtyLabel";
            this.qtyLabel.Size = new System.Drawing.Size(43, 13);
            this.qtyLabel.TabIndex = 149;
            this.qtyLabel.Text = "Quantity";

            // 
            // qtyTextbox
            // 
            this.qtyTextbox.Location = new System.Drawing.Point(209, 103);
            this.qtyTextbox.Name = "qtyTextbox";
            this.qtyTextbox.Size = new System.Drawing.Size(101, 20);
            this.qtyTextbox.TabIndex = 144;

            // 
            // inventory
            // 
            this.inventory.FormattingEnabled = true;
            this.inventory.Location = new System.Drawing.Point(63, 135);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(297, 108);
            this.inventory.TabIndex = 147;

            // 
            // addItemButton
            // 
            this.addItemButton.Location = new System.Drawing.Point(332, 102);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(75, 23);
            this.addItemButton.TabIndex = 145;
            this.addItemButton.Text = "Add";
            this.addItemButton.UseVisualStyleBackColor = true;
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(89, 249);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(75, 23);
            this.removeItemButton.TabIndex = 146;
            this.removeItemButton.Text = "Remove";
            this.removeItemButton.UseVisualStyleBackColor = true;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(170, 249);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 148;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;

            // 
            // iceProductLabel
            // 
            this.iceProductLabel.AutoSize = true;
            this.iceProductLabel.Location = new System.Drawing.Point(296, 51);
            this.iceProductLabel.Name = "iceProductLabel";
            this.iceProductLabel.Size = new System.Drawing.Size(67, 13);
            this.iceProductLabel.TabIndex = 143;
            this.iceProductLabel.Text = "Ice Products";
            // 
            // iceProductCombobox
            // 
            this.iceProductCombobox.FormattingEnabled = true;
            this.iceProductCombobox.Location = new System.Drawing.Point(296, 70);
            this.iceProductCombobox.Name = "iceProductCombobox";
            this.iceProductCombobox.Size = new System.Drawing.Size(121, 21);
            this.iceProductCombobox.TabIndex = 142;

            // 
            // mineralLabel
            // 
            this.mineralLabel.AutoSize = true;
            this.mineralLabel.Location = new System.Drawing.Point(296, 8);
            this.mineralLabel.Name = "mineralLabel";
            this.mineralLabel.Size = new System.Drawing.Size(46, 13);
            this.mineralLabel.TabIndex = 141;
            this.mineralLabel.Text = "Minerals";
            // 
            // mineralsCombobox
            // 
            this.mineralsCombobox.FormattingEnabled = true;
            this.mineralsCombobox.Location = new System.Drawing.Point(296, 27);
            this.mineralsCombobox.Name = "mineralsCombobox";
            this.mineralsCombobox.Size = new System.Drawing.Size(121, 21);
            this.mineralsCombobox.TabIndex = 140;

            // 
            // compIceLabel
            // 
            this.compIceLabel.AutoSize = true;
            this.compIceLabel.Location = new System.Drawing.Point(155, 51);
            this.compIceLabel.Name = "compIceLabel";
            this.compIceLabel.Size = new System.Drawing.Size(108, 13);
            this.compIceLabel.TabIndex = 139;
            this.compIceLabel.Text = "Compressed Raw Ice";
            // 
            // compIceCombobox
            // 
            this.compIceCombobox.FormattingEnabled = true;
            this.compIceCombobox.Location = new System.Drawing.Point(155, 70);
            this.compIceCombobox.Name = "compIceCombobox";
            this.compIceCombobox.Size = new System.Drawing.Size(121, 21);
            this.compIceCombobox.TabIndex = 138;

            // 
            // iceLabel
            // 
            this.iceLabel.AutoSize = true;
            this.iceLabel.Location = new System.Drawing.Point(155, 8);
            this.iceLabel.Name = "iceLabel";
            this.iceLabel.Size = new System.Drawing.Size(47, 13);
            this.iceLabel.TabIndex = 137;
            this.iceLabel.Text = "Raw Ice";
            // 
            // iceCombobox
            // 
            this.iceCombobox.FormattingEnabled = true;
            this.iceCombobox.Location = new System.Drawing.Point(155, 27);
            this.iceCombobox.Name = "iceCombobox";
            this.iceCombobox.Size = new System.Drawing.Size(121, 21);
            this.iceCombobox.TabIndex = 136;

            // 
            // compOreLabel
            // 
            this.compOreLabel.AutoSize = true;
            this.compOreLabel.Location = new System.Drawing.Point(14, 51);
            this.compOreLabel.Name = "compOreLabel";
            this.compOreLabel.Size = new System.Drawing.Size(110, 13);
            this.compOreLabel.TabIndex = 135;
            this.compOreLabel.Text = "Compressed Raw Ore";
            // 
            // compOreCombobox
            // 
            this.compOreCombobox.FormattingEnabled = true;
            this.compOreCombobox.Location = new System.Drawing.Point(14, 70);
            this.compOreCombobox.Name = "compOreCombobox";
            this.compOreCombobox.Size = new System.Drawing.Size(121, 21);
            this.compOreCombobox.TabIndex = 134;

            // 
            // oreLabel
            // 
            this.oreLabel.AutoSize = true;
            this.oreLabel.Location = new System.Drawing.Point(14, 8);
            this.oreLabel.Name = "oreLabel";
            this.oreLabel.Size = new System.Drawing.Size(49, 13);
            this.oreLabel.TabIndex = 133;
            this.oreLabel.Text = "Raw Ore";
            // 
            // oreCombobox
            // 
            this.oreCombobox.AllowDrop = true;
            this.oreCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.oreCombobox.FormattingEnabled = true;
            this.oreCombobox.Location = new System.Drawing.Point(14, 27);
            this.oreCombobox.Name = "oreCombobox";
            this.oreCombobox.Size = new System.Drawing.Size(121, 21);
            this.oreCombobox.TabIndex = 132;

            // 
            // ContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oreRadioButtonPanel);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.refreshPriceButton);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalBox);
            this.Controls.Add(this.qtyLabel);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.removeItemButton);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.qtyTextbox);
            this.Controls.Add(this.iceProductLabel);
            this.Controls.Add(this.iceProductCombobox);
            this.Controls.Add(this.mineralLabel);
            this.Controls.Add(this.mineralsCombobox);
            this.Controls.Add(this.compIceLabel);
            this.Controls.Add(this.compIceCombobox);
            this.Controls.Add(this.iceLabel);
            this.Controls.Add(this.iceCombobox);
            this.Controls.Add(this.compOreLabel);
            this.Controls.Add(this.compOreCombobox);
            this.Controls.Add(this.oreLabel);
            this.Controls.Add(this.oreCombobox);
            this.Name = "ContainerControl";
            this.Size = new System.Drawing.Size(435, 340);
            this.oreRadioButtonPanel.ResumeLayout(false);
            this.oreRadioButtonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel oreRadioButtonPanel;
        private System.Windows.Forms.RadioButton isCommonOre;
        private System.Windows.Forms.RadioButton isUncommonOre;
        private System.Windows.Forms.RadioButton isRareOre;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Button refreshPriceButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.TextBox totalBox;
        private System.Windows.Forms.Label qtyLabel;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.ListBox inventory;
        private System.Windows.Forms.Button removeItemButton;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.TextBox qtyTextbox;
        private System.Windows.Forms.Label iceProductLabel;
        private System.Windows.Forms.ComboBox iceProductCombobox;
        private System.Windows.Forms.Label mineralLabel;
        private System.Windows.Forms.ComboBox mineralsCombobox;
        private System.Windows.Forms.Label compIceLabel;
        private System.Windows.Forms.ComboBox compIceCombobox;
        private System.Windows.Forms.Label iceLabel;
        private System.Windows.Forms.ComboBox iceCombobox;
        private System.Windows.Forms.Label compOreLabel;
        private System.Windows.Forms.ComboBox compOreCombobox;
        private System.Windows.Forms.Label oreLabel;
        private System.Windows.Forms.ComboBox oreCombobox;

    }
}
