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
namespace MainProjectApi.ChangeSheetNumber
{
  public static  class AppPanelChangeSheetNumber
    {
        public static frmChangeSheetNumber myFormChangeSheetNumber;
        public static void ShowFormChange()
        {
            ChangeSheetNumberHandler handler = new ChangeSheetNumberHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormChangeSheetNumber = new frmChangeSheetNumber(myEvent, handler);
            myFormChangeSheetNumber.Show();
        }
    }
}
