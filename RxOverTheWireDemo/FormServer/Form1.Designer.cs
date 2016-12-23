namespace FormServer
{
    partial class Form1
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
            this.btnSendItemToClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendItemToClient
            // 
            this.btnSendItemToClient.Location = new System.Drawing.Point(282, 147);
            this.btnSendItemToClient.Name = "btnSendItemToClient";
            this.btnSendItemToClient.Size = new System.Drawing.Size(334, 47);
            this.btnSendItemToClient.TabIndex = 0;
            this.btnSendItemToClient.Text = "Send Item To Client";
            this.btnSendItemToClient.UseVisualStyleBackColor = true;
            this.btnSendItemToClient.Click += new System.EventHandler(this.btnSendItemToClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 465);
            this.Controls.Add(this.btnSendItemToClient);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendItemToClient;
    }
}

