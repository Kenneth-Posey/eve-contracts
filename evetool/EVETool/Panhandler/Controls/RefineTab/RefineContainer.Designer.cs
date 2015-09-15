namespace Panhandler.RefineTab
{
    partial class RefineContainer
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
            this.cWhiteGlazeLabel = new System.Windows.Forms.Label();
            this.cWhiteGlazeValue = new System.Windows.Forms.Label();
            this.cIceValueRefreshButton = new System.Windows.Forms.Button();
            this.marketPricePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // marketPricePanel
            // 
            this.marketPricePanel.Controls.Add(this.cIceValueRefreshButton);
            this.marketPricePanel.Controls.Add(this.cWhiteGlazeValue);
            this.marketPricePanel.Controls.Add(this.cWhiteGlazeLabel);
            this.marketPricePanel.Location = new System.Drawing.Point(3, 3);
            this.marketPricePanel.Name = "marketPricePanel";
            this.marketPricePanel.Size = new System.Drawing.Size(259, 350);
            this.marketPricePanel.TabIndex = 1;
            // 
            // cWhiteGlazeLabel
            // 
            this.cWhiteGlazeLabel.AutoSize = true;
            this.cWhiteGlazeLabel.Location = new System.Drawing.Point(15, 59);
            this.cWhiteGlazeLabel.Name = "cWhiteGlazeLabel";
            this.cWhiteGlazeLabel.Size = new System.Drawing.Size(65, 13);
            this.cWhiteGlazeLabel.TabIndex = 0;
            this.cWhiteGlazeLabel.Text = "White Glaze";
            // 
            // cWhiteGlazeValue
            // 
            this.cWhiteGlazeValue.AutoSize = true;
            this.cWhiteGlazeValue.Location = new System.Drawing.Point(110, 59);
            this.cWhiteGlazeValue.Name = "cWhiteGlazeValue";
            this.cWhiteGlazeValue.Size = new System.Drawing.Size(40, 13);
            this.cWhiteGlazeValue.TabIndex = 1;
            this.cWhiteGlazeValue.Text = "10,000";
            // 
            // cIceValueRefreshButton
            // 
            this.cIceValueRefreshButton.Location = new System.Drawing.Point(5, 3);
            this.cIceValueRefreshButton.Name = "cIceValueRefreshButton";
            this.cIceValueRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.cIceValueRefreshButton.TabIndex = 2;
            this.cIceValueRefreshButton.Text = "Refresh";
            this.cIceValueRefreshButton.UseVisualStyleBackColor = true;
            this.cIceValueRefreshButton.Click += new System.EventHandler(this.cIceValueRefreshButton_Click);
            // 
            // RefineContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.marketPricePanel);
            this.Name = "RefineContainer";
            this.Size = new System.Drawing.Size(266, 356);
            this.marketPricePanel.ResumeLayout(false);
            this.marketPricePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel marketPricePanel;
        private System.Windows.Forms.Label cWhiteGlazeValue;
        private System.Windows.Forms.Label cWhiteGlazeLabel;
        private System.Windows.Forms.Button cIceValueRefreshButton;
    }
}
