namespace Panhandler.UserTab
{
    partial class UserContainer
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
            this.userPanel = new System.Windows.Forms.Panel();
            this.userCodeLabel = new System.Windows.Forms.Label();
            this.userCodeBox = new System.Windows.Forms.TextBox();
            this.updateUserButton = new System.Windows.Forms.Button();
            this.userList = new System.Windows.Forms.ListView();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.userMultiplierLabel = new System.Windows.Forms.Label();
            this.playerMultiplierBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.userPanel.SuspendLayout();
            this.SuspendLayout();

            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.userCodeLabel);
            this.userPanel.Controls.Add(this.userCodeBox);
            this.userPanel.Controls.Add(this.updateUserButton);
            this.userPanel.Controls.Add(this.userList);
            this.userPanel.Controls.Add(this.removeUserButton);
            this.userPanel.Controls.Add(this.userMultiplierLabel);
            this.userPanel.Controls.Add(this.playerMultiplierBox);
            this.userPanel.Controls.Add(this.userNameLabel);
            this.userPanel.Controls.Add(this.userNameBox);
            this.userPanel.Controls.Add(this.addUserButton);
            this.userPanel.Location = new System.Drawing.Point(3, 3);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(460, 365);
            this.userPanel.TabIndex = 1;
            // 
            // userCodeLabel
            // 
            this.userCodeLabel.AutoSize = true;
            this.userCodeLabel.Location = new System.Drawing.Point(227, 23);
            this.userCodeLabel.Name = "userCodeLabel";
            this.userCodeLabel.Size = new System.Drawing.Size(57, 13);
            this.userCodeLabel.TabIndex = 10;
            this.userCodeLabel.Text = "User Code";
            // 
            // userCodeBox
            // 
            this.userCodeBox.Location = new System.Drawing.Point(230, 42);
            this.userCodeBox.Name = "userCodeBox";
            this.userCodeBox.Size = new System.Drawing.Size(219, 20);
            this.userCodeBox.TabIndex = 9;
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(11, 102);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(438, 238);
            this.userList.TabIndex = 7;

            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(124, 73);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 1;
            this.addUserButton.Text = "Add";
            this.addUserButton.UseVisualStyleBackColor = true;
            // 
            // updateUserButton
            // 
            this.updateUserButton.Location = new System.Drawing.Point(286, 73);
            this.updateUserButton.Name = "updateUserButton";
            this.updateUserButton.Size = new System.Drawing.Size(75, 23);
            this.updateUserButton.TabIndex = 8;
            this.updateUserButton.Text = "Update";
            this.updateUserButton.UseVisualStyleBackColor = true;
            // 
            // removeUserButton
            // 
            this.removeUserButton.Location = new System.Drawing.Point(205, 73);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(75, 23);
            this.removeUserButton.TabIndex = 6;
            this.removeUserButton.Text = "Remove";
            this.removeUserButton.UseVisualStyleBackColor = true;

            // 
            // userMultiplierLabel
            // 
            this.userMultiplierLabel.AutoSize = true;
            this.userMultiplierLabel.Location = new System.Drawing.Point(121, 23);
            this.userMultiplierLabel.Name = "userMultiplierLabel";
            this.userMultiplierLabel.Size = new System.Drawing.Size(48, 13);
            this.userMultiplierLabel.TabIndex = 5;
            this.userMultiplierLabel.Text = "Multiplier";
            // 
            // playerMultiplierBox
            // 
            this.playerMultiplierBox.Location = new System.Drawing.Point(124, 42);
            this.playerMultiplierBox.Name = "playerMultiplierBox";
            this.playerMultiplierBox.Size = new System.Drawing.Size(100, 20);
            this.playerMultiplierBox.TabIndex = 4;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(18, 23);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(67, 13);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "User Name";
            // 
            // userNameBox
            // 
            this.userNameBox.Location = new System.Drawing.Point(18, 42);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(100, 20);
            this.userNameBox.TabIndex = 2;

            // 
            // ContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userPanel);
            this.Name = "ContainerControl";
            this.Size = new System.Drawing.Size(468, 374);
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label userCodeLabel;
        private System.Windows.Forms.TextBox userCodeBox;
        private System.Windows.Forms.Button updateUserButton;
        private System.Windows.Forms.ListView userList;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Label userMultiplierLabel;
        private System.Windows.Forms.TextBox playerMultiplierBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Button addUserButton;
    }
}
