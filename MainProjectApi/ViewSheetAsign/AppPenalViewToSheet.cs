using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace MainProjectApi.ViewSheetAsign
{
   public static class AppPenalViewToSheet
    {
        public static frmViewToSheet myFormViewToSheet;
        public static void ShowViewToSheet()
        {
            ViewToSheetHandler handlerViewToSheet = new ViewToSheetHandler();
            ExternalEvent eventViewToSheet = ExternalEvent.Create(handlerViewToSheet);
            myFormViewToSheet = new frmViewToSheet(eventViewToSheet, handlerViewToSheet);
            myFormViewToSheet.Show();
        }
    }
}
