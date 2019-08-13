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
namespace ProjectApiV3.FilterElement
{
   public static class AppPanelFilterElement
    {
        public static frmFilerElement myFormFilterElement;
        public static int numberButtonClick;       
        public static void ShowFormFilterElement()
        {
            FilterElementHandler handler = new FilterElementHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormFilterElement = new frmFilerElement(myEvent, handler);
            myFormFilterElement.Show();

        }

    }
}
