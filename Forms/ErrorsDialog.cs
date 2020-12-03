using System;
using System.Text;
using CDBurnerXP.Forms;
using CDBurnerXP.IO;

namespace Ketarin.Forms
{
    /// <summary>
    /// Represents a dialog which displays all errors 
    /// which occured during an update process.
    /// </summary>
    public partial class ErrorsDialog : PersistentForm
    {
        private ApplicationJobError[] m_Errors;

        #region Properties

        /// <summary>
        /// Gets or sets the errors which are to be shown in the dialog.
        /// </summary>
        internal ApplicationJobError[] Errors
        {
            get { return m_Errors; }
            set { m_Errors = value; }
        }

        #endregion

        internal ErrorsDialog(ApplicationJobError[] errors)
        {
            InitializeComponent();
            CancelButton = bClose;

            m_Errors = errors;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
#if MONO
	    // Quick fix for width; setting Width to -1 on mono doesn't size it
	    // to content.  TODO: Fix this properly, tracking the max width in
	    // the foreach loop, and set this.colError.Width to that at the end
	    // of the loop.
            this.colError.Width = this.olvErrors.Width - this.colAppName.Width - 4;
            foreach (ApplicationJobError error in m_Errors) {
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(new String[]{error.ApplicationJob.Name, error.Message}, 0);
                olvErrors.Items.Add(item);
            }
#else
            olvErrors.SetObjects(m_Errors);
#endif
        }

        private void bCopyToClipboard_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // Copy all errors to clipboard (separated with tabs and newlines)
            foreach (ApplicationJobError error in m_Errors)
            {
                sb.Append(error.ApplicationJob.Name);
                sb.Append("\t");
                sb.AppendLine(error.Message);
            }

            SafeClipboard.SetData(sb.ToString(), true);
        }
    }
}
