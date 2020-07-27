using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CDBurnerXP.IO;
using Mono.Unix.Native;
using Microsoft.Win32;

namespace Ketarin.Forms
{
    public partial class KFileDialog : Form
    {
        private string KFileDialogKey = "HKEY_CURRENT_USER\\Software\\KFileDialog";
        private string ViewTypeValue = "ViewType";
        private string ColumnWidthValue = "ColumnWidth";
        private string DialogHeightValue = "DialogHeight";
        private string DialogWidthValue = "DialogWidth";
        private string SplitterDistanceValue = "SplitterDistance";
        private bool m_CheckFileExists;
        private bool m_CheckPathExists;
        private string m_Directory;
        private string m_Filter;
        private string m_FileName;
        private string currentFilter;
        private Dictionary<string, string> filterDictionary;
        public enum Type
        {
            Open,
            SaveAs
        }
        private Type type;
        private int sortColumn;
        private bool sortAscending;
        public KFileDialog(Type type)
        {
            this.type = type;
            sortColumn = 0;
            sortAscending = true;
            inLoadFileList = false;
            InitializeComponent();
            fileListView.SmallImageList = new ImageList();
            fileListView.SmallImageList.ImageSize = new Size(16,16);
            fileListView.SmallImageList.Images.Add(global::Ketarin.Properties.Resources.SmallFolder);
            fileListView.SmallImageList.Images.Add(global::Ketarin.Properties.Resources.Document);
            fileListView.LargeImageList = new ImageList();
            fileListView.LargeImageList.ImageSize = new Size(32,32);
            fileListView.LargeImageList.Images.Add(global::Ketarin.Properties.Resources.Folder);
            fileListView.LargeImageList.Images.Add(global::Ketarin.Properties.Resources.Document);
            fileListView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            fileListView.Columns.Add("Size", -2, HorizontalAlignment.Right);
            fileListView.Columns.Add("Type", -2, HorizontalAlignment.Left);
            fileListView.Columns.Add("Date Modified", -2, HorizontalAlignment.Left);
            fileListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            View newView = (View)((int) Registry.GetValue(KFileDialogKey, ViewTypeValue, View.List));
            switch (newView)
            {
                case View.LargeIcon:
                    this.viewLargeIcon_Click(null, null);
                    break;
                case View.SmallIcon:
                    this.viewSmallIcon_Click(null, null);
                    break;
                case View.List:
                    this.viewList_Click(null, null);
                    break;
                default:
                case View.Details:
                    this.viewDetails_Click(null, null);
                    break;
            }
            setDialogSizes();
            currentFilter = null;
            if (type == Type.Open)
            {
                CheckFileExists = true;
                Text = "Open";
                ok.Text = "Open";
            }
            else
            {
                Text = "Save As";
                ok.Text = "Save";
            }
            loadMountList();
        }

        public bool CheckFileExists
        {
            get
            {
                return m_CheckFileExists;
            }
            set
            {
                m_CheckFileExists = value;
            }
        }

        public bool CheckPathExists
        {
            get
            {
                return m_CheckPathExists;
            }
            set
            {
                m_CheckPathExists = value;
            }
        }

        public string CurrentDir
        {
            get
            {
                return m_Directory;
            }
            set
            {
                loadFileList(value);
            }
        }

        public int FilterIndex
        {
            get
            {
                return extensions.SelectedIndex + 1;
            }
            set
            {
                extensions.SelectedIndex = value - 1;
            }
        }

        public string Filter
        {
            get
            {
                return m_Filter;
            }
            set
            {
                setFilter(value);
            }
        }

        public string InitialDirectory
        {
            set
            {
                loadFileList(value);
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                fileName.Text = value;
            }
        }
        
        public bool MultiSelect
        {
            get
            {
                return fileListView.MultiSelect;
            }
            set
            {
                if (type == Type.Open)
                    fileListView.MultiSelect = value;
                else
                    fileListView.MultiSelect = false;
            }
        }

        public void loadMountList()
        {
            List<string> items = new List<string>();
            items.Add("/");
            // Home directory for real user id, not effective user id
            Passwd passwd = new Passwd();
            Passwd passwdp = null;
            Syscall.getpwuid_r(Syscall.getuid(), passwd, out passwdp);
            items.Add(passwd.pw_dir);
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                DriveInfo driveInfo = new DriveInfo(drive);
                if (!drive.Equals("/")
                    && driveInfo.DriveType != DriveType.Unknown)
                {
                    items.Add(drive);
                }
                // TODO: Use PathEx.IsRemovableSource() to determine which icon
                // to use, once we start adding icons
            }
            mountList.Items.AddRange(items.ToArray());
            mountList.SetSelected(0, true);
        }

        public void loadFileList(string directory)
        {
            m_Directory = directory;
            loadFileList();
        }

        private void loadFileList()
        {
            inLoadFileList = true;
            fileName.Text = "";
            fileName.Items.Clear();
            lookIn.Items.Clear();
            string[] directories = m_Directory.Split(Path.DirectorySeparatorChar);
            string pathSoFar = "" + Path.DirectorySeparatorChar;
            lookIn.Items.Add(pathSoFar);
            foreach (string dir in directories)
            {
                if (dir.Length > 0)
                {
                    pathSoFar += dir;
                    lookIn.Items.Add(pathSoFar);
                    pathSoFar += Path.DirectorySeparatorChar;
                }
            }
            List<ListViewItem> listViewItems = new List<ListViewItem>();
            DirectoryInfo thisDirInfo = new DirectoryInfo(m_Directory);
            foreach (DirectoryInfo dirInfo in thisDirInfo.GetDirectories())
            {
                bool show = true;
                if (dirInfo.Name.StartsWith(".")
                    && !PathEx.IsShowHiddenFilesEnabled)
                    show = false;
                if (show)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(dirInfo.Name), 0);
                    // Size
                    item.SubItems.Add("");
                    // Type
                    item.SubItems.Add("Directory");
                    // Modified
                    item.SubItems.Add(Directory.GetLastWriteTime(dirInfo.FullName).ToString());
                    // Add both file and tmpFileName to the list!
                    fileName.Items.Add(dirInfo.FullName);
                    fileName.Items.Add(dirInfo.Name);
                    lookIn.Items.Add(dirInfo.FullName);
                    listViewItems.Add(item);
                }
            }
            FileInfo[] fileInfos = null;
            if (currentFilter != null)
                fileInfos = thisDirInfo.GetFiles(currentFilter);
            else
                fileInfos = thisDirInfo.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
            {
                bool show = true;
                if (fileInfo.Name.StartsWith(".")
                    && !PathEx.IsShowHiddenFilesEnabled)
                    show = false;
                if (show)
                {
                    ListViewItem item = new ListViewItem(fileInfo.Name, 1);
                    // Size
                    item.SubItems.Add(GetBytesReadable(fileInfo.Length));
                    // Type
                    item.SubItems.Add("File");
                    // Modified
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                    // Add both file and tmpFileName to the list!
                    fileName.Items.Add(fileInfo.FullName);
                    fileName.Items.Add(fileInfo.Name);
                    listViewItems.Add(item);
                }
            }
            lookIn.Text = m_Directory;
            fileListView.BeginUpdate();
            fileListView.Items.Clear();
            fileListView.Items.AddRange(listViewItems.ToArray());
            fileListView.EndUpdate();
            inLoadFileList = false;
        }

        public void setFilter(string filter)
        {
            string[] filters = filter.Split('|');

            if ((filters.Length % 2) != 0)
                // TODO: Throw an exception here, because the filter isn't
                // right!
                return;

            extensions.BeginUpdate();
            m_Filter = filter;
            filterDictionary = new Dictionary<string, string>();
            for (int i = 0; i < filters.Length; i+=2)
            {
                filterDictionary.Add(filters[i], filters[i+1]);
            }
            extensions.DataSource = new BindingSource(filterDictionary, null);
            extensions.DisplayMember = "Key";
            extensions.ValueMember = "Value";
            extensions.EndUpdate();
            extensions.SelectedIndex = 0;
        }

        protected void extensions_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
        {
            currentFilter = ((KeyValuePair<string, string>)extensions.SelectedItem).Value;
            if (!inLoadFileList)
            {
                loadFileList();
            }
        }

        protected void mountList_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
        {
            loadFileList((string)mountList.SelectedItem);
        }

        protected void fileListView_ColumnClick(object sender, ColumnClickEventArgs eventArgs)
        {
            if (sortColumn == eventArgs.Column)
            {
                if (sortAscending)
                    sortAscending = false;
                else
                    sortAscending = true;
            }
            else
            {
                sortColumn = eventArgs.Column;
                sortAscending = true;
            }
            fileListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
        }

        protected void fileListView_ItemActivate(object sender, EventArgs eventArgs)
        {
            if (fileListView.SelectedItems.Count == 1)
            {
                string target = Path.Combine(m_Directory, fileListView.SelectedItems[0].Text);
                if (Directory.Exists(target))
                {
                    loadFileList(target);
                }
            }

        }

        protected void fileListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs eventArgs)
        {
            if (fileListView.MultiSelect)
            {
                fileName.Text = "";
                foreach (ListViewItem item in fileListView.SelectedItems)
                {
                    if (!Directory.Exists(Path.Combine(m_Directory, item.Text)))
                    {
                        if (fileName.Text.Length > 0)
                        {
                            fileName.Text += ' ';
                        }
                        fileName.Text += '\"' + item.Text + '\"';
                    }
                    else
                        fileName.Text = "";
                }
            }
            else if (eventArgs.IsSelected)
            {
                if (!Directory.Exists(Path.Combine(m_Directory, eventArgs.Item.Text)))
                    fileName.Text = eventArgs.Item.Text;
                else
                    fileName.Text = "";
            }
            else
            {
                fileName.Text = "";
            }
        }

        protected void ok_Click(object sender, System.EventArgs eventArgs)
        {
            this.saveDialogSizes();
            if (fileName.Text.Length > 0)
            {
                string checkFile = getFullPathName();
                if (m_CheckPathExists)
                {
                    if (!Directory.Exists(Path.GetDirectoryName(checkFile)))
                    {
                        MessageBox.Show(this, "The directory of the file must exist!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (m_CheckFileExists)
                {
                    if (!File.Exists(checkFile))
                    {
                        MessageBox.Show(this, "The file must exist!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                m_FileName = checkFile;
                this.DialogResult = DialogResult.OK;
                this.Close();
                this.Dispose();
                return;
            }
            if (type == Type.Open)
                MessageBox.Show(this, "You must select a file to open.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(this, "You must specify a file to save.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void cancel_Click(object sender, System.EventArgs eventArgs)
        {
            this.saveDialogSizes();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        protected void viewLargeIcon_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.LargeIcon;
            Registry.SetValue(KFileDialogKey, ViewTypeValue, (int)this.fileListView.View);
            this.viewLargeIcon.Checked = true;
            this.viewSmallIcon.Checked = false;
            this.viewList.Checked = false;
            this.viewDetails.Checked = false;
        }

        protected void viewSmallIcon_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.SmallIcon;
            Registry.SetValue(KFileDialogKey, ViewTypeValue, (int)this.fileListView.View);
            this.viewLargeIcon.Checked = false;
            this.viewSmallIcon.Checked = true;
            this.viewList.Checked = false;
            this.viewDetails.Checked = false;
        }

        protected void viewList_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.List;
            Registry.SetValue(KFileDialogKey, ViewTypeValue, (int)this.fileListView.View);
            this.viewLargeIcon.Checked = false;
            this.viewSmallIcon.Checked = false;
            this.viewList.Checked = true;
            this.viewDetails.Checked = false;
        }

        protected void viewDetails_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.Details;
            Registry.SetValue(KFileDialogKey, ViewTypeValue, (int)this.fileListView.View);
            this.viewLargeIcon.Checked = false;
            this.viewSmallIcon.Checked = false;
            this.viewList.Checked = false;
            this.viewDetails.Checked = true;
        }

        protected void refresh_Click(object sender, System.EventArgs eventArgs)
        {
            loadFileList();
        }

        protected void lookIn_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
        {
            if (!inLoadFileList)
            {
                loadFileList((string)lookIn.SelectedItem);
                inLoadFileList = false;
            }
        }

        protected void fileName_KeyDown(object sender, KeyEventArgs eventArgs)
        {
            if (eventArgs.KeyCode == Keys.Enter)
            {
                this.ok_Click(null, null);
            }
        }

        protected void fileName_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
        {
            string tmpFileName = (string)fileName.SelectedItem;
            if (!tmpFileName.StartsWith("/"))
            {
                tmpFileName = Path.Combine(m_Directory,
                    (string)fileName.SelectedItem);
            }
            if (Directory.Exists(tmpFileName))
            {
                loadFileList(tmpFileName);
                fileName.Text = "";
            }
            else
            {
                fileName.Text = (string)fileName.SelectedItem;
            }
        }

        private string appendExtension(string pathName, string filter)
        {
            string[] extensions = filter.Split(',');
            bool extensionFound = false;
            foreach (string extension in extensions)
            {
                string[] tmp = extension.Split('.');
                if ((tmp.Length > 1)
                    && (PathEx.IsExtension(pathName, tmp[tmp.Length - 1])))
                {
                    extensionFound = true;
                    break;
                }
                else if (PathEx.IsExtension(pathName, extension))
                {
                    extensionFound = true;
                    break;
                }
            }
            if (!extensionFound)
            {
                string[] tmp = extensions[0].Split('.');
                if (tmp.Length > 1)
                    return pathName + '.' + tmp[tmp.Length - 1];
                return pathName + '.' +  extensions[0];
            }
            return pathName;
        }

        private string getFullPathName()
        {
            if (fileName.Text.Length == 0)
                return "";
            if (fileListView.MultiSelect)
                return fileName.Text;

            currentFilter = ((KeyValuePair<string, string>)extensions.SelectedItem).Value;
            string pathName = fileName.Text;
            pathName = appendExtension(pathName, currentFilter);
            if (pathName.StartsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return pathName;
            }
            return Path.Combine(m_Directory, pathName);
        }

	private void saveDialogSizes()
	{
            Registry.SetValue(KFileDialogKey, ColumnWidthValue+"1",
                fileListView.Columns[0].Width);
            Registry.SetValue(KFileDialogKey, ColumnWidthValue+"2",
                fileListView.Columns[1].Width);
            Registry.SetValue(KFileDialogKey, ColumnWidthValue+"3",
                fileListView.Columns[2].Width);
            Registry.SetValue(KFileDialogKey, ColumnWidthValue+"4",
                fileListView.Columns[3].Width);
            Registry.SetValue(KFileDialogKey, DialogHeightValue,
		ClientSize.Height);
            Registry.SetValue(KFileDialogKey, DialogWidthValue,
		ClientSize.Width);
            Registry.SetValue(KFileDialogKey, SplitterDistanceValue,
		splitContainer.SplitterDistance);
        }

        private void setDialogSizes()
        {
            ClientSize = new System.Drawing.Size(
                (int) Registry.GetValue(KFileDialogKey, DialogWidthValue, 526),
                (int) Registry.GetValue(KFileDialogKey, DialogHeightValue, 348));
            splitContainer.SplitterDistance =
                (int) Registry.GetValue(KFileDialogKey, SplitterDistanceValue, 104);
            fileListView.Columns[0].Width =
                (int) Registry.GetValue(KFileDialogKey, ColumnWidthValue+"1", -2);
            fileListView.Columns[1].Width =
                (int) Registry.GetValue(KFileDialogKey, ColumnWidthValue+"2", -2);
            fileListView.Columns[2].Width =
                (int) Registry.GetValue(KFileDialogKey, ColumnWidthValue+"3", -2);
            fileListView.Columns[3].Width =
                (int) Registry.GetValue(KFileDialogKey, ColumnWidthValue+"4", -2);
        }

        // Returns the human-readable file size for an arbitrary, 64-bit file
        // size.  The default format is "0.# XB", e.g. "42.3 KB" or "1,430.4 MB"
        // Updated by TOM so that it won't return 1.5KB, but 1,500KB
        // From https://www.somacon.com/p576.php
        public string GetBytesReadable(long i)
        {
            // Get absolute value
            long absolute_i = (i < 0 ? -i : i);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (i >> 50);
            }
            else if (absolute_i >= 0x28000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (i >> 40);
            }
            else if (absolute_i >= 0xA0000000000) // Terabyte
            {
                suffix = "TB";
                readable = (i >> 30);
            }
            else if (absolute_i >= 0x280000000) // Gigabyte
            {
                suffix = "GB";
                readable = (i >> 20);
            }
            else if (absolute_i >= 0xA00000) // Megabyte
            {
                suffix = "MB";
                readable = (i >> 10);
            }
            else if (absolute_i >= 0x2800) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.# ") + suffix;
        }

        class ListViewItemComparer : System.Collections.IComparer
        {
            private int column;
            private bool ascending;
            public ListViewItemComparer()
            {
                column = 0;
            }

            public ListViewItemComparer(int column, bool ascending)
            {
                this.column = column;
                this.ascending = ascending;
            }

            public int Compare(object x, object y)
            {
                ListViewItem lviX = null;
                ListViewItem lviY = null;
                if (ascending)
                {
                    lviX = (ListViewItem)x;
                    lviY = (ListViewItem)y;
                }
                else
                {
                    lviX = (ListViewItem)y;
                    lviY = (ListViewItem)x;
                }
                int comp = 0;
                // Always sort by Type (column 2) first, unless that's what
                // we're supposed to sort by...
                if (column != 2)
                {
                    comp = String.Compare(lviX.SubItems[2].Text,
                        lviY.SubItems[2].Text);
                }
                // If comp is 0, they're the same type, so proceed to requested
                // sort order...
                if (comp == 0)
                {
                    comp = String.Compare(lviX.SubItems[column].Text,
                        lviY.SubItems[column].Text);
                    if (comp == 0)
                    {
                        comp = String.Compare(lviX.SubItems[0].Text,
                            lviY.SubItems[0].Text);
                    }
                }
                return comp;
            }
        }
    }
}
