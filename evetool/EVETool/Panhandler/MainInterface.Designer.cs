using System.Security.AccessControl;
using Panhandler.CalculatorTab;
using Panhandler.MarketTab;
using Panhandler.Objects;
using Panhandler.UserTab;

namespace Panhandler
{
    partial class MainInterface
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calculator = new Panhandler.CalculatorTab.CalculatorContainer();
            this.market = new Panhandler.MarketTab.MarketContainer();
            this.users = new Panhandler.UserTab.UserContainer();

            this.tabContainer = new System.Windows.Forms.TabControl();
            this.calculatorTabPage = new System.Windows.Forms.TabPage();
            this.userTabPage = new System.Windows.Forms.TabPage();
            this.marketTabPage = new System.Windows.Forms.TabPage();

            this.tabContainer.SuspendLayout();
            this.calculatorTabPage.SuspendLayout();
            this.marketTabPage.SuspendLayout();
            this.userTabPage.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.calculatorTabPage);
            this.tabContainer.Controls.Add(this.userTabPage);
            this.tabContainer.Controls.Add(this.marketTabPage);
            this.tabContainer.Location = new System.Drawing.Point(12, 12);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1161, 407);
            this.tabContainer.TabIndex = 17;

            // 
            // calculatorTabPage
            // 
            this.calculatorTabPage.Controls.Add(this.calculator);
            this.calculatorTabPage.Location = new System.Drawing.Point(4, 22);
            this.calculatorTabPage.Name = "calculatorTabPage";
            this.calculatorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.calculatorTabPage.Size = new System.Drawing.Size(1153, 381);
            this.calculatorTabPage.TabIndex = 0;
            this.calculatorTabPage.Text = "Calculator";
            this.calculatorTabPage.UseVisualStyleBackColor = true;

            // 
            // calculator
            // 
            this.calculator.Location = new System.Drawing.Point(3, 3);
            this.calculator.Name = "calculator";
            this.calculator.Size = new System.Drawing.Size(434, 337);
            this.calculator.TabIndex = 132;

            // 
            // userTabPage
            // 
            this.userTabPage.Controls.Add(this.users);
            this.userTabPage.Location = new System.Drawing.Point(4, 22);
            this.userTabPage.Name = "userTabPage";
            this.userTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.userTabPage.Size = new System.Drawing.Size(1153, 381);
            this.userTabPage.TabIndex = 1;
            this.userTabPage.Text = "Members";
            this.userTabPage.UseVisualStyleBackColor = true;

            //
            // users
            // 
            this.users.Location = new System.Drawing.Point(3, 3);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(434, 337);
            this.users.TabIndex = 132;

            // 
            // marketTabPage
            // 
            this.marketTabPage.Controls.Add(this.market);
            this.marketTabPage.Location = new System.Drawing.Point(4, 22);
            this.marketTabPage.Name = "marketTabPage";
            this.marketTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.marketTabPage.Size = new System.Drawing.Size(1153, 381);
            this.marketTabPage.TabIndex = 2;
            this.marketTabPage.Text = "Market";
            this.marketTabPage.UseVisualStyleBackColor = true;

            //
            // market
            // 
            this.market.Location = new System.Drawing.Point(3, 3);
            this.market.Name = "market";
            this.market.Size = new System.Drawing.Size(434, 337);
            this.market.TabIndex = 132;

            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 426);
            this.Controls.Add(this.tabContainer);
            this.Name = "MainInterface";
            this.Text = "Custom Value Calculator";

            this.tabContainer.ResumeLayout(false);
            this.calculatorTabPage.ResumeLayout(false);
            this.marketTabPage.ResumeLayout(false);
            this.userTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage calculatorTabPage;
        private System.Windows.Forms.TabPage userTabPage;
        private System.Windows.Forms.TabPage marketTabPage;

        private CalculatorContainer calculator;
        private MarketContainer market;
        private UserContainer users;
    }
}

