using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
namespace MainProjectApi.ViewSheetAsign
{
    public class ViewToSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ElementId idSelect = null;
            try
            {
                idSelect  = app.ActiveUIDocument.Selection.GetElementIds().First();
            }
            catch
            {
                MessageBox.Show("You must choose a view on sheet");
                return;
            }
            Viewport viewPortChoose = doc.GetElement(idSelect) as Viewport;
            List<Autodesk.Revit.DB.View> listViewSelect = GetViewChecked(doc);
            List<ViewSheet> listSheetSelect = GetSheetChecked(doc);


        }

        public string GetName()
        {
            return "ViewToSheetHandlers";
        }

        public List<Autodesk.Revit.DB.View> GetViewChecked(Document doc)
        {    
            List<Autodesk.Revit.DB.View> listView = new List<Autodesk.Revit.DB.View>();
            var listItemView = AppPenalViewToSheet.myFormViewToSheet.listViewViewAssignTo.CheckedItems;
            var listAllView = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).Cast<Autodesk.Revit.DB.View>();
            foreach (ListViewItem view in listItemView)
            {
                var name = view.Text;
                foreach (var viewAdd in listAllView)
                {
                    var viewname = viewAdd.ViewType + "/Name: " + viewAdd.Name;
                    if (viewname == name)
                    {
                        listView.Add(viewAdd);
                    }
                }
            }
            return listView;
        }

        public List<ViewSheet> GetSheetChecked(Document doc)
        {
            var listItemSheet = AppPenalViewToSheet.myFormViewToSheet.listViewSheetAssignView.CheckedItems;
            var listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>();
            List<ViewSheet> listViewSheetCheck = new List<ViewSheet>();
            foreach (ListViewItem item in listItemSheet)
            {
                var sheet = listSheet.Where(x => x.SheetNumber == item.Text).First();
                listViewSheetCheck.Add(sheet);
            }          
            return listViewSheetCheck;
        }
    }
}
