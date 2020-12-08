namespace Aruru.AruruForm
{
    partial class Config
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.BakenDBDirBrowseButton = new System.Windows.Forms.Button();
            this.BakenDBDirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BakenDBDirBrowseButton
            // 
            this.BakenDBDirBrowseButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BakenDBDirBrowseButton.Location = new System.Drawing.Point(464, 35);
            this.BakenDBDirBrowseButton.Name = "BakenDBDirBrowseButton";
            this.BakenDBDirBrowseButton.Size = new System.Drawing.Size(75, 22);
            this.BakenDBDirBrowseButton.TabIndex = 6;
            this.BakenDBDirBrowseButton.Text = "参照";
            this.BakenDBDirBrowseButton.UseVisualStyleBackColor = true;
            this.BakenDBDirBrowseButton.Click += new System.EventHandler(this.BakenDBDirBrowseButton_Click);
            // 
            // BakenDBDirTextBox
            // 
            this.BakenDBDirTextBox.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BakenDBDirTextBox.Location = new System.Drawing.Point(17, 37);
            this.BakenDBDirTextBox.Name = "BakenDBDirTextBox";
            this.BakenDBDirTextBox.ReadOnly = true;
            this.BakenDBDirTextBox.Size = new System.Drawing.Size(441, 25);
            this.BakenDBDirTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "馬券結果保存フォルダ";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BakenDBDirBrowseButton);
            this.Controls.Add(this.BakenDBDirTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Config";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BakenDBDirBrowseButton;
        private System.Windows.Forms.TextBox BakenDBDirTextBox;
        private System.Windows.Forms.Label label1;
    }
}
