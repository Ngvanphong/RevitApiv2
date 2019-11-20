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
namespace MainProjectApi.LegendSheet
{
    public partial class frmLegendToSheet : Form
    {
        private ExternalEvent _event;
        private LegendToSheetHandler _handler;

        public frmLegendToSheet(ExternalEvent myevent, LegendToSheetHandler handler)
        {
            InitializeComponent();
            _event = myevent;
            _handler = handler;
        }

        private void frmLegendToSheet_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAssignLegend_Click(object sender, EventArgs e)
        {
            AppPanelLegendToSheet.AddLegend = 0;
            _event.Raise();
        }

        private void listViewSheetSimilar_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void listViewSheetSimilar_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listItemChecked = AppPanelLegendToSheet.myFormLegendToSheet.listViewSheetSimilar.CheckedItems;
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

        private void btnRemoveRevision_Click(object sender, EventArgs e)
        {
            AppPanelLegendToSheet.AddLegend = 1;
            _event.Raise();
        }

        private void btnAlignLegend_Click(object sender, EventArgs e)
        {
            AppPanelLegendToSheet.AddLegend = 2;
            _event.Raise();
        }
    }
}
