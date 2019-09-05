using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using MainProjectApi.Helper;

namespace MainProjectApi.LegendSheet
{
    [Transaction(TransactionMode.Manual)]
    public class LegendToSheetBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelLegendToSheet.ShowFormAssignLegend();
                GetInforLegend.GetInforToForm(doc);
            }
            return Result.Succeeded;
        }
    }
    public class GetInforLegend
    {
        public static List<ViewSheet> GetSheet(Document doc)
        {
            var listViewShet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().OrderByDescending(x=>x.SheetNumber).ToList();
            return listViewShet;
        }
        public static List<Autodesk.Revit.DB.View> GetLegendInfo(Document doc)
        {
            var listLegend = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).Cast<Autodesk.Revit.DB.View>();
            List<Autodesk.Revit.DB.View> listLegends = new List<Autodesk.Revit.DB.View>();
            foreach(var item in listLegend)
            {
                if (item.ViewType == ViewType.Legend)
                {
                    listLegends.Add(item);
                }
            }
            return listLegends;

        }
        public static void GetInforToForm(Document doc)
        {
            List<ViewSheet> listViewSheet   = GetSheet(doc);
            List<Autodesk.Revit.DB.View> listLegend = GetLegendInfo(doc);
            foreach (var item in listLegend)
            {
                var row = new string[] { item.Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelLegendToSheet.myFormLegendToSheet.listViewLegend.Items.Add(lvi);
            }
            foreach(var item in listViewSheet)
            {  
                    var sheetNumber = item.SheetNumber;
                    var sheetName = item.Name;
                    var row = new string[] { sheetNumber, sheetName };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = lvi;
                    AppPanelLegendToSheet.myFormLegendToSheet.listViewSheet.Items.Add(lvi);             
            }
            foreach (var item in listViewSheet)
            {
                var sheetNumber = item.SheetNumber;
                var sheetName = item.Name;
                var row = new string[] { sheetNumber, sheetName };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelLegendToSheet.myFormLegendToSheet.listViewSheetSimilar.Items.Add(lvi);
            }
        }

       
    }
}
