using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using MainProjectApi.Helper;
using System.Windows.Forms;

namespace MainProjectApi.DuplicateSheet
{
    [Transaction(TransactionMode.Manual)]
    public class DuplicateSheetBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelDuplicateSheet.ShowFormDuplicate();
                GetSheetForForm(doc);
            }
            return Result.Succeeded;
        }
        public void GetSheetForForm(Document doc)
        {
            List<ViewSheet> listSheet = new List<ViewSheet>();
            listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            foreach (var sheet in listSheet.OrderByDescending(x => x.SheetNumber))
            {
                var sheetNumber = sheet.SheetNumber;
                var sheetName = sheet.ViewName;
                var row = new string[] { sheetNumber, sheetName };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelDuplicateSheet.myFormDuplicateSheet.listViewSheet.Items.Add(lvi);
            }

        }
    }
}
