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
            //Document doc = app.ActiveUIDocument.Document;
            //ElementId idSelect = null;
            //try
            //{
            //    idSelect = app.ActiveUIDocument.Selection.GetElementIds().First();
            //}
            //catch
            //{
            //    MessageBox.Show("You must choose a view on sheet");
            //    return;
            //}
            //Viewport viewPortChoose = doc.GetElement(idSelect) as Viewport;
            //var viewMain = doc.GetElement(viewPortChoose.ViewId) as Autodesk.Revit.DB.View;
            //using(Transaction t6= new Transaction(doc, "Showline2"))
            //{
            //    t6.Start();
            //    viewMain.CropBoxActive = true;
            //    viewMain.CropBoxVisible = true;
            //    t6.Commit();
            //}
            //var locationPoint = viewPortChoose.GetBoxCenter();

            //List<Autodesk.Revit.DB.View> listViewSelect = GetViewChecked(doc);
            //List<ViewSheet> listSheetSelect = GetSheetChecked(doc);
            //if (listSheetSelect.Count != listViewSelect.Count)
            //{
            //    MessageBox.Show("You must choose count of sheets = count of views");
            //    return;
            //}
            //List<ViewSectionBox> listBoudingBoxOld = new List<ViewSectionBox>();
            //foreach (var item in listViewSelect)
            //{
            //    ViewSectionBox sectionBox = new ViewSectionBox();
            //    BoundingBoxXYZ box = new BoundingBoxXYZ();
            //    box.Min = item.CropBox.Min;
            //    box.Max = item.CropBox.Max;
            //    sectionBox.BoudingBoxOld = box;
            //    sectionBox.viewAssign = item;
            //    listBoudingBoxOld.Add(sectionBox);
            //}

            //for (int i = 0; i < listSheetSelect.Count; i++)
            //{
            //    using (Transaction t2 = new Transaction(doc, "AssignViewSheet2"))
            //    {
            //        t2.Start();
            //        ViewSheet sheet = listSheetSelect[i];
            //        Autodesk.Revit.DB.View view = listViewSelect[i];
            //        BoundingBoxXYZ box = new BoundingBoxXYZ();
            //        box.Min = viewMain.CropBox.Min;
            //        box.Max = viewMain.CropBox.Max;
            //        view.CropBox = box;
            //        view.CropBoxActive = true;
            //        view.CropBoxVisible = true;
            //        Viewport viewNew = Viewport.Create(doc, sheet.Id, view.Id, locationPoint);
            //        viewNew.ChangeTypeId(viewPortChoose.GetTypeId());                   
            //        t2.Commit();
            //    }
            //}
            //foreach (var viewBox in listBoudingBoxOld)
            //{
            //    using (Transaction t3 = new Transaction(doc, "notCropBox"))
            //    {
            //        t3.Start();
            //        viewBox.viewAssign.CropBox = viewBox.BoudingBoxOld;
            //        viewBox.viewAssign.CropBoxActive = true;
            //        viewBox.viewAssign.CropBoxVisible = true;
            //        t3.Commit();
            //    }
            //}
            //UpdateData(doc);
        }

        public string GetName()
        {
            return "ViewToSheetHandlers";
        }

        //public List<Autodesk.Revit.DB.View> GetViewChecked(Document doc)
        //{
        //    List<Autodesk.Revit.DB.View> listView = new List<Autodesk.Revit.DB.View>();
        //    var listItemView = AppPenalViewToSheet.myFormViewToSheet.listViewViewAssignTo.CheckedItems;
        //    var listAllView = new FilteredElementCollector(doc).OfClass(typeof(Autodesk.Revit.DB.View)).Cast<Autodesk.Revit.DB.View>();
        //    foreach (ListViewItem view in listItemView)
        //    {
        //        var name = view.Text;
        //        foreach (var viewAdd in listAllView)
        //        {
        //            var viewname = viewAdd.ViewType + "/Name: " + viewAdd.Name;
        //            if (viewname == name)
        //            {
        //                listView.Add(viewAdd);
        //            }
        //        }
        //    }
        //    return listView;
        //}

        //public List<ViewSheet> GetSheetChecked(Document doc)
        //{
        //    var listItemSheet = AppPenalViewToSheet.myFormViewToSheet.listViewSheetAssignView.CheckedItems;
        //    var listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>();
        //    List<ViewSheet> listViewSheetCheck = new List<ViewSheet>();
        //    foreach (ListViewItem item in listItemSheet)
        //    {
        //        var sheet = listSheet.Where(x => x.SheetNumber == item.Text).First();
        //        listViewSheetCheck.Add(sheet);
        //    }
        //    return listViewSheetCheck;
        //}
        //public void UpdateData(Document doc)
        //{
        //    AppPenalViewToSheet.myFormViewToSheet.listViewSheetAssignView.Items.Clear();
        //    AppPenalViewToSheet.myFormViewToSheet.listViewViewAssignTo.Items.Clear();
        //    InforViewSheet.UpdateFormInformation(doc);
        //}
    }
    public class ViewSectionBox
    {
        public BoundingBoxXYZ BoudingBoxOld;
        public Autodesk.Revit.DB.View viewAssign;
    }
}
