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
            string sheetNumberStart = null;
            if(AppPenalAssignView.myFormAssignView.txtSheetNumber.Text != ""
                || string.IsNullOrEmpty(AppPenalAssignView.myFormAssignView.txtSheetNumber.Text) == false)
            {
                sheetNumberStart = numberSheet;
            }else
            {
                if (sheet.GetAllViewports().Count > 0)
                {
                    Viewport viewPortOld = null;
                    foreach (var port in sheet.GetAllViewports())
                    {
                        Viewport viewport = doc.GetElement(port) as Viewport;
                        Parameter parameter = viewport.LookupParameter("Crop View");
                        if (parameter != null)
                        {
                            viewPortOld = viewport;
                            break;
                        }
                    }
                    if (viewPortOld != null)
                    {
                        int end = int.Parse(Regex.Match(numberSheet, @"\d+").Value) + 1;
                        int countEnd = end.ToString().Length;
                        sheetNumberStart = numberSheet.Remove(numberSheet.Length - countEnd) + end.ToString();
                    }
                    else
                    {
                        sheetNumberStart = numberSheet;
                    }
                }
                else
                {
                    sheetNumberStart = numberSheet;
                }
            }            
            bool isBegin = true;
            bool cropBegin = true;
            bool isCreate = true;
            bool isExistView = false;
            XYZ locationPoint=null;
            Autodesk.Revit.DB.View viewMain = null;
            Viewport viewPortOldMain = null;
            List<ViewSectionBox> listBoudingBoxOld = new List<ViewSectionBox>();
            if (AppPenalAssignView.myFormAssignView.checkBoxFixPositionNotBox.Checked)
            {
                foreach(var item in listViewAssgin)
                {
                    ViewSectionBox sectionBox = new ViewSectionBox();
                    BoundingBoxXYZ box = new BoundingBoxXYZ();
                    box.Min = item.CropBox.Min;
                    box.Max = item.CropBox.Max;                  
                    sectionBox.BoudingBoxOld = box;
                    sectionBox.viewAssign = item;
                    listBoudingBoxOld.Add(sectionBox);
                }
            }

            if (AppPenalAssignView.myFormAssignView.checkBoxFixPosition.Checked
                ||AppPenalAssignView.myFormAssignView.checkBoxFixPositionNotBox.Checked)
            {
                foreach (var item in listViewAssgin)
                {
                    using (Transaction t1 = new Transaction(doc, "CropViewAssign"))
                    {
                        t1.Start();
                        if (cropBegin)
                        {
                            if (sheet.GetAllViewports().Count > 0)
                            {
                                var viewPortOldId = sheet.GetAllViewports();
                                foreach (var port in viewPortOldId)
                                {
                                    Viewport viewport = doc.GetElement(port) as Viewport;
                                    Parameter parameter = viewport.LookupParameter("Crop View");
                                    if (parameter != null)
                                    {
                                        viewPortOldMain = viewport;
                                        viewMain = doc.GetElement(viewport.ViewId) as Autodesk.Revit.DB.View;
                                        break;
                                    }
                                }
                                if (viewPortOldId != null)
                                {
                                    BoundingBoxXYZ box = new BoundingBoxXYZ();
                                    box.Min = viewMain.CropBox.Min;
                                    box.Max = viewMain.CropBox.Max;
                                    item.CropBox = box;
                                    item.CropBoxActive = true;
                                    item.CropBoxVisible = true;
                                    locationPoint = viewPortOldMain.GetBoxCenter();
                                }
                            }
                            cropBegin = false;
                        }
                        else if (viewMain != null)
                        {
                            BoundingBoxXYZ box = new BoundingBoxXYZ();
                            box.Min = viewMain.CropBox.Min;
                            box.Max = viewMain.CropBox.Max;
                            item.CropBox = box;
                            item.CropBoxActive = true;
                            item.CropBoxVisible = true;
                        }
                        t1.Commit();
                    }
                }
            }
            FamilyInstance titleblock = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks).Cast<FamilyInstance>().First(q => q.OwnerViewId == sheet.Id);
            foreach (var view in listViewAssgin)
            {                
                using (Transaction t = new Transaction(doc, "AssigntoSheet"))
                {
                    t.Start();
                    try
                    {               
                        if (isBegin)
                        {
                            if (sheet.GetAllViewports().Count > 0)
                            {
                                var viewPortOldId = sheet.GetAllViewports();                                                             
                                foreach (var port in viewPortOldId)
                                {
                                    Viewport viewport = doc.GetElement(port) as Viewport;
                                    Parameter parameter = viewport.LookupParameter("Crop View");
                                    if (parameter != null)
                                    {
                                        viewPortOldMain = viewport;                                     
                                        break;
                                    }
                                }
                                if (viewPortOldMain != null)
                                {
                                    isExistView = true;
                                    ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                                    viewSheet.SheetNumber = sheetNumberStart;
                                    viewSheet.ViewName = view.Name;
                                    if (AppPenalAssignView.myFormAssignView.checkBoxFixPosition.Checked==false
                                        && AppPenalAssignView.myFormAssignView.checkBoxFixPositionNotBox.Checked == false)
                                    {
                                        BoundingBoxXYZ newvpbb = titleblock.get_BoundingBox(sheet);
                                        XYZ newCenter = (newvpbb.Max + newvpbb.Min) / 2;
                                        locationPoint = newCenter;
                                    }                                   
                                    Viewport viewNew = Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                                    viewNew.ChangeTypeId(viewPortOldMain.GetTypeId());
                                }
                                else
                                {
                                    if (AppPenalAssignView.myFormAssignView.txtSheetNumber.Text != ""
                                    || string.IsNullOrEmpty(AppPenalAssignView.myFormAssignView.txtSheetNumber.Text) == false)
                                    {
                                        ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                                        viewSheet.SheetNumber = sheetNumberStart;
                                        viewSheet.ViewName = view.Name;
                                        BoundingBoxXYZ newvpbb = titleblock.get_BoundingBox(sheet);
                                        XYZ newCenter = (newvpbb.Max + newvpbb.Min) / 2;
                                        locationPoint = newCenter;
                                        Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                                    }
                                    else
                                    {
                                        sheet.ViewName = view.Name;
                                        BoundingBoxXYZ newvpbb = titleblock.get_BoundingBox(sheet);
                                        XYZ newCenter = (newvpbb.Max + newvpbb.Min) / 2;
                                        locationPoint = newCenter;
                                        Viewport.Create(doc, sheet.Id, view.Id, locationPoint);
                                        isCreate = false;
                                    }
                                }

                            }
                            else
                            {
                                if (AppPenalAssignView.myFormAssignView.txtSheetNumber.Text != ""
                                   || string.IsNullOrEmpty(AppPenalAssignView.myFormAssignView.txtSheetNumber.Text) == false)
                                {
                                    ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                                    viewSheet.SheetNumber = sheetNumberStart;
                                    viewSheet.ViewName = view.Name;
                                    BoundingBoxXYZ newvpbb = titleblock.get_BoundingBox(sheet);
                                    XYZ newCenter = (newvpbb.Max + newvpbb.Min) / 2;
                                    locationPoint = newCenter;
                                    Viewport viewNew = Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                                }
                                else
                                {
                                    sheet.ViewName = view.Name;
                                    BoundingBoxXYZ newvpbb = titleblock.get_BoundingBox(sheet);
                                    XYZ newCenter = (newvpbb.Max + newvpbb.Min) / 2;
                                    locationPoint = newCenter;
                                    Viewport viewNew = Viewport.Create(doc, sheet.Id, view.Id, locationPoint);
                                    isCreate = false;
                                }
                            }
                            isBegin = false;
                        }
                        else
                        {
                            if (isCreate == false)
                            {
                                int end2 = int.Parse(Regex.Match(sheetNumberStart, @"\d+").Value) + 1;
                                int countEnd2 = end2.ToString().Length;
                                string sheetNumberStart2 = numberSheet.Remove(sheetNumberStart.Length - countEnd2) + end2.ToString();
                                ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                                viewSheet.ViewName = view.Name;
                                viewSheet.SheetNumber = sheetNumberStart2;
                                Viewport viewNew = Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                                isCreate = true;
                            }
                            else
                            {
                                if (isExistView  &&(AppPenalAssignView.myFormAssignView.checkBoxFixPosition.Checked
                                    || AppPenalAssignView.myFormAssignView.checkBoxFixPositionNotBox.Checked))
                                {                                   
                                    ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                                    viewSheet.ViewName = view.Name;
                                    Viewport viewNew = Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                                    viewNew.ChangeTypeId(viewPortOldMain.GetTypeId());
                                }
                                else
                                {
                                    ViewSheet viewSheet = ViewSheet.Create(doc, titleblock.GetTypeId());
                                    viewSheet.ViewName = view.Name;
                                    Viewport viewNew = Viewport.Create(doc, viewSheet.Id, view.Id, locationPoint);
                                }                               
                            }
                        }
                        
                        RemoveViewAssigned(view);
                        t.Commit();

                    }
                    catch
                    {
                        TaskDialog.Show("Error", "Sheet Number is existed");
                        t.Commit();
                        break;
                    }                                                     
                }
            }
            if (AppPenalAssignView.myFormAssignView.checkBoxFixPositionNotBox.Checked)
            {
                foreach (var viewBox in listBoudingBoxOld)
                {
                    using(Transaction t3= new Transaction(doc, "notCropBox"))
                    {
                        t3.Start();
                        viewBox.viewAssign.CropBox = viewBox.BoudingBoxOld;
                        viewBox.viewAssign.CropBoxActive = true;
                        viewBox.viewAssign.CropBoxVisible = true;
                        t3.Commit();
                    }

                }
            }
            
            //Update form;
            AppPenalAssignView.myFormAssignView.listViewView.Items.Clear();
            AppPenalAssignView.myFormAssignView.listSheet.Items.Clear();
            GetViewInfor.UpdateFormInformation(doc);
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
                    var viewname = viewAdd.ViewType + "/Name: " + viewAdd.Name;
                    if (viewname == name)
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
            if (AppPenalAssignView.myFormAssignView.txtSheetNumber.Text != ""
                || string.IsNullOrEmpty(AppPenalAssignView.myFormAssignView.txtSheetNumber.Text)==false)
            {
                numberStart = AppPenalAssignView.myFormAssignView.txtSheetNumber.Text;
            }
            else
            {
                
                numberStart = viewSheet.SheetNumber;
            }
           
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

        public void RemoveViewAssigned(Autodesk.Revit.DB.View viewAssigned)
        {
            var listItem = AppPenalAssignView.myFormAssignView.listViewSelect.Items;
            string name = viewAssigned.ViewType + "/Name: " + viewAssigned.Name;
            foreach (ListViewItem item in listItem)
            {
                if(item.Text == name)
                {
                    AppPenalAssignView.myFormAssignView.listViewSelect.Items.Remove(item);
                }
            }
        }
    }
    public class ViewSectionBox
    {
      public BoundingBoxXYZ BoudingBoxOld;
      public Autodesk.Revit.DB.View viewAssign;
    }
}
