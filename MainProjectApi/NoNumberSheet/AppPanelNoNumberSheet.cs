using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using MainProjectApi.Helper;
using System.IO;

namespace MainProjectApi.NoNumberSheet
{
  
   public static class AppPanelNoNumberSheet
    {
        public static frmNoNumberSheet myFormNoNumberSheet;
        public static void ShowFormNoNumber()
        {
            NoNumberSheetHandler handler = new NoNumberSheetHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormNoNumberSheet = new frmNoNumberSheet(myEvent, handler);
            myFormNoNumberSheet.Show();
        }
    }
}
