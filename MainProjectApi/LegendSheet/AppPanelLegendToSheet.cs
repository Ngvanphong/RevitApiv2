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

namespace MainProjectApi.LegendSheet
{
  public static  class AppPanelLegendToSheet
    {
        public static frmLegendToSheet myFormLegendToSheet;
        public static ListViewItem mySelectItemLegend;
        public static int AddLegend = 0;
        public static void ShowFormAssignLegend()
        {
            LegendToSheetHandler handler = new LegendToSheetHandler();
            ExternalEvent myEvent = ExternalEvent.Create(handler);
            myFormLegendToSheet = new frmLegendToSheet(myEvent, handler);
            myFormLegendToSheet.Show();

        }
    }
}
