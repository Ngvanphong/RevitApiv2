using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ProjectApiV3.Helper;

namespace ProjectApiV3.CropView
{
    public partial class frmCropView : Form
    {
        private CropViewHandler _cropHandler;
        private ExternalEvent _cropEvent;
        public frmCropView(ExternalEvent cropEvent,CropViewHandler cropHandler)
        {
            InitializeComponent();
            _cropEvent = cropEvent;
            _cropHandler = cropHandler;
        }

        private void frmCropView_Load(object sender, EventArgs e)
        {

        }

        private void btnCropView_Click(object sender, EventArgs e)
        {
            _cropEvent.Raise();
        }

        private void listViewViewCropSimilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listViewViewCropSimilar_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listItemChecked = AppPanelCropView.myFormCropView.listViewViewCropSimilar.CheckedItems;
            if (listItemChecked.Count > 1)
            {
                foreach (ListViewItem item in listItemChecked)
                {
                    if (item.Index != e.Item.Index)
                    {
                        item.Checked = false;
                    }
                }
            }
        }
    }
}
