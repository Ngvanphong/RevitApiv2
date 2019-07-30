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

namespace MainProjectApi.AssignView
{
    public class AssignViewHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ViewSheet sheet = null;
            string numberSheet = null;
            List<Autodesk.Revit.DB.View> listViewAssgin = null;
            listViewAssgin = GetCheckedSheetAndView(doc, out sheet,out numberSheet);
            int sheetDuplicate = 0;
            string sheetNumberStart = null;
            if (sheet.GetAllViewports().Count > 0)
            {
                int end = int.Parse(Regex.Match(numberSheet, @"\d+").Value)+1;
                int countEnd = end.ToString().Length;
                sheetNumberStart = numberSheet.Remove(numberSheet.Length - countEnd) + end.ToString();
                sheetDuplicate = listViewAssgin.Count();
            }
            else
            {
                sheetDuplicate = listViewAssgin.Count() - 1;
                sheetNumberStart = numberSheet;                
            }
            bool isBegin = true;
            XYZ locationPoint=null;
            foreach(var view in listViewAssgin)
            {
                using (Transaction t = new Transaction(doc, "AssigntoSheet"))
                {
                    t.Start();
                    FamilyInstance titleblock = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks).Cast<FamilyInstance>().First(q => q.OwnerViewId == sheet.Id);
                    if (isBegin)
                    {
                        if (sheet.GetAllViewports().Count > 0)
                        {
                            ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                            viewSheet.SheetNumber = sheetNumberStart;
                            viewSheet.ViewName = view.Name;
                            var viewPortOldId = sheet.GetAllViewports();
                            Viewport viewPortOld=null;
                            Autodesk.Revit.DB.View viewMain = null;
                            foreach (var port in viewPortOldId)
                            {
                                Viewport viewport = doc.GetElement(port) as Viewport;
                                Parameter parameter = viewport.LookupParameter("Crop View");
                                if (parameter != null)
                                {
                                    viewPortOld = viewport;
                                    viewMain = doc.GetElement(viewport.ViewId) as Autodesk.Revit.DB.View;
                                    break;
                                }
                            }
                            if (viewPortOld != null)
                            {
                                BoundingBoxXYZ box = new BoundingBoxXYZ();
                                box.Min = viewMain.CropBox.Min;
                                box.Max = viewMain.CropBox.Max;
                                view.CropBox = box;
                                view.CropBoxActive = true;
                                view.CropBoxVisible = true;
                                locationPoint = viewPortOld.GetBoxCenter();
                                Viewport viewNew = Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                            }
                            else
                            {

                            }                      
                            
                        }
                        else
                        {                           
                            //BoundingBoxXYZ newvpbb =sheet.get_BoundingBox(sheet);
                            //XYZ newCenter = (newvpbb.Max + newvpbb.Min) / 2;
                            //Viewport.Create(doc, sheet.Id, view.Id, newCenter);
                            //locationPoint = newCenter;
                        }

                    }
                    else
                    {

                        ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                        viewSheet.ViewName = view.Name;
                        Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                    }                    
                    isBegin = false;
                    t.Commit();
                }
            }
        }

        public string GetName()
        {
            return "AssignViewToSheet";
        }
        public List<Autodesk.Revit.DB.View> GetCheckedSheetAndView(Document doc, out ViewSheet viewSheet, out string numberStart)
        {
            ViewSheet sheetSelect=null;
            List<Autodesk.Revit.DB.View> listView = new List<Autodesk.Revit.DB.View>();
            var listItemView = AppPenalAssignView.myFormAssignView.listViewSelect.Items;
            var listAllView = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).Cast<Autodesk.Revit.DB.View>();
            foreach (ListViewItem view in listItemView)
            {
                var name = view.Text;
                foreach (var viewAdd in listAllView)
                {
                    if (viewAdd.Name == name)
                    {
                        listView.Add(viewAdd);
                    }
                }
            }

            var listItemSheet = AppPenalAssignView.myFormAssignView.listSheet.CheckedItems;
            var listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>();
            foreach (ListViewItem item in listItemSheet)
            {
                var sheet = listSheet.Where(x=>x.SheetNumber==item.Text).First();               
                sheetSelect = sheet;
                break;             
            }
            viewSheet = sheetSelect;
            if (viewSheet == null)
            {
                viewSheet = listSheet.OrderByDescending(x => x.SheetNumber).First();
            }
            List<ViewSheet> listViewSheetCheck =new List<ViewSheet>();
            foreach (var item in listSheet)
            {
                listViewSheetCheck.Add(item);
            }
            numberStart = FindNumberMaxSheet(listViewSheetCheck, viewSheet);
            return listView;
        }
        public string FindNumberMaxSheet(List<ViewSheet> listViewSheet,ViewSheet sheet)
        {
            string sheetNumberMax = null;
            string sheetNumberNow = sheet.SheetNumber;
            int lengthNumber = sheetNumberNow.Length;
            string start = Regex.Replace(sheetNumberNow, @"[\d-]", string.Empty);
            int end = int.Parse(Regex.Match(sheetNumberNow, @"\d+").Value);
            int endMax = 0;
            foreach(var item in listViewSheet)
            {
                int lengthItem = item.SheetNumber.Length;
                string startItem = Regex.Replace(item.SheetNumber, @"[\d-]", string.Empty);
                if (lengthItem == lengthNumber && startItem == start)
                {
                    int endItem = int.Parse(Regex.Match(item.SheetNumber, @"\d+").Value);
                    if (endItem > endMax)
                    {
                        endMax = endItem;
                    }
                }
            }
            int countEnd = endMax.ToString().Length;
            sheetNumberMax = sheetNumberNow.Remove(lengthNumber-countEnd) + endMax.ToString();
            return sheetNumberMax;
            
        }
    }
}
