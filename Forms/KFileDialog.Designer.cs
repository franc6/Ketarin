namespace Ketarin.Forms
{
    partial class KFileDialog
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
            this.cancel = new System.Windows.Forms.Button();
            this.fileListView = new System.Windows.Forms.ListView();
            this.ok = new System.Windows.Forms.Button();
            this.lookIn = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.extensions = new System.Windows.Forms.ComboBox();
            this.fileName = new System.Windows.Forms.ComboBox();
            this.mountList = new System.Windows.Forms.ListBox();
            this.viewButton = new wyDay.Controls.SplitButton();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileTypeLabel = new System.Windows.Forms.Label();
	    this.viewMenu = new System.Windows.Forms.ContextMenu();
	    this.viewLargeIcon = new System.Windows.Forms.MenuItem();
	    this.viewSmallIcon = new System.Windows.Forms.MenuItem();
	    this.viewList = new System.Windows.Forms.MenuItem();
	    this.viewDetails = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(431, 313);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
	    this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // fileListView
            // 
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(110, 41);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(399, 239);
	    this.fileListView.MultiSelect = false;
            this.fileListView.TabIndex = 7;
            this.fileListView.UseCompatibleStateImageBehavior = false;
	    this.fileListView.ItemActivate += new System.EventHandler(this.fileListView_ItemActivate);
	    this.fileListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.fileListView_ItemSelectionChanged);
	    this.fileListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.fileListView_ColumnClick);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(431, 284);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "Save";
            this.ok.UseVisualStyleBackColor = true;
	    this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // lookIn
            // 
	    this.lookIn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
	    this.lookIn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	    this.lookIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lookIn.FormattingEnabled = true;
            this.lookIn.Location = new System.Drawing.Point(110, 14);
            this.lookIn.Name = "lookIn";
            this.lookIn.Size = new System.Drawing.Size(302, 21);
            this.lookIn.TabIndex = 5;
            this.lookIn.SelectedIndexChanged += new System.EventHandler(lookIn_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.Image = global::Ketarin.Properties.Resources.Restart;
            this.refresh.Location = new System.Drawing.Point(474, 12);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(32, 23);
            this.refresh.TabIndex = 6;
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Look in:";
            // 
            // extensions
            // 
	    this.extensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extensions.FormattingEnabled = true;
            this.extensions.Location = new System.Drawing.Point(182, 315);
            this.extensions.Name = "extensions";
            this.extensions.Size = new System.Drawing.Size(243, 21);
            this.extensions.TabIndex = 1;
            this.extensions.SelectedIndexChanged += new System.EventHandler(extensions_SelectedIndexChanged);
            // 
            // fileName
            // 
	    //this.fileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
	    //this.fileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
	    this.fileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
	    this.fileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
	    this.fileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.fileName.Location = new System.Drawing.Point(182, 286);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(243, 20);
            this.fileName.TabIndex = 0;
            this.fileName.SelectedIndexChanged += new System.EventHandler(fileName_SelectedIndexChanged);
	    this.fileName.KeyDown += new System.Windows.Forms.KeyEventHandler(fileName_KeyDown);
            // 
            // mountList
            // 
            this.mountList.FormattingEnabled = true;
            this.mountList.Location = new System.Drawing.Point(12, 38);
            this.mountList.Name = "mountList";
            this.mountList.Size = new System.Drawing.Size(92, 290);
            this.mountList.TabIndex = 8;
	    this.mountList.SelectedIndexChanged += new System.EventHandler(this.mountList_SelectedIndexChanged);
            // 
            // viewButton
            // 
            this.viewButton.Image = global::Ketarin.Properties.Resources.Symbol_Check;
            this.viewButton.Location = new System.Drawing.Point(436, 12);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(32, 23);
            this.viewButton.TabIndex = 9;
            this.viewButton.UseVisualStyleBackColor = true;
	    this.viewButton.SplitMenu = this.viewMenu;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(110, 289);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(55, 13);
            this.fileNameLabel.TabIndex = 10;
            this.fileNameLabel.Text = "File name:";
            // 
            // fileTypeLabel
            // 
            this.fileTypeLabel.AutoSize = true;
            this.fileTypeLabel.Location = new System.Drawing.Point(110, 318);
            this.fileTypeLabel.Name = "fileTypeLabel";
            this.fileTypeLabel.Size = new System.Drawing.Size(66, 13);
            this.fileTypeLabel.TabIndex = 11;
            this.fileTypeLabel.Text = "Files of type:";
	    //
	    // viewMenu
	    // 
	    this.viewMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
		this.viewLargeIcon,
		this.viewSmallIcon,
		this.viewList,
		this.viewDetails
	    });
	    //
	    // viewLargeIcon
	    // 
	    this.viewLargeIcon.Index = 0;
	    this.viewLargeIcon.Text = "Large Icons";
	    this.viewLargeIcon.Click += new System.EventHandler(this.viewLargeIcon_Click);
	    //
	    // viewSmallIcon
	    // 
	    this.viewSmallIcon.Index = 0;
	    this.viewSmallIcon.Text = "Small Icons";
	    this.viewSmallIcon.Click += new System.EventHandler(this.viewSmallIcon_Click);
	    //
	    // viewList
	    // 
	    this.viewList.Index = 0;
	    this.viewList.Text = "List";
	    this.viewList.Click += new System.EventHandler(this.viewList_Click);
	    //
	    // viewDetails
	    // 
	    this.viewDetails.Index = 0;
	    this.viewDetails.Text = "Details";
	    this.viewDetails.Click += new System.EventHandler(this.viewDetails_Click);
            // 
            // KFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 348);
            this.Controls.Add(this.fileTypeLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.mountList);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.extensions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.lookIn);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.cancel);
            this.Name = "KFileDialog";
            this.Text = "KFileDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ComboBox lookIn;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox extensions;
        private System.Windows.Forms.ComboBox fileName;
        private System.Windows.Forms.ListBox mountList;
        private wyDay.Controls.SplitButton viewButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label fileTypeLabel;
	private System.Windows.Forms.ContextMenu viewMenu;
	private System.Windows.Forms.MenuItem viewLargeIcon;
	private System.Windows.Forms.MenuItem viewSmallIcon;
	private System.Windows.Forms.MenuItem viewList;
	private System.Windows.Forms.MenuItem viewDetails;
	private bool inLoadFileList;
    }
}
