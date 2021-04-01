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
    public class RevisionHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<ElementId> revisionCheckIds = GetRevisionCheckedId(doc);
            List<ViewSheet> sheetChecks = getListSheets(doc);
            if (AppPanelRevision.buttonCilick == 0)
            {

                foreach (var sheet in sheetChecks)
                {

                    using (Transaction t = new Transaction(doc, "AssignRevision"))
                    {
                        t.Start();
                        try
                        {
                            var revisionIdAdded = sheet.GetAllRevisionIds();
                            var allRevision = revisionCheckIds.Union(revisionIdAdded).Distinct().ToList();
                            sheet.SetAdditionalRevisionIds(allRevision);
                            t.Commit();
                        }
                        catch { t.Commit(); continue; };

                    }
                }
            }
            else if (AppPanelRevision.buttonCilick == 1)
            {
                foreach (var sheet in sheetChecks)
                {

                    using (Transaction t = new Transaction(doc, "RemoveRevision"))
                    {
                        t.Start();
                        try
                        {
                            var revisionIdAdded = sheet.GetAllRevisionIds();
                            List<ElementId> allRevision = new List<ElementId>();
                            if (revisionCheckIds.Count>= revisionIdAdded.Count)
                            {
                                sheet.SetAdditionalRevisionIds(new List<ElementId>());
                            }
                            else
                            {
                                allRevision = revisionIdAdded.Except(revisionCheckIds).ToList();
                                sheet.SetAdditionalRevisionIds(allRevision);
                            }
                            t.Commit();
                        }
                        catch { t.Commit(); continue; };

                    }
                }
            }
            AppPanelRevision.myFormRevision.listViewSheetAssign.Items.Clear();
            GetInformation.GetAllSheet(doc);
            var listItemOne = AppPanelRevision.myFormRevision.listViewRevisionInfor.CheckedItems;
            foreach(ListViewItem item in listItemOne)
            {
                item.Checked = false;
                item.Checked = true;
                break;
            } 
                   
        }

        public string GetName()
        {
            return "RevisionSheet";
        }
        public List<ElementId> GetRevisionCheckedId(Document doc)
        {
            List<ElementId> result = new List<ElementId>();
            var listItem = AppPanelRevision.myFormRevision.listViewRevisionAssign.CheckedItems;
            var revisionIds = Autodesk.Revit.DB.Revision.GetAllRevisionIds(doc);
            foreach (ElementId id in revisionIds)
            {
                Autodesk.Revit.DB.Revision revision = doc.GetElement(id) as Autodesk.Revit.DB.Revision;
                foreach (ListViewItem item in listItem)
                {
                    string name = item.Text;
                    if (name == revision.Name)
                    {
                        result.Add(id);
                    }
                }
            }
            return result;
        }
        public List<ViewSheet> getListSheets(Document doc)
        {
            List<ViewSheet> result = new List<ViewSheet>();
            var listItem = AppPanelRevision.myFormRevision.listViewSheetAssign.CheckedItems;
            List<ViewSheet> listSheetsAll = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            foreach (ViewSheet sheet in listSheetsAll)
            {
                foreach (ListViewItem item in listItem)
                {
                    string sheetNumber = item.Text;
                    if (sheetNumber == sheet.SheetNumber)
                    {
                        result.Add(sheet);
                    }
                }
            }
            return result;
        }
    }
}
