namespace Aruru.AruruForm
{
    partial class BakenMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BakenMenuForm));
            this.BakenListView = new System.Windows.Forms.ListView();
            this.NewRegistButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BakenListView
            // 
            this.BakenListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BakenListView.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BakenListView.HideSelection = false;
            this.BakenListView.Location = new System.Drawing.Point(14, 15);
            this.BakenListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BakenListView.Name = "BakenListView";
            this.BakenListView.Size = new System.Drawing.Size(803, 449);
            this.BakenListView.TabIndex = 0;
            this.BakenListView.UseCompatibleStateImageBehavior = false;
            this.BakenListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BakenListView_MouseDoubleClick);
            // 
            // NewRegistButton
            // 
            this.NewRegistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewRegistButton.Location = new System.Drawing.Point(135, 472);
            this.NewRegistButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewRegistButton.Name = "NewRegistButton";
            this.NewRegistButton.Size = new System.Drawing.Size(115, 29);
            this.NewRegistButton.TabIndex = 1;
            this.NewRegistButton.Text = "新規馬券登録";
            this.NewRegistButton.UseVisualStyleBackColor = true;
            this.NewRegistButton.Click += new System.EventHandler(this.NewRegistButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(14, 472);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(115, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // BakenMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 507);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.NewRegistButton);
            this.Controls.Add(this.BakenListView);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BakenMenuForm";
            this.Text = "Aruru 馬券成績管理";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView BakenListView;
        private System.Windows.Forms.Button NewRegistButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}