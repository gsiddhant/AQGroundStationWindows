namespace AgroQuad
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Connection_ListBox = new System.Windows.Forms.ListBox();
            this.Quad_SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attempting to Communicate with the Device";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(44, 56);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(534, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Connection_ListBox
            // 
            this.Connection_ListBox.FormattingEnabled = true;
            this.Connection_ListBox.Location = new System.Drawing.Point(44, 129);
            this.Connection_ListBox.Name = "Connection_ListBox";
            this.Connection_ListBox.Size = new System.Drawing.Size(534, 95);
            this.Connection_ListBox.TabIndex = 2;
            this.Connection_ListBox.Tag = "Connected";
            this.Connection_ListBox.SelectedIndexChanged += new System.EventHandler(this.Connection_ListBox_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 248);
            this.Controls.Add(this.Connection_ListBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Tag = "";
            this.Text = "Connecting to Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox Connection_ListBox;
        private System.IO.Ports.SerialPort Quad_SerialPort;
    }
}