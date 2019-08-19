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
using ProjectApiV3.Helper;

namespace ProjectApiV3.Revision
{
    [Transaction(TransactionMode.Manual)]
    public class RevisionBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelRevision.ShowFormRevision();
                GetInformation.GetRevision(doc);
                GetInformation.GetAllSheet(doc);
            }
            return Result.Succeeded;
        }
        
    }
    public static class GetInformation
    {
        public static void GetRevision(Document document)
        {
            
            List<Autodesk.Revit.DB.Revision> result = new List<Autodesk.Revit.DB.Revision>();
            var revisions = Autodesk.Revit.DB.Revision.GetAllRevisionIds(document);
            foreach(ElementId id in revisions)
            {
                Autodesk.Revit.DB.Revision revision = document.GetElement(id) as Autodesk.Revit.DB.Revision;
                if (revision != null)
                {
                    result.Add(revision);
                }
            }
            foreach (var re in result.OrderBy(x => x.Name))
            {
                string name = re.Name;
                string date = re.RevisionDate.ToString();
                var row = new string[] { name, date };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelRevision.myFormRevision.listViewRevisionInfor.Items.Add(lvi);
            }
            foreach (var re in result.OrderBy(x => x.Name))
            {
                string name = re.Name;             
                var row = new string[] { name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelRevision.myFormRevision.listViewRevisionAssign.Items.Add(lvi);
            }
        }

        public static void GetAllSheet(Document document)
        {
            List<ViewSheet> result = new List<ViewSheet>();
            result = new FilteredElementCollector(document).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().OrderBy(x=>x.SheetNumber).ToList();
            foreach (var sheet in result.OrderBy(x=>x.SheetNumber))
            {      
                var sheetNumber = sheet.SheetNumber;
                string revisionName = string.Empty;
                try
                {
                    revisionName = document.GetElement(sheet.GetCurrentRevision()).Name.ToString();
                }
                catch { }
                var sheetName = sheet.ViewName;
                var row = new string[] { sheetNumber,revisionName, sheetName };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelRevision.myFormRevision.listViewSheetAssign.Items.Add(lvi);
            }            
        }
    }

}
