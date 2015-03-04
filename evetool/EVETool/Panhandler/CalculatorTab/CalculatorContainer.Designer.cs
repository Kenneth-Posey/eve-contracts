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
            this.refreshPrices = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalBox = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.ListBox();
            this.Remove = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.iceProductCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mineralsCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.compIceCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iceCombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.compOreCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // refreshPrices
            // 
            this.refreshPrices.Location = new System.Drawing.Point(251, 249);
            this.refreshPrices.Name = "refreshPrices";
            this.refreshPrices.Size = new System.Drawing.Size(75, 23);
            this.refreshPrices.TabIndex = 152;
            this.refreshPrices.Text = "Refresh";
            this.refreshPrices.UseVisualStyleBackColor = true;
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
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(160, 106);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 13);
            this.label32.TabIndex = 149;
            this.label32.Text = "Amount";
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(170, 249);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(75, 23);
            this.Calculate.TabIndex = 148;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            // 
            // inventory
            // 
            this.inventory.FormattingEnabled = true;
            this.inventory.Location = new System.Drawing.Point(63, 135);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(297, 108);
            this.inventory.TabIndex = 147;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(89, 249);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 23);
            this.Remove.TabIndex = 146;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(332, 102);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 145;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // qty
            // 
            this.qty.Location = new System.Drawing.Point(209, 103);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(101, 20);
            this.qty.TabIndex = 144;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 143;
            this.label6.Text = "Ice Products";
            // 
            // iceProductCombobox
            // 
            this.iceProductCombobox.FormattingEnabled = true;
            this.iceProductCombobox.Location = new System.Drawing.Point(296, 70);
            this.iceProductCombobox.Name = "iceProductCombobox";
            this.iceProductCombobox.Size = new System.Drawing.Size(121, 21);
            this.iceProductCombobox.TabIndex = 142;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 141;
            this.label5.Text = "Minerals";
            // 
            // mineralsCombobox
            // 
            this.mineralsCombobox.FormattingEnabled = true;
            this.mineralsCombobox.Location = new System.Drawing.Point(296, 27);
            this.mineralsCombobox.Name = "mineralsCombobox";
            this.mineralsCombobox.Size = new System.Drawing.Size(121, 21);
            this.mineralsCombobox.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 139;
            this.label4.Text = "Compressed Raw Ice";
            // 
            // compIceCombobox
            // 
            this.compIceCombobox.FormattingEnabled = true;
            this.compIceCombobox.Location = new System.Drawing.Point(155, 70);
            this.compIceCombobox.Name = "compIceCombobox";
            this.compIceCombobox.Size = new System.Drawing.Size(121, 21);
            this.compIceCombobox.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 137;
            this.label3.Text = "Raw Ice";
            // 
            // iceCombobox
            // 
            this.iceCombobox.FormattingEnabled = true;
            this.iceCombobox.Location = new System.Drawing.Point(155, 27);
            this.iceCombobox.Name = "iceCombobox";
            this.iceCombobox.Size = new System.Drawing.Size(121, 21);
            this.iceCombobox.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 135;
            this.label2.Text = "Compressed Raw Ore";
            // 
            // compOreCombobox
            // 
            this.compOreCombobox.FormattingEnabled = true;
            this.compOreCombobox.Location = new System.Drawing.Point(14, 70);
            this.compOreCombobox.Name = "compOreCombobox";
            this.compOreCombobox.Size = new System.Drawing.Size(121, 21);
            this.compOreCombobox.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Raw Ore";
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
            this.Controls.Add(this.refreshPrices);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalBox);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.iceProductCombobox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mineralsCombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.compIceCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iceCombobox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.compOreCombobox);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button refreshPrices;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.TextBox totalBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.ListBox inventory;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox iceProductCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mineralsCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox compIceCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox iceCombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox compOreCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox oreCombobox;

    }
}
