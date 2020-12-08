namespace Aruru.AruruForm
{
    partial class BakenMenu
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.NewRegistButton = new System.Windows.Forms.Button();
            this.BakenListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(0, 566);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(134, 34);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // NewRegistButton
            // 
            this.NewRegistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewRegistButton.Location = new System.Drawing.Point(139, 566);
            this.NewRegistButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.NewRegistButton.Name = "NewRegistButton";
            this.NewRegistButton.Size = new System.Drawing.Size(134, 34);
            this.NewRegistButton.TabIndex = 4;
            this.NewRegistButton.Text = "新規馬券登録";
            this.NewRegistButton.UseVisualStyleBackColor = true;
            this.NewRegistButton.Click += new System.EventHandler(this.NewRegistButton_Click);
            // 
            // BakenListView
            // 
            this.BakenListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BakenListView.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BakenListView.HideSelection = false;
            this.BakenListView.Location = new System.Drawing.Point(0, 0);
            this.BakenListView.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.BakenListView.Name = "BakenListView";
            this.BakenListView.Size = new System.Drawing.Size(800, 562);
            this.BakenListView.TabIndex = 3;
            this.BakenListView.UseCompatibleStateImageBehavior = false;
            this.BakenListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BakenListView_MouseDoubleClick);
            // 
            // BakenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.NewRegistButton);
            this.Controls.Add(this.BakenListView);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BakenMenu";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Click += new System.EventHandler(this.NewRegistButton_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button NewRegistButton;
        private System.Windows.Forms.ListView BakenListView;
    }
}
