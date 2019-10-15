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
using MainProjectApi.Helper;

namespace MainProjectApi.LegendSheet
{
    public class LegendToSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {

            Document doc = app.ActiveUIDocument.Document;
            List<Autodesk.Revit.DB.View> listLegends = GetLegendCheked(doc);
            List<ViewSheet> listSheetAssign = GetSheets(doc);
            if (AppPanelLegendToSheet.AddLegend == true)
            {
                ViewSheet sheetSimilar = null;
                bool similar = GetLegendSimilar(doc, listLegends, out sheetSimilar);
                if (similar)
                {
                    var listViewPortId = sheetSimilar.GetAllViewports().ToList();
                    foreach (var legend in listLegends)
                    {
                        XYZ location = null;
                        ElementId typeView = null;
                        foreach (var id in listViewPortId)
                        {
                            Viewport viewPort = doc.GetElement(id) as Viewport;
                            if (viewPort.ViewId == legend.Id)
                            {
                                location = viewPort.GetBoxCenter();
                                typeView = viewPort.GetTypeId();
                                break;
                            }
                        }
                        foreach (var sheet in listSheetAssign)
                        {
                            try
                            {
                                using (Transaction t = new Transaction(doc, "Assginlegend"))
                                {
                                    t.Start();
                                    Viewport viewNew = Viewport.Create(doc, sheet.Id, legend.Id, location);
                                    viewNew.ChangeTypeId(typeView);
                                    t.Commit();
                                }
                            }
                            catch
                            {
                                continue;
                            }

                        }
                    }
                    MessageBox.Show("Adding legend is finished");

                }
            }
            else if (AppPanelLegendToSheet.AddLegend == false)
            {
                foreach (var sheet in listSheetAssign)
                {
                    var viewPortIds = sheet.GetAllViewports();
                    foreach (ElementId id in viewPortIds)
                    {
                        Viewport viewport = doc.GetElement(id) as Viewport;
                        if (viewport != null)
                        {
                            var legendId = viewport.ViewId;
                            if (listLegends.Exists(x => x.Id==legendId))
                            {
                                try
                                {
                                    using (Transaction t2 = new Transaction(doc, "Removelegend"))
                                    {
                                        t2.Start();
                                        doc.Delete(viewport.Id);
                                        t2.Commit();
                                    }
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                   
                }
                MessageBox.Show("Removing legend is finished");
            }

        }

        public string GetName()
        {
            return "LegendToView";
        }

        public List<Autodesk.Revit.DB.View> GetLegendCheked(Document doc)
        {
            List<Autodesk.Revit.DB.View> listLegendeChecked = new List<Autodesk.Revit.DB.View>();
            var itemView = AppPanelLegendToSheet.myFormLegendToSheet.listViewLegend.CheckedItems;
            var listLegendModel = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View))
                .Cast<Autodesk.Revit.DB.View>().Where(x => x.ViewType == ViewType.Legend);
            foreach (ListViewItem legend in itemView)
            {
                foreach (var item in listLegendModel)
                {
                    if (legend.Text == item.Name)
                    {
                        listLegendeChecked.Add(item);
                        break;
                    }
                }
            }
            return listLegendeChecked;
        }

        public List<ViewSheet> GetSheets(Document doc)
        {
            List<ViewSheet> listViewSheet = new List<ViewSheet>();
            var itemChecked = AppPanelLegendToSheet.myFormLegendToSheet.listViewSheet.CheckedItems;
            var listSheetModel = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>();
            foreach (ListViewItem item in itemChecked)
            {
                foreach (ViewSheet sheet in listSheetModel)
                {
                    if (sheet.SheetNumber == item.Text)
                    {
                        listViewSheet.Add(sheet);
                        break;
                    }
                }
            }
            return listViewSheet;
        }

        public bool GetLegendSimilar(Document doc, List<Autodesk.Revit.DB.View> listLegend, out ViewSheet sheetout)
        {
            ViewSheet sheetChecked = null;
            List<Autodesk.Revit.DB.View> listLegendSimilar = new List<Autodesk.Revit.DB.View>();
            var itemSheet = AppPanelLegendToSheet.myFormLegendToSheet.listViewSheetSimilar.CheckedItems;
            var listSheets = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>();
            foreach (ListViewItem item in itemSheet)
            {
                foreach (var sheet in listSheets)
                {
                    if (sheet.SheetNumber == item.Text)
                    {
                        sheetChecked = sheet;
                        break;
                    }
                }
            }
            sheetout = sheetChecked;
            if (sheetChecked == null)
            {
                TaskDialog.Show("Error", "You seclect a sheet similar");
                return false;
            }
            var listViewPortId = sheetChecked.GetAllViewports().ToList();
            foreach (var legend in listLegend)
            {
                foreach (var id in listViewPortId)
                {
                    Viewport viewPort = doc.GetElement(id) as Viewport;
                    if (viewPort.ViewId == legend.Id)
                    {
                        listLegendSimilar.Add(legend);
                        break;
                    }
                }
            }

            if (listLegendSimilar.Count() == listLegend.Count())
            {
                return true;
            }
            else
            {
                TaskDialog.Show("Error", "Legend must add sheet similar");
                return false;
            }
        }


    }
}
