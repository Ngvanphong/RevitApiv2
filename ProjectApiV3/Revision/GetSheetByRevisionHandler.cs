using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectApiV3.Revision
{
    public class GetSheetByRevisionHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listItem = AppPanelRevision.myFormRevision.listViewRevisionInfor.CheckedItems;
            int countChecked = listItem.Count;
            var revisions = Autodesk.Revit.DB.Revision.GetAllRevisionIds(doc);
            List<Autodesk.Revit.DB.Revision> listRevisionCheck = new List<Autodesk.Revit.DB.Revision>();
            foreach (ElementId id in revisions)
            {
                Autodesk.Revit.DB.Revision revision = doc.GetElement(id) as Autodesk.Revit.DB.Revision;
                foreach(ListViewItem item in listItem)
                {
                    string name = item.Text;
                    if (name == revision.Name)
                    {
                        listRevisionCheck.Add(revision);
                    }
                }
            }
            List<ViewSheet> listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().OrderBy(x => x.SheetNumber).ToList();
            List<ViewSheet> listSheetCheck = new List<ViewSheet>();           
            foreach(ViewSheet sheet in listSheet)
            {
                int count = 0;
                var revisionSheetId = sheet.GetAllRevisionIds();                      
                foreach(ElementId id in revisionSheetId)
                {
                    Autodesk.Revit.DB.Revision revisionSheet = doc.GetElement(id) as Autodesk.Revit.DB.Revision;
                    if (listRevisionCheck.Exists(x => x.Name == revisionSheet.Name))
                    {
                        count = count + 1;                        
                    }
                }
                if (count == countChecked)
                {
                    listSheetCheck.Add(sheet);
                }
            }
            AppPanelRevision.myFormRevision.listViewSheetInfor.Items.Clear();
            foreach (var sheet in listSheetCheck.OrderBy(x => x.SheetNumber))
            {
                var sheetNumber = sheet.SheetNumber;
                string revisionName = string.Empty;
                try
                {
                    revisionName = doc.GetElement(sheet.GetCurrentRevision()).Name.ToString();
                }
                catch { }
                var sheetName = sheet.Name;
                var row = new string[] { sheetNumber, revisionName, sheetName };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelRevision.myFormRevision.listViewSheetInfor.Items.Add(lvi);
            }

        }

        public string GetName()
        {
            return "GetSheetByRevision";
        }
    }
}
