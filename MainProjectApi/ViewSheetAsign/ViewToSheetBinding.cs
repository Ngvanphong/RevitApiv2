using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows.Controls;

namespace MainProjectApi.ViewSheetAsign
{
    [Transaction(TransactionMode.Manual)]
    public class ViewToSheetBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            AppPenalViewToSheet.ShowViewToSheet();
            InforViewSheet.UpdateFormInformation(doc);
            return Result.Succeeded;
        }

    }
    public static class InforViewSheet
    {
        
        public static void UpdateFormInformation(Document doc)
        {
            List<ViewSheet> listViewSheet = new List<ViewSheet>();
            listViewSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            IOrderedEnumerable<ViewSheet> vps = from ViewSheet vp in listViewSheet orderby vp.SheetNumber ascending select vp;
            List<SheetInfor> listSousce = new List<SheetInfor>();
            foreach(var sheet in vps)
            {
                SheetInfor sheetIn = new SheetInfor();
                sheetIn.SheetNumber = sheet.SheetNumber;
                sheetIn.SheetName = sheet.Name;
                listSousce.Add(sheetIn);
            }
            var listViewWpf= AppPenalViewToSheet.myFormViewToSheet.FindName("lvSheet") as ListView;
            listViewWpf.ItemsSource = listSousce;
        }
    }

    public class SheetInfor
    {
        public string SheetName { set; get; }
        public string SheetNumber { set; get; }
        
    }
}
