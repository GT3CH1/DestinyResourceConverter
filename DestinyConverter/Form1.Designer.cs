namespace DestinyConverter
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
            this.resourceSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.itemInfoGroup = new System.Windows.Forms.GroupBox();
            this.manufacturerText = new System.Windows.Forms.TextBox();
            this.manuLabel = new System.Windows.Forms.Label();
            this.locationText = new System.Windows.Forms.TextBox();
            this.priceText = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.csvModification = new System.Windows.Forms.GroupBox();
            this.additionalOptionsList = new System.Windows.Forms.CheckedListBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.poText = new System.Windows.Forms.TextBox();
            this.poLabel = new System.Windows.Forms.Label();
            this.optionList = new System.Windows.Forms.CheckedListBox();
            this.selectedFileText = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.fileBrowse = new System.Windows.Forms.Button();
            this.itemInfoGroup.SuspendLayout();
            this.csvModification.SuspendLayout();
            this.SuspendLayout();
            // 
            // resourceSelection
            // 
            this.resourceSelection.FormattingEnabled = true;
            this.resourceSelection.Location = new System.Drawing.Point(112, 13);
            this.resourceSelection.Name = "resourceSelection";
            this.resourceSelection.Size = new System.Drawing.Size(302, 21);
            this.resourceSelection.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resource Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceLabel
            // 
            this.priceLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.priceLabel.Location = new System.Drawing.Point(6, 44);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(35, 16);
            this.priceLabel.TabIndex = 3;
            this.priceLabel.Text = "Price";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // itemInfoGroup
            // 
            this.itemInfoGroup.Controls.Add(this.manufacturerText);
            this.itemInfoGroup.Controls.Add(this.manuLabel);
            this.itemInfoGroup.Controls.Add(this.locationText);
            this.itemInfoGroup.Controls.Add(this.priceText);
            this.itemInfoGroup.Controls.Add(this.locationLabel);
            this.itemInfoGroup.Controls.Add(this.label1);
            this.itemInfoGroup.Controls.Add(this.priceLabel);
            this.itemInfoGroup.Controls.Add(this.resourceSelection);
            this.itemInfoGroup.Location = new System.Drawing.Point(12, 12);
            this.itemInfoGroup.Name = "itemInfoGroup";
            this.itemInfoGroup.Size = new System.Drawing.Size(427, 124);
            this.itemInfoGroup.TabIndex = 4;
            this.itemInfoGroup.TabStop = false;
            this.itemInfoGroup.Text = "Resource Selection";
            // 
            // manufacturerText
            // 
            this.manufacturerText.Location = new System.Drawing.Point(112, 92);
            this.manufacturerText.Name = "manufacturerText";
            this.manufacturerText.ReadOnly = true;
            this.manufacturerText.Size = new System.Drawing.Size(302, 20);
            this.manufacturerText.TabIndex = 8;
            // 
            // manuLabel
            // 
            this.manuLabel.Location = new System.Drawing.Point(6, 96);
            this.manuLabel.Name = "manuLabel";
            this.manuLabel.Size = new System.Drawing.Size(100, 11);
            this.manuLabel.TabIndex = 7;
            this.manuLabel.Text = "Manufacturer";
            this.manuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locationText
            // 
            this.locationText.Location = new System.Drawing.Point(112, 66);
            this.locationText.Name = "locationText";
            this.locationText.ReadOnly = true;
            this.locationText.Size = new System.Drawing.Size(302, 20);
            this.locationText.TabIndex = 6;
            // 
            // priceText
            // 
            this.priceText.Location = new System.Drawing.Point(112, 40);
            this.priceText.Name = "priceText";
            this.priceText.ReadOnly = true;
            this.priceText.Size = new System.Drawing.Size(302, 20);
            this.priceText.TabIndex = 5;
            // 
            // locationLabel
            // 
            this.locationLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.locationLabel.Location = new System.Drawing.Point(6, 70);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(100, 11);
            this.locationLabel.TabIndex = 4;
            this.locationLabel.Text = "Location";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // csvModification
            // 
            this.csvModification.Controls.Add(this.additionalOptionsList);
            this.csvModification.Controls.Add(this.convertButton);
            this.csvModification.Controls.Add(this.poText);
            this.csvModification.Controls.Add(this.poLabel);
            this.csvModification.Controls.Add(this.optionList);
            this.csvModification.Controls.Add(this.selectedFileText);
            this.csvModification.Controls.Add(this.filePathLabel);
            this.csvModification.Controls.Add(this.fileBrowse);
            this.csvModification.Location = new System.Drawing.Point(12, 142);
            this.csvModification.Name = "csvModification";
            this.csvModification.Size = new System.Drawing.Size(427, 177);
            this.csvModification.TabIndex = 5;
            this.csvModification.TabStop = false;
            this.csvModification.Text = "Options";
            // 
            // additionalOptionsList
            // 
            this.additionalOptionsList.Enabled = false;
            this.additionalOptionsList.FormattingEnabled = true;
            this.additionalOptionsList.Items.AddRange(new object[] {"Add MAC comment"});
            this.additionalOptionsList.Location = new System.Drawing.Point(286, 47);
            this.additionalOptionsList.Name = "additionalOptionsList";
            this.additionalOptionsList.Size = new System.Drawing.Size(128, 34);
            this.additionalOptionsList.TabIndex = 7;
            // 
            // convertButton
            // 
            this.convertButton.Enabled = false;
            this.convertButton.Location = new System.Drawing.Point(6, 147);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(408, 23);
            this.convertButton.TabIndex = 6;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            // 
            // poText
            // 
            this.poText.Enabled = false;
            this.poText.Location = new System.Drawing.Point(87, 48);
            this.poText.Name = "poText";
            this.poText.Size = new System.Drawing.Size(75, 20);
            this.poText.TabIndex = 5;
            // 
            // poLabel
            // 
            this.poLabel.Location = new System.Drawing.Point(0, 45);
            this.poLabel.Name = "poLabel";
            this.poLabel.Size = new System.Drawing.Size(86, 23);
            this.poLabel.TabIndex = 4;
            this.poLabel.Text = "Purchase Order";
            this.poLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // optionList
            // 
            this.optionList.Enabled = false;
            this.optionList.FormattingEnabled = true;
            this.optionList.Items.AddRange(new object[] {"District ID as MAC", "District ID as SN"});
            this.optionList.Location = new System.Drawing.Point(168, 47);
            this.optionList.Name = "optionList";
            this.optionList.Size = new System.Drawing.Size(112, 34);
            this.optionList.TabIndex = 3;
            // 
            // selectedFileText
            // 
            this.selectedFileText.Location = new System.Drawing.Point(168, 19);
            this.selectedFileText.Name = "selectedFileText";
            this.selectedFileText.ReadOnly = true;
            this.selectedFileText.Size = new System.Drawing.Size(246, 20);
            this.selectedFileText.TabIndex = 2;
            // 
            // filePathLabel
            // 
            this.filePathLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathLabel.Location = new System.Drawing.Point(87, 18);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(75, 0);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "Selected File:";
            this.filePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileBrowse
            // 
            this.fileBrowse.Location = new System.Drawing.Point(6, 19);
            this.fileBrowse.Name = "fileBrowse";
            this.fileBrowse.Size = new System.Drawing.Size(75, 23);
            this.fileBrowse.TabIndex = 0;
            this.fileBrowse.Text = "Browse...";
            this.fileBrowse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(463, 324);
            this.Controls.Add(this.csvModification);
            this.Controls.Add(this.itemInfoGroup);
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.itemInfoGroup.ResumeLayout(false);
            this.itemInfoGroup.PerformLayout();
            this.csvModification.ResumeLayout(false);
            this.csvModification.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckedListBox additionalOptionsList;

        private System.Windows.Forms.Button convertButton;

        private System.Windows.Forms.Label poLabel;
        private System.Windows.Forms.TextBox poText;

        private System.Windows.Forms.CheckedListBox optionList;

        private System.Windows.Forms.TextBox selectedFileText;

        private System.Windows.Forms.Label filePathLabel;

        private System.Windows.Forms.Button fileBrowse;

        private System.Windows.Forms.GroupBox csvModification;

        private System.Windows.Forms.TextBox manufacturerText;
        private System.Windows.Forms.Label manuLabel;

        private System.Windows.Forms.GroupBox itemInfoGroup;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox priceText;
        private System.Windows.Forms.TextBox locationText;

        private System.Windows.Forms.Label priceLabel;

        private System.Windows.Forms.ComboBox resourceSelection;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}