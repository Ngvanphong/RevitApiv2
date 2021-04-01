using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProjectApi.DuplicateSheet
{
   public static class AppPanelDuplicateSheet
    {
        public static frmDuplicateSheet myFormDuplicateSheet;
        public static void ShowFormDuplicate()
        {
            DuplicateSheetHandler handler = new DuplicateSheetHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormDuplicateSheet = new frmDuplicateSheet(myEvent, handler);
            myFormDuplicateSheet.Show();

        }
    }
}
