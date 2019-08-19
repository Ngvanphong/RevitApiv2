using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using ProjectApiV3.Helper;
using System.IO;
using System.Windows.Forms;

namespace ProjectApiV3.Revision
{
   public static class AppPanelRevision
    {
        public static frmRevision myFormRevision;
        public static void ShowFormRevision()
        {
            RevisionHandler handler = new RevisionHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormRevision = new frmRevision(myEvent, handler);
            myFormRevision.Show();           
        }

    }
}
