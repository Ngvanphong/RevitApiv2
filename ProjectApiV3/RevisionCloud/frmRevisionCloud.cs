using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectApiV3.RevisionCloud
{
    public partial class frmRevisionCloud : Form
    {

        private ReloadRevisionCloudHandler _handlerReloadCloud;
        private ExternalEvent _eventReloadCloud;
        private SelectRevisionCloudHandler _handlerSelectCloud;
        private ExternalEvent _eventSelectCloud;
        private FilterRevisionCloudHandler _handlerFilterRevisonCloud;
        private ExternalEvent _eventFilterCloud;
        public frmRevisionCloud(ExternalEvent eventReloadCloud, ReloadRevisionCloudHandler handlerReloadCloud,
            ExternalEvent eventSelectCloud, SelectRevisionCloudHandler handlerSelectCloud, ExternalEvent eventFilterCloud, FilterRevisionCloudHandler handlerFilterRevisonCloud)
        {
            
            InitializeComponent();
            _handlerReloadCloud = handlerReloadCloud;
            _eventReloadCloud = eventReloadCloud;
            _handlerSelectCloud = handlerSelectCloud;
            _eventSelectCloud = eventSelectCloud;
            _eventFilterCloud = eventFilterCloud;
            _handlerFilterRevisonCloud = handlerFilterRevisonCloud;
        }

        private void frmRevisionCloud_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectRevisionCloud_Click(object sender, EventArgs e)
        {
            _eventSelectCloud.Raise();
        }

        private void btnReloadRevisionCloud_Click(object sender, EventArgs e)
        {
            _eventReloadCloud.Raise();
        }

        private void dropChooseFilterCloud_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventFilterCloud.Raise();
        }

        private void checkBoxCheckAllRevisionCloud_CheckedChanged(object sender, EventArgs e)
        {
           
                var listItem = this.listViewRevisionCloud.Items;
                if (this.checkBoxCheckAllRevisionCloud.Checked == false)
                {
                    foreach (ListViewItem item in listItem)
                    {
                        item.Checked = false;
                    }
                }
                else
                {
                    foreach (ListViewItem item in listItem)
                    {
                        item.Checked = true;
                    }
                }
           
        }
    }
}
