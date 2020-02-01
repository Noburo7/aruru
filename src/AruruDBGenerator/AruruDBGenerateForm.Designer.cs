﻿namespace AruruDB
{
    partial class AruruDBGenerateForm
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
            this.CreateTablesButton = new System.Windows.Forms.Button();
            this.ProgressListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DBFileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateTablesButton
            // 
            this.CreateTablesButton.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CreateTablesButton.Location = new System.Drawing.Point(259, 16);
            this.CreateTablesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateTablesButton.Name = "CreateTablesButton";
            this.CreateTablesButton.Size = new System.Drawing.Size(105, 29);
            this.CreateTablesButton.TabIndex = 0;
            this.CreateTablesButton.Text = "テーブル作成";
            this.CreateTablesButton.UseVisualStyleBackColor = true;
            this.CreateTablesButton.Click += new System.EventHandler(this.CreateTablesButton_Click);
            // 
            // ProgressListBox
            // 
            this.ProgressListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressListBox.FormattingEnabled = true;
            this.ProgressListBox.HorizontalScrollbar = true;
            this.ProgressListBox.ItemHeight = 15;
            this.ProgressListBox.Location = new System.Drawing.Point(12, 49);
            this.ProgressListBox.Name = "ProgressListBox";
            this.ProgressListBox.Size = new System.Drawing.Size(488, 184);
            this.ProgressListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = ".sqlite";
            // 
            // DBFileNameTextBox
            // 
            this.DBFileNameTextBox.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DBFileNameTextBox.Location = new System.Drawing.Point(84, 16);
            this.DBFileNameTextBox.Name = "DBFileNameTextBox";
            this.DBFileNameTextBox.Size = new System.Drawing.Size(115, 27);
            this.DBFileNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "ファイル名";
            // 
            // AruruDBGenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 243);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DBFileNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressListBox);
            this.Controls.Add(this.CreateTablesButton);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AruruDBGenerateForm";
            this.Text = "Aruru DB Generator";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateTablesButton;
        private System.Windows.Forms.ListBox ProgressListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DBFileNameTextBox;
        private System.Windows.Forms.Label label2;
    }
}

