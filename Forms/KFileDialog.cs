﻿using System;
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

namespace Ketarin.Forms
{
    public partial class KFileDialog : Form
    {
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
	    fileListView.Columns.Add("Name", -2, HorizontalAlignment.Left);
	    fileListView.Columns.Add("Size", -2, HorizontalAlignment.Right);
	    fileListView.Columns.Add("Type", -2, HorizontalAlignment.Left);
	    fileListView.Columns.Add("Date Modified", -2, HorizontalAlignment.Left);
	    fileListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
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

        public string InitialDir
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
	    // TODO: Get mounted file systems -- unfortunately, there's no
	    // standard interface for this. If available, use getfsstat() or
	    // getmntinfo(), on Linux, use /proc/self/mountinfo
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
		    ListViewItem item = new ListViewItem(fileInfo.Name, 0);
		    // Size
		    item.SubItems.Add(fileInfo.Length.ToString());
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
	    this.DialogResult = DialogResult.Cancel;
            this.Close();
	    this.Dispose();
        }

        protected void viewLargeIcon_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.LargeIcon;
            this.viewLargeIcon.Checked = true;
            this.viewSmallIcon.Checked = false;
            this.viewList.Checked = false;
            this.viewDetails.Checked = false;
        }

        protected void viewSmallIcon_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.SmallIcon;
            this.viewLargeIcon.Checked = false;
            this.viewSmallIcon.Checked = true;
            this.viewList.Checked = false;
            this.viewDetails.Checked = false;
        }

        protected void viewList_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.List;
            this.viewLargeIcon.Checked = false;
            this.viewSmallIcon.Checked = false;
            this.viewList.Checked = true;
            this.viewDetails.Checked = false;
        }

        protected void viewDetails_Click(object sender, System.EventArgs eventArgs)
        {
            this.fileListView.View = View.Details;
            this.viewLargeIcon.Checked = false;
            this.viewSmallIcon.Checked = false;
            this.viewList.Checked = false;
            this.viewDetails.Checked = true;
        }

        protected void lookIn_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
        {
            if (!inLoadFileList)
            {
                loadFileList((string)lookIn.SelectedItem);
                inLoadFileList = false;
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
