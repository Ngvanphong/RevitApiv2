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
namespace MainProjectApi.AssignView
{
    public partial class frmAssignView : Form
    {
        private ExternalEvent _event;
        private AssignViewHandler _handler;
        public frmAssignView(ExternalEvent myevent, AssignViewHandler handler)
        {
            InitializeComponent();
            _event = myevent;
            _handler = handler;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmAssignView_Load(object sender, EventArgs e)
        {

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            _event.Raise();
        }

        private void listSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listSheet_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listItemChecked = AppPenalAssignView.myFormAssignView.listSheet.CheckedItems;
            if (listItemChecked.Count > 1)
            {
                foreach(ListViewItem item in listItemChecked)
                {
                    if (item.Index!=e.Item.Index)
                    {                       
                        item.Checked = false;
                    }
                }
            }

        }

        private void listSheet_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var listItemChecked = AppPenalAssignView.myFormAssignView.listViewView.CheckedItems;
            for (int i = 0; i < listItemChecked.Count; i++)
            {
                var name = AppPenalAssignView.myFormAssignView.listViewView.CheckedItems[i].Text;
                bool cadAdd = true;              
                foreach (ListViewItem item in AppPenalAssignView.myFormAssignView.listViewSelect.Items)
                {
                    if (item.Text == name)
                    {
                        cadAdd = false;
                    }
                }
                if (cadAdd)
                {
                    var row = new string[] { name };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = lvi;
                    AppPenalAssignView.myFormAssignView.listViewSelect.Items.Add(lvi);
                }

            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var listItemChecked = AppPenalAssignView.myFormAssignView.listViewSelect.CheckedItems;
            foreach (ListViewItem item in listItemChecked)
            {                
                AppPenalAssignView.myFormAssignView.listViewSelect.Items.Remove(item);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
