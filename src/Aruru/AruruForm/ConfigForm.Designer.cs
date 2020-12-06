namespace Aruru.AruruForm
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BakenDBDirTextBox = new System.Windows.Forms.TextBox();
            this.BakenDBDirBrowseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "馬券結果保存フォルダ";
            // 
            // BakenDBDirTextBox
            // 
            this.BakenDBDirTextBox.Location = new System.Drawing.Point(16, 32);
            this.BakenDBDirTextBox.Name = "BakenDBDirTextBox";
            this.BakenDBDirTextBox.Size = new System.Drawing.Size(441, 23);
            this.BakenDBDirTextBox.TabIndex = 1;
            // 
            // BakenDBDirBrowseButton
            // 
            this.BakenDBDirBrowseButton.Location = new System.Drawing.Point(464, 32);
            this.BakenDBDirBrowseButton.Name = "BakenDBDirBrowseButton";
            this.BakenDBDirBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BakenDBDirBrowseButton.TabIndex = 2;
            this.BakenDBDirBrowseButton.Text = "参照";
            this.BakenDBDirBrowseButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(436, 173);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(104, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "保存して閉じる";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 208);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BakenDBDirBrowseButton);
            this.Controls.Add(this.BakenDBDirTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigForm";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BakenDBDirTextBox;
        private System.Windows.Forms.Button BakenDBDirBrowseButton;
        private System.Windows.Forms.Button SaveButton;
    }
}