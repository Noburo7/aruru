namespace Aruru.AruruForm
{
    partial class BakenInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BakenInfoForm));
            this.BakenInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BakenInfoLabel
            // 
            this.BakenInfoLabel.AutoSize = true;
            this.BakenInfoLabel.Location = new System.Drawing.Point(9, 9);
            this.BakenInfoLabel.Name = "BakenInfoLabel";
            this.BakenInfoLabel.Size = new System.Drawing.Size(41, 15);
            this.BakenInfoLabel.TabIndex = 1;
            this.BakenInfoLabel.Text = "label1";
            // 
            // BakenInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 480);
            this.Controls.Add(this.BakenInfoLabel);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "BakenInfoForm";
            this.Text = "馬券情報";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BakenInfoLabel;
    }
}