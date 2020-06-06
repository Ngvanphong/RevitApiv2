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
using Autodesk.Revit.UI.Selection;

namespace ProjectApiV3.RevisionCloud
{
    public class SelectRevisionCloudHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var revisionClouds = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.RevisionCloud)).Cast<Autodesk.Revit.DB.RevisionCloud>().ToList();
            var listItemChecked = AppPanelRevisionCloud.myFormRevisionCloud.listViewRevisionCloud.CheckedItems;
            List<ElementId> listIdCloud = new List<ElementId>();
            foreach (ListViewItem item in listItemChecked)
            {        
                int elemntIdInt = int.Parse(item.SubItems[9].Text);
                ElementId id = new ElementId(elemntIdInt);
                listIdCloud.Add(id);
            }
            if (listIdCloud.Count > 0)
            {
                app.ActiveUIDocument.Selection.SetElementIds(listIdCloud);
                var rev = doc.GetElement(listIdCloud.First()) as Autodesk.Revit.DB.RevisionCloud;
                app.ActiveUIDocument.ActiveView = doc.GetElement(rev.OwnerViewId) as Autodesk.Revit.DB.View;
                app.ActiveUIDocument.ShowElements(rev);
            }
        }

        public string GetName()
        {
            return "SelectRevisionCloud";
        }
    }
}
