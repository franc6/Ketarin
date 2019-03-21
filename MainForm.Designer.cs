namespace Ketarin
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imlStatus = new System.Windows.Forms.ImageList(this.components);
            this.cmnuJobs = new System.Windows.Forms.ContextMenuStrip();
            this.cmnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCheckForUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuForceDownload = new System.Windows.Forms.ToolStripMenuItem();
#if !MONO
            this.cmnuInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuUpdateInstall = new System.Windows.Forms.ToolStripMenuItem();
#endif
            this.cmnuCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRunPostDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
#if !MONO
            this.cmnuProperties = new System.Windows.Forms.ToolStripMenuItem();
#endif
            this.cmnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTutorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
#if !MONO
            this.cmnuUpdateAndInstall = new System.Windows.Forms.ToolStripMenuItem();
#endif
            this.cmuAdd = new System.Windows.Forms.ContextMenuStrip();
            this.cmnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuImportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuImportOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.olvJobs = new Ketarin.ApplicationJobsListView();
            this.colName = new CDBurnerXP.Controls.OLVColumn();
            this.colLastUpdate = new CDBurnerXP.Controls.OLVColumn();
            this.colProgress = new CDBurnerXP.Controls.OLVColumn();
            this.colTarget = new CDBurnerXP.Controls.OLVColumn();
            this.colCategory = new CDBurnerXP.Controls.OLVColumn();
            this.colStatus = new CDBurnerXP.Controls.OLVColumn();
#if !MONO
            this.m_VistaMenu = new CDBurnerXP.Controls.VistaMenu(this.components);
#endif
            this.cmuRun = new System.Windows.Forms.ContextMenuStrip();
            this.cmnuCheckAndDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuOnlyCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.ntiTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmnuTrayIconMenu = new System.Windows.Forms.ContextMenuStrip();
            this.cmnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tbSelectedApplications = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbNumByStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbTotalApplications = new System.Windows.Forms.ToolStripStatusLabel();
#if !MONO
            this.bInstall = new wyDay.Controls.SplitButton();
#endif
            this.bRun = new wyDay.Controls.SplitButton();
            this.bAddApplication = new wyDay.Controls.SplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.olvJobs)).BeginInit();
#if !MONO
            ((System.ComponentModel.ISupportInitialize)(this.m_VistaMenu)).BeginInit();
#endif
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // imlStatus
            // 
            this.imlStatus.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imlStatus.ImageSize = new System.Drawing.Size(16, 16);
            this.imlStatus.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmnuJobs
            // 
            this.cmnuJobs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuUpdate,
            this.cmnuCheckForUpdate,
            this.cmnuForceDownload,
#if !MONO
            new System.Windows.Forms.ToolStripSeparator(),
            this.cmnuInstall,
            this.cmnuUpdateInstall,
#endif
            new System.Windows.Forms.ToolStripSeparator(),
            this.cmnuCommands,
            new System.Windows.Forms.ToolStripSeparator(),
            this.cmnuOpenFile,
            this.cmnuOpenFolder,
#if !MONO
            this.cmnuProperties,
#endif
            this.cmnuRename,
            new System.Windows.Forms.ToolStripSeparator(),
            this.cmnuEdit,
            this.cmnuDelete,
            this.cmnuCopy,
            this.cmnuPaste,
            this.mnuSelectAll,
            this.mnuInvert});
            this.cmnuJobs.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuJobs_Popup);
            this.cmnuJobs.ShowCheckMargin = false;
            this.cmnuJobs.ShowImageMargin = false;
            // 
            // cmnuUpdate
            // 
#if !MONO
            this.m_VistaMenu.SetImage(this.cmnuUpdate, global::Ketarin.Properties.Resources.Restart);
#endif
            this.cmnuUpdate.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U;
            this.cmnuUpdate.Text = "&Update";
            this.cmnuUpdate.Click += new System.EventHandler(this.cmuUpdate_Click);
            // 
            // cmnuCheckForUpdate
            // 
            this.cmnuCheckForUpdate.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.U;
            this.cmnuCheckForUpdate.Text = "C&heck for update";
            this.cmnuCheckForUpdate.Click += new System.EventHandler(this.cmnuCheckForUpdate_Click);
            // 
            // cmnuForceDownload
            // 
            this.cmnuForceDownload.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5;
            this.cmnuForceDownload.Text = "&Force download";
            this.cmnuForceDownload.Click += new System.EventHandler(this.cmnuForceDownload_Click);
#if !MONO
            // 
            // cmnuInstall
            // 
            this.cmnuInstall.Text = "&Install";
            this.cmnuInstall.Click += new System.EventHandler(this.cmnuInstall_Click);
            // 
            // cmnuUpdateInstall
            // 
            this.cmnuUpdateInstall.Text = "Upda&te and install";
            this.cmnuUpdateInstall.Click += new System.EventHandler(this.cmnuUpdateInstall_Click);
#endif
            // 
            // cmnuCommands
            // 
            this.cmnuCommands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.cmnuRunPostDownload});
            this.cmnuCommands.Text = "Com&mands";
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.cmnuCommands.DropDown)).ShowImageMargin = false;
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.cmnuCommands.DropDown)).ShowCheckMargin = false;
            // 
            // cmnuRunPostDownload
            // 
            this.cmnuRunPostDownload.Text = "&Run post-download command";
            this.cmnuRunPostDownload.Click += new System.EventHandler(this.cmnuRunPostDownload_Click);
            // 
            // cmnuOpenFile
            // 
            this.cmnuOpenFile.Enabled = false;
            this.cmnuOpenFile.Text = "&Open file";
            this.cmnuOpenFile.Click += new System.EventHandler(this.cmnuOpenFile_Click);
            // 
            // cmnuOpenFolder
            // 
            this.cmnuOpenFolder.Text = "Ope&n folder";
            this.cmnuOpenFolder.Click += new System.EventHandler(this.cmnuOpenFolder_Click);
#if !MONO
            // 
            // cmnuProperties
            // 
            this.cmnuProperties.Enabled = false;
            this.cmnuProperties.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.cmnuProperties.Text = "File propertie&s";
            this.cmnuProperties.Click += new System.EventHandler(this.cmnuProperties_Click);
#endif
            // 
            // cmnuRename
            // 
            this.cmnuRename.Enabled = false;
            this.cmnuRename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.cmnuRename.Text = "&Rename file";
            this.cmnuRename.Click += new System.EventHandler(this.cmnuRename_Click);
            // 
            // cmnuEdit
            // 
            this.cmnuEdit.Font = new System.Drawing.Font(this.cmnuEdit.Font, System.Drawing.FontStyle.Bold);
            this.cmnuEdit.Enabled = false;
            this.cmnuEdit.Text = "&Edit";
            this.cmnuEdit.Click += new System.EventHandler(this.cmnuEdit_Click);
            // 
            // cmnuDelete
            // 
            this.cmnuDelete.Enabled = false;
            this.cmnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.cmnuDelete.Text = "&Delete";
            this.cmnuDelete.Click += new System.EventHandler(this.cmnuDelete_Click);
            // 
            // cmnuCopy
            // 
            this.cmnuCopy.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
            this.cmnuCopy.Text = "&Copy";
            this.cmnuCopy.Click += new System.EventHandler(this.cmnuCopy_Click);
            // 
            // cmnuPaste
            // 
            this.cmnuPaste.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P;
            this.cmnuPaste.Text = "&Paste";
            this.cmnuPaste.Click += new System.EventHandler(this.cmnuPaste_Click);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A;
            this.mnuSelectAll.Text = "Select &all";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuInvert
            // 
            this.mnuInvert.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I;
            this.mnuInvert.Text = "In&vert selection";
            this.mnuInvert.Click += new System.EventHandler(this.mnuInvert_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuHelp});
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuImport,
            this.mnuExportSelected,
            this.mnuExportAll,
            new System.Windows.Forms.ToolStripSeparator(),
            this.mnuSettings,
            new System.Windows.Forms.ToolStripSeparator(),
            this.mnuExit});
            this.mnuFile.Text = "&File";
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.mnuFile.DropDown)).ShowImageMargin = false;
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.mnuFile.DropDown)).ShowCheckMargin = false;
            // 
            // mnuNew
            // 
#if !MONO
            this.m_VistaMenu.SetImage(this.mnuNew, global::Ketarin.Properties.Resources.AddSmall);
#endif
            this.mnuNew.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            this.mnuNew.Text = "&New application...";
            this.mnuNew.Click += new System.EventHandler(this.mnuAddNew_Click);
            // 
            // mnuImport
            // 
            this.mnuImport.Text = "&Import...";
            this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
            // 
            // mnuExportSelected
            // 
            this.mnuExportSelected.Text = "E&xport selected...";
            this.mnuExportSelected.Click += new System.EventHandler(this.mnuExportSelected_Click);
            // 
            // mnuExportAll
            // 
            this.mnuExportAll.Text = "Export &all...";
            this.mnuExportAll.Click += new System.EventHandler(this.mnuExportAll_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T;
            this.mnuSettings.Text = "&Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.mnuLog,
            this.mnuShowGroups,
            this.mnuShowStatusBar,
            this.mnuAutoScroll,
            this.mnuFind});
            this.mnuView.Text = "&View";
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.mnuView.DropDown)).ShowImageMargin = false;
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.mnuView.DropDown)).ShowCheckMargin = true;
            // 
            // mnuLog
            // 
            this.mnuLog.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L;
            this.mnuLog.Text = "&Show log";
            this.mnuLog.Click += new System.EventHandler(this.mnuLog_Click);
            // 
            // mnuShowGroups
            // 
            this.mnuShowGroups.Checked = true;
            this.mnuShowGroups.Text = "Show gr&oups";
            this.mnuShowGroups.Click += new System.EventHandler(this.mnuShowGroups_Click);
            // 
            // mnuShowStatusBar
            // 
            this.mnuShowStatusBar.Text = "Show status &bar";
            this.mnuShowStatusBar.Click += new System.EventHandler(this.mnuShowStatusBar_Click);
            // 
            // mnuAutoScroll
            // 
            this.mnuAutoScroll.Checked = true;
            this.mnuAutoScroll.Text = "&Auto scroll";
            this.mnuAutoScroll.Click += new System.EventHandler(this.mnuAutoScroll_Click);
            // 
            // mnuFind
            // 
            this.mnuFind.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F;
            this.mnuFind.Text = "&Find";
            this.mnuFind.Click += new System.EventHandler(this.mnuFind_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.mnuTutorial,
            this.mnuAbout});
            this.mnuHelp.Text = "&Help";
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.mnuHelp.DropDown)).ShowImageMargin = false;
            ((System.Windows.Forms.ToolStripDropDownMenu)(this.mnuHelp.DropDown)).ShowCheckMargin = false;
            // 
            // mnuTutorial
            // 
            this.mnuTutorial.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuTutorial.Text = "&Tutorial";
            this.mnuTutorial.Click += new System.EventHandler(this.mnuTutorial_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
#if !MONO
            // 
            // cmnuUpdateAndInstall
            // 
            this.cmnuUpdateAndInstall.Text = "Update &all and install updates";
            this.cmnuUpdateAndInstall.Click += new System.EventHandler(this.cmnuUpdateAndInstall_Click);
#endif
            // 
            // cmuAdd
            // 
            this.cmuAdd.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.cmnuAdd,
            this.cmnuImportFile,
            this.cmnuImportOnline});
            this.cmuAdd.ShowCheckMargin = false;
            this.cmuAdd.ShowImageMargin = false;
            // 
            // cmnuAdd
            // 
            this.cmnuAdd.Text = "&New...";
            this.cmnuAdd.Click += new System.EventHandler(this.cmnuAdd_Click);
            // 
            // cmnuImportFile
            // 
            this.cmnuImportFile.Text = "Imp&ort from file...";
            this.cmnuImportFile.Click += new System.EventHandler(this.cmnuImport_Click);
            // 
            // cmnuImportOnline
            // 
            this.cmnuImportOnline.Text = "I&mport from online database...";
            this.cmnuImportOnline.Click += new System.EventHandler(this.cmnuImportOnline_Click);
            // 
            // olvJobs
            // 
            this.olvJobs.AllColumns.Add(this.colName);
            this.olvJobs.AllColumns.Add(this.colLastUpdate);
            this.olvJobs.AllColumns.Add(this.colProgress);
            this.olvJobs.AllColumns.Add(this.colTarget);
            this.olvJobs.AllColumns.Add(this.colCategory);
            this.olvJobs.AllColumns.Add(this.colStatus);
            this.olvJobs.AllowColumnReorder = true;
            this.olvJobs.AlternateRowBackColor = System.Drawing.Color.Empty;
            this.olvJobs.AlwaysGroupByColumn = null;
            this.olvJobs.AlwaysGroupBySortOrder = System.Windows.Forms.SortOrder.None;
            this.olvJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.olvJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colLastUpdate,
            this.colProgress,
            this.colTarget,
            this.colCategory});
            this.olvJobs.FullRowSelect = true;
            this.olvJobs.HideSelection = false;
            this.olvJobs.HighlightBackgroundColor = System.Drawing.Color.Empty;
            this.olvJobs.HighlightForegroundColor = System.Drawing.Color.Empty;
            this.olvJobs.LastSortColumn = null;
            this.olvJobs.LastSortOrder = System.Windows.Forms.SortOrder.None;
            this.olvJobs.Location = new System.Drawing.Point(12, 32);
            this.olvJobs.Name = "olvJobs";
            this.olvJobs.OwnerDraw = true;
            this.olvJobs.Size = new System.Drawing.Size(658, 262);
            this.olvJobs.SmallImageList = this.imlStatus;
            this.olvJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.olvJobs.TabIndex = 0;
            this.olvJobs.UseCompatibleStateImageBehavior = false;
            this.olvJobs.View = System.Windows.Forms.View.Details;
            this.olvJobs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.olvJobs_KeyDown);
            this.olvJobs.SelectionChanged += new System.EventHandler(this.olvJobs_SelectionChanged);
            this.olvJobs.SelectedIndexChanged += new System.EventHandler(this.olvJobs_SelectedIndexChanged);
            this.olvJobs.DoubleClick += new System.EventHandler(this.olvJobs_DoubleClick);
            // 
            // colName
            // 
            this.colName.AspectName = null;
            this.colName.Text = "Application";
            this.colName.Width = 183;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.AspectName = null;
            this.colLastUpdate.Text = "Last updated";
            this.colLastUpdate.Width = 110;
            // 
            // colProgress
            // 
            this.colProgress.AspectName = null;
            this.colProgress.MaximumWidth = 100;
            this.colProgress.MinimumWidth = 100;
            this.colProgress.Text = "Progress";
            this.colProgress.Width = 100;
            // 
            // colTarget
            // 
            this.colTarget.AspectName = null;
            this.colTarget.FillsFreeSpace = true;
            this.colTarget.Text = "Target";
            // 
            // colCategory
            // 
            this.colCategory.AspectName = "Category";
            this.colCategory.Text = "Category";
            this.colCategory.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.AspectName = null;
            this.colStatus.IsVisible = false;
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;
#if !MONO
            // 
            // m_VistaMenu
            // 
            this.m_VistaMenu.ContainerControl = this;
#endif
            // 
            // cmuRun
            // 
            this.cmuRun.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.cmnuCheckAndDownload,
            this.cmnuOnlyCheck
#if !MONO
            , this.cmnuUpdateAndInstall
#endif
            });
            this.cmuRun.ShowImageMargin = false;
            this.cmuRun.ShowCheckMargin = false;
            // 
            // cmnuCheckAndDownload
            // 
            this.cmnuCheckAndDownload.Text = "&Update all";
            this.cmnuCheckAndDownload.Click += new System.EventHandler(this.cmnuCheckAndDownload_Click);
            // 
            // cmnuOnlyCheck
            // 
            this.cmnuOnlyCheck.Text = "&Check all for updates only, do not download";
            this.cmnuOnlyCheck.Click += new System.EventHandler(this.cmnuOnlyCheck_Click);
            // 
            // ntiTrayIcon
            // 
            this.ntiTrayIcon.ContextMenuStrip = this.cmnuTrayIconMenu;
            this.ntiTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiTrayIcon.Icon")));
            this.ntiTrayIcon.Text = "Ketarin (Idle)";
            this.ntiTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntiTrayIcon_MouseDoubleClick);
            // 
            // cmnuTrayIconMenu
            // 
            this.cmnuTrayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.cmnuShow,
            this.cmnuExit});
            // 
            // cmnuShow
            // 
            this.cmnuShow.Text = "&Show";
            this.cmnuShow.Click += new System.EventHandler(this.cmnuShow_Click);
            // 
            // cmnuExit
            // 
            this.cmnuExit.Text = "E&xit";
            this.cmnuExit.Click += new System.EventHandler(this.cmnuExit_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSelectedApplications,
            this.tbNumByStatus,
            this.tbTotalApplications});
            this.statusBar.Location = new System.Drawing.Point(0, 260);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(682, 24);
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "statusBar";
            this.statusBar.Visible = false;
            // 
            // tbSelectedApplications
            // 
            this.tbSelectedApplications.Name = "tbSelectedApplications";
            this.tbSelectedApplications.Size = new System.Drawing.Size(130, 19);
            this.tbSelectedApplications.Text = "Selected applications: 0";
            // 
            // tbNumByStatus
            // 
            this.tbNumByStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tbNumByStatus.Name = "tbNumByStatus";
            this.tbNumByStatus.Size = new System.Drawing.Size(197, 19);
            this.tbNumByStatus.Text = "By status: 0 Idle, 0 Finished, 0 Failed";
            // 
            // tbTotalApplications
            // 
            this.tbTotalApplications.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tbTotalApplications.Name = "tbTotalApplications";
            this.tbTotalApplications.Size = new System.Drawing.Size(340, 19);
            this.tbTotalApplications.Spring = true;
            this.tbTotalApplications.Text = "Number of applications: 0";
            this.tbTotalApplications.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
#if !MONO
            // 
            // bInstall
            // 
            this.bInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bInstall.AutoSize = true;
            // Get the file icon for ".msi" in the system directory (which file
            // should not exist and cannot be created through GUI tools) --
            // This only works because the Windows implementation of
            // GetFileIcon makes a call to SHGetFileInfo() instead of calling
            // System.Drawing.Icon.ExtractAssociatedIcon().  When the former
            // gets a file that doesn't exist, it returns the icon based on
            // file name extension associations.  The latter throws an
            // exception for files that don't exist.
            this.bInstall.Image = Microsoft.Win32.IconReader.GetFileIcon(System.IO.Path.Combine(System.Environment.SystemDirectory, ".msi"), Microsoft.Win32.IconReader.IconSize.Small, false).ToBitmap();
            this.bInstall.Location = new System.Drawing.Point(290, 300);
            this.bInstall.Name = "bInstall";
            this.bInstall.Size = new System.Drawing.Size(85, 24);
            this.bInstall.TabIndex = 5;
            this.bInstall.Text = "I&nstall...";
            this.bInstall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bInstall.UseVisualStyleBackColor = true;
            this.bInstall.Click += new System.EventHandler(this.bInstall_Click);
#endif
            // 
            // bRun
            // 
            this.bRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bRun.AutoSize = true;
            this.bRun.Image = global::Ketarin.Properties.Resources.Restart;
            this.bRun.Location = new System.Drawing.Point(168, 300);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(116, 24);
            this.bRun.SplitMenuStrip = this.cmuRun;
            this.bRun.TabIndex = 4;
            this.bRun.Text = "&Update all";
            this.bRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // bAddApplication
            // 
            this.bAddApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddApplication.AutoSize = true;
            this.bAddApplication.Image = global::Ketarin.Properties.Resources.AddSmall;
            this.bAddApplication.Location = new System.Drawing.Point(12, 300);
            this.bAddApplication.Name = "bAddApplication";
            this.bAddApplication.Size = new System.Drawing.Size(150, 24);
            this.bAddApplication.SplitMenuStrip = this.cmuAdd;
            this.bAddApplication.TabIndex = 3;
            this.bAddApplication.Text = "&Add new application";
            this.bAddApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAddApplication.UseVisualStyleBackColor = true;
            this.bAddApplication.Click += new System.EventHandler(this.sbAddApplication_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(682, 316);
            this.ClientSize = new System.Drawing.Size(682, 336);
#if !MONO
            this.Controls.Add(this.bInstall);
#endif
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.bAddApplication);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.olvJobs);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "MainForm";
            this.SavePosition = true;
            this.Text = "Ketarin";
            ((System.ComponentModel.ISupportInitialize)(this.olvJobs)).EndInit();
#if !MONO
            ((System.ComponentModel.ISupportInitialize)(this.m_VistaMenu)).EndInit();
#endif
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApplicationJobsListView olvJobs;
        private System.Windows.Forms.ImageList imlStatus;
#if !MONO
        private CDBurnerXP.Controls.VistaMenu m_VistaMenu;
#endif
        private System.Windows.Forms.ContextMenuStrip cmnuJobs;
        private System.Windows.Forms.ToolStripMenuItem cmnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem cmnuEdit;
        private System.Windows.Forms.ToolStripMenuItem cmnuDelete;
        private CDBurnerXP.Controls.OLVColumn colName;
        private CDBurnerXP.Controls.OLVColumn colLastUpdate;
        private CDBurnerXP.Controls.OLVColumn colProgress;
        private CDBurnerXP.Controls.OLVColumn colTarget;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem cmnuRename;
        private CDBurnerXP.Controls.OLVColumn colCategory;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuExportSelected;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private wyDay.Controls.SplitButton bAddApplication;
        private System.Windows.Forms.ContextMenuStrip cmuAdd;
        private System.Windows.Forms.ToolStripMenuItem cmnuAdd;
        private System.Windows.Forms.ToolStripMenuItem cmnuImportFile;
        private System.Windows.Forms.ToolStripMenuItem cmnuImportOnline;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem cmnuCopy;
        private System.Windows.Forms.ToolStripMenuItem cmnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private wyDay.Controls.SplitButton bRun;
        private System.Windows.Forms.ContextMenuStrip cmuRun;
        private System.Windows.Forms.ToolStripMenuItem cmnuCheckAndDownload;
        private System.Windows.Forms.ToolStripMenuItem cmnuOnlyCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuTutorial;
        private System.Windows.Forms.NotifyIcon ntiTrayIcon;
        private System.Windows.Forms.ContextMenuStrip cmnuTrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuShow;
        private System.Windows.Forms.ToolStripMenuItem cmnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuExportAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuCheckForUpdate;
        private System.Windows.Forms.ToolStripMenuItem mnuLog;
        private System.Windows.Forms.ToolStripMenuItem mnuShowGroups;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel tbSelectedApplications;
        private System.Windows.Forms.ToolStripStatusLabel tbTotalApplications;
        private System.Windows.Forms.ToolStripMenuItem mnuShowStatusBar;
        private System.Windows.Forms.ToolStripMenuItem mnuInvert;
        private System.Windows.Forms.ToolStripMenuItem cmnuForceDownload;
        private System.Windows.Forms.ToolStripMenuItem mnuFind;
        private System.Windows.Forms.ToolStripMenuItem mnuAutoScroll;
#if !MONO
        private System.Windows.Forms.ToolStripMenuItem cmnuUpdateAndInstall;
#endif
        private CDBurnerXP.Controls.OLVColumn colStatus;
        private System.Windows.Forms.ToolStripStatusLabel tbNumByStatus;
#if !MONO
        private System.Windows.Forms.ToolStripMenuItem cmnuProperties;
        private wyDay.Controls.SplitButton bInstall;
        private System.Windows.Forms.ToolStripMenuItem cmnuInstall;
        private System.Windows.Forms.ToolStripMenuItem cmnuUpdateInstall;
#endif
        private System.Windows.Forms.ToolStripMenuItem cmnuCommands;
        private System.Windows.Forms.ToolStripMenuItem cmnuRunPostDownload;
    }
}

