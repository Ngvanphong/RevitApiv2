using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;

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
        public static List<Autodesk.Revit.DB.View> GetView(Document doc, out List<Autodesk.Revit.DB.ViewSheet> listSheet)
        {
            var listView = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).Cast<Autodesk.Revit.DB.View>();
            List<Autodesk.Revit.DB.View> listviewNotUse = new List<Autodesk.Revit.DB.View>();
            List<ViewSheet> listViewSheet = new List<ViewSheet>();
            foreach (var item in listView)
            {
                ViewSheet viewSheet = item as ViewSheet;
                if (viewSheet == null && item.ViewType != ViewType.Legend)
                {
                    listviewNotUse.Add(item);
                }
                else
                {
                    if (item.ViewType != ViewType.Legend)
                    {
                        listViewSheet.Add(viewSheet);
                    }
                }
            }
            List<Autodesk.Revit.DB.View> result = new List<Autodesk.Revit.DB.View>();
            foreach (var item in listviewNotUse)
            {
                foreach (var view in listViewSheet)
                {
                    if (Viewport.CanAddViewToSheet(doc, view.Id, item.Id) == true)
                    {
                        result.Add(item);
                        break;
                    }
                }
            }
            listSheet = listViewSheet;
            return result;
        }

        public static void UpdateFormInformation(Document doc)
        {
            List<ViewSheet> listViewSheet = new List<ViewSheet>();
            List<Autodesk.Revit.DB.View> listView = InforViewSheet.GetView(doc,out listViewSheet);

            foreach (var item in listView.OrderBy(x => x.ViewType + "/Name: " + x.Name))
            {
                var row = new string[] { item.ViewType + "/Name: " + item.Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPenalViewToSheet.myFormViewToSheet.listViewViewAssignTo.Items.Add(lvi);
            }

            IOrderedEnumerable<ViewSheet> vps = from ViewSheet vp in listViewSheet orderby vp.SheetNumber ascending select vp;
            foreach (var sheet in vps)
            {
                var sheetNumber = sheet.SheetNumber;
                var sheetName = sheet.Name;
                var row = new string[] { sheetNumber, sheetName };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPenalViewToSheet.myFormViewToSheet.listViewSheetAssignView.Items.Add(lvi);
            }
        }
    }
}
