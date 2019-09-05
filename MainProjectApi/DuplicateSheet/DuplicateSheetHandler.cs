using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Text.RegularExpressions;
using MainProjectApi.Helper;
using System.Windows.Forms;

namespace MainProjectApi.DuplicateSheet
{
    public class DuplicateSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<SheetView> listSheetView = new List<SheetView>();
            listSheetView = GetListSheetChecked(doc);
            string endNumber = AppPanelDuplicateSheet.myFormDuplicateSheet.textBoxEndNumber.Text;
            string endName = AppPanelDuplicateSheet.myFormDuplicateSheet.textBoxEndName.Text;
            foreach (var item in listSheetView)
            {
                try
                {
                    FamilyInstance titleblock = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                    .OfCategory(BuiltInCategory.OST_TitleBlocks).Cast<FamilyInstance>().First(q => q.OwnerViewId == item.Sheet.Id);
                    ViewSheet sheet = null;
                    using (Transaction t = new Transaction(doc, "DuplicateSheet"))
                    {
                        t.Start();
                        sheet = ViewSheet.Create(doc, titleblock.GetTypeId());

                        sheet.SheetNumber = CompareString(item.Sheet.SheetNumber, endNumber);
                        sheet.Name = CompareString(item.Sheet.Name, endName);
                        t.Commit();
                    }

                    using (Transaction t2 = new Transaction(doc, "DupicateView"))
                    {
                        t2.Start();
                        ViewDuplicateOption option = ViewDuplicateOption.WithDetailing;
                        if (AppPanelDuplicateSheet.myFormDuplicateSheet.radioButtonDuplicate.Checked)
                        {
                            option = ViewDuplicateOption.Duplicate;
                        }
                        else if (AppPanelDuplicateSheet.myFormDuplicateSheet.radioButtonDuplicateasdepending.Checked)
                        {
                            option = ViewDuplicateOption.AsDependent;
                        }

                        foreach (var view in item.ListView)
                        {
                            Autodesk.Revit.DB.View viewDuplicate = null;
                            ElementId id = view.Duplicate(option);
                            viewDuplicate = doc.GetElement(id) as Autodesk.Revit.DB.View;
                            //viewDuplicate.Name = CompareString(view.Name, endName);
                            Viewport viewPortOld = getViewPort(doc, item.Sheet, view.Id).ViewPortRe;
                            var location = viewPortOld.GetBoxCenter();
                            Viewport viewNew = Viewport.Create(doc, sheet.Id, viewDuplicate.Id, location);
                            viewNew.ChangeTypeId(viewPortOld.GetTypeId());
                        }
                        t2.Commit();
                    }
                    if (AppPanelDuplicateSheet.myFormDuplicateSheet.radioButtonLegendYes.Checked)
                    {
                        foreach (var legend in item.ListLegend)
                        {
                            using (Transaction t3 = new Transaction(doc, "AssignViewSheet"))
                            {
                                t3.Start();
                                Viewport legendOld = getViewPort(doc, item.Sheet, legend.Id).ViewPortRe;
                                var locationLegend = legendOld.GetBoxCenter();
                                Viewport legendNew = Viewport.Create(doc, sheet.Id, legend.Id, locationLegend);
                                legendNew.ChangeTypeId(legendOld.GetTypeId());
                                t3.Commit();
                            }
                        }
                    }
                    if (AppPanelDuplicateSheet.myFormDuplicateSheet.radioButtonScheduleYes.Checked)
                    {
                        foreach (var schedule in item.ListSchedule)
                        {
                            using (Transaction t4 = new Transaction(doc, "AssignSchedule"))
                            {
                                t4.Start();
                                ScheduleSheetInstance scheduleOld = getViewPort(doc, item.Sheet, schedule.Id).SheetSchedule;
                                var locationSchedule = scheduleOld.Point;
                                ScheduleSheetInstance scheduleNew = ScheduleSheetInstance.Create(doc, sheet.Id, schedule.Id, locationSchedule);
                                t4.Commit();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error: Sheet Number is existed");                 
                    break;
                }
                
                
            }

        }

        public string GetName()
        {
            return "DuplicateSheet";
        }

        public List<SheetView> GetListSheetChecked(Document doc)
        {
            List<SheetView> listResult = new List<SheetView>();
            var listItem = AppPanelDuplicateSheet.myFormDuplicateSheet.listViewSheet.CheckedItems;
            List<ViewSheet> listSheetAll = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().ToList();
            foreach (ListViewItem listView in listItem)
            {
                string sheetNumber = listView.Text;
                foreach (var sheet in listSheetAll)
                {
                    if (sheet.SheetNumber == sheetNumber)
                    {
                        SheetView sheetView = new SheetView();
                        sheetView.Sheet = sheet;
                        var allViewId = sheet.GetAllPlacedViews();
                        List<Autodesk.Revit.DB.View> listAllView = new List<Autodesk.Revit.DB.View>();
                        foreach (var item in allViewId)
                        {
                            Autodesk.Revit.DB.View viewItem = null;
                            viewItem = doc.GetElement(item) as Autodesk.Revit.DB.View;
                            if (viewItem != null) listAllView.Add(viewItem);
                        }
                        List<ViewSchedule> listSchedule = new List<ViewSchedule>();
                        List<Autodesk.Revit.DB.View> listLegend = new List<Autodesk.Revit.DB.View>();
                        List<Autodesk.Revit.DB.View> listViewSheet = new List<Autodesk.Revit.DB.View>();
                        foreach (var item in listAllView)
                        {
                          
                            if (item.ViewType == ViewType.Legend)
                            {
                                listLegend.Add(item);
                            }
                            else
                            {
                                listViewSheet.Add(item);
                            }
                        }
                        var viewSchedules = new FilteredElementCollector(doc, sheet.Id).OfClass(typeof(ScheduleSheetInstance)).Cast<ScheduleSheetInstance>();
                        foreach(var item in viewSchedules)
                        {
                            var id = item.ScheduleId;
                            ViewSchedule schedule = doc.GetElement(id) as ViewSchedule;
                            if (schedule.Name != Constant.NameScheduleRevisiion)
                            {
                                listSchedule.Add(schedule);
                            }                            
                        }
                        sheetView.ListView = listViewSheet;
                        sheetView.ListSchedule = listSchedule;
                        sheetView.ListLegend = listLegend;
                        listResult.Add(sheetView);
                    }
                }

            }
            return listResult;
        }

        public ViewPortShechule getViewPort(Document doc, ViewSheet sheet, ElementId idView)
        {
            ViewPortShechule result = new ViewPortShechule();
            var listScheduleSheet = new FilteredElementCollector(doc, sheet.Id).OfClass(typeof(ScheduleSheetInstance)).Cast<ScheduleSheetInstance>();
            foreach(var schedule in listScheduleSheet)
            {
                if (schedule.ScheduleId == idView)
                {
                    result.SheetSchedule = schedule;
                    return result;
                }
               
            }
            var viewPortIds = sheet.GetAllViewports();
            foreach (var id in viewPortIds)
            {
                    Viewport viewPort = doc.GetElement(id) as Viewport;
                    if (viewPort.ViewId == idView)
                    {
                        result.ViewPortRe = viewPort;
                        return result;
                    } 
            }
            
            return result;

        }
        public string CompareString(string origin, string end)
        {
            return origin + end;
        }
    }
    public class SheetView
    {
        public ViewSheet Sheet { set; get; }
        public List<Autodesk.Revit.DB.View> ListView { set; get; }
        public List<Autodesk.Revit.DB.View> ListLegend { set; get; }
        public List<ViewSchedule> ListSchedule { set; get; }
    }
    public class ViewPortShechule
    {
        public Viewport ViewPortRe { set; get; }
        public ScheduleSheetInstance SheetSchedule { get; set; }
    }
}
