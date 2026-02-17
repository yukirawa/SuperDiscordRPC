namespace SuperDiscordRPC.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.Timer rpcTimer;
            chkEnableRPC = new CheckBox();
            chkSyncMobile = new CheckBox();
            lblStatus = new Label();
            rpcTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // chkEnableRPC
            // 
            chkEnableRPC.AutoSize = true;
            chkEnableRPC.Location = new Point(12, 12);
            chkEnableRPC.Name = "chkEnableRPC";
            chkEnableRPC.Size = new Size(83, 19);
            chkEnableRPC.TabIndex = 0;
            chkEnableRPC.Tag = "";
            chkEnableRPC.Text = "RPC有効化";
            chkEnableRPC.UseVisualStyleBackColor = true;
            // 
            // chkSyncMobile
            // 
            chkSyncMobile.AutoSize = true;
            chkSyncMobile.Location = new Point(12, 37);
            chkSyncMobile.Name = "chkSyncMobile";
            chkSyncMobile.Size = new Size(87, 19);
            chkSyncMobile.TabIndex = 1;
            chkSyncMobile.Tag = "";
            chkSyncMobile.Text = "スマホと連携";
            chkSyncMobile.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 59);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(81, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: 待機中";
            // 
            // rpcTimer
            // 
            rpcTimer.Enabled = true;
            rpcTimer.Interval = 5000;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 107);
            Controls.Add(lblStatus);
            Controls.Add(chkSyncMobile);
            Controls.Add(chkEnableRPC);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkEnableRPC;
        private CheckBox chkSyncMobile;
        private Label lblStatus;
        private System.Windows.Forms.Timer rpcTimer;
    }
}
