using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using MainProjectApi.Helper;
using System.IO;
using System.Windows.Forms;

namespace MainProjectApi.AssignView
{
    public static class AppPenalAssignView
    {
        public static frmAssignView myFormAssignView;
        public static ListViewItem mySelectItem;
        public static void ShowFormAssignView()
        {
            AssignViewHandler handler = new AssignViewHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormAssignView = new frmAssignView(myEvent, handler);
            myFormAssignView.Show();

        }
    }
}
