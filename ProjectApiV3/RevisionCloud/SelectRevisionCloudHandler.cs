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
                int elemntIdInt = int.Parse(item.SubItems[8].Text);
                ElementId id = new ElementId(elemntIdInt);
                listIdCloud.Add(id);
            }
            app.ActiveUIDocument.Selection.SetElementIds(listIdCloud);
        }

        public string GetName()
        {
            return "SelectRevisionCloud";
        }
    }
}
