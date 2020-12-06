namespace Aruru.AruruForm
{
    partial class MenuForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.BakenMenuButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HorseSearchButton = new System.Windows.Forms.Button();
            this.RapAnalysisButton = new System.Windows.Forms.Button();
            this.SettingButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BakenMenuButton
            // 
            this.BakenMenuButton.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BakenMenuButton.Location = new System.Drawing.Point(0, 0);
            this.BakenMenuButton.Name = "BakenMenuButton";
            this.BakenMenuButton.Size = new System.Drawing.Size(192, 50);
            this.BakenMenuButton.TabIndex = 0;
            this.BakenMenuButton.Text = "馬券成績管理";
            this.BakenMenuButton.UseVisualStyleBackColor = true;
            this.BakenMenuButton.Click += new System.EventHandler(this.BakenMenuButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Location = new System.Drawing.Point(0, 570);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(105, 30);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "終了";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HorseSearchButton
            // 
            this.HorseSearchButton.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HorseSearchButton.Location = new System.Drawing.Point(0, 100);
            this.HorseSearchButton.Name = "HorseSearchButton";
            this.HorseSearchButton.Size = new System.Drawing.Size(192, 50);
            this.HorseSearchButton.TabIndex = 2;
            this.HorseSearchButton.Text = "競走馬検索";
            this.HorseSearchButton.UseVisualStyleBackColor = true;
            // 
            // RapAnalysisButton
            // 
            this.RapAnalysisButton.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RapAnalysisButton.Location = new System.Drawing.Point(0, 50);
            this.RapAnalysisButton.Name = "RapAnalysisButton";
            this.RapAnalysisButton.Size = new System.Drawing.Size(192, 50);
            this.RapAnalysisButton.TabIndex = 1;
            this.RapAnalysisButton.Text = "ハロンラップ解析";
            this.RapAnalysisButton.UseVisualStyleBackColor = true;
            // 
            // SettingButton
            // 
            this.SettingButton.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SettingButton.Location = new System.Drawing.Point(0, 150);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(192, 50);
            this.SettingButton.TabIndex = 3;
            this.SettingButton.Text = "設定";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(192, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 600);
            this.MainPanel.TabIndex = 5;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(994, 601);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.BakenMenuButton);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.HorseSearchButton);
            this.Controls.Add(this.RapAnalysisButton);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MenuForm";
            this.Text = "Aruru ver 0.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BakenMenuButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button HorseSearchButton;
        private System.Windows.Forms.Button RapAnalysisButton;
        private System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.Panel MainPanel;
    }
}

