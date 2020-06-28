using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Controls;
using System.Windows;

namespace MainProjectApi.ViewSheetAsign
{
    public class ViewToSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            if (AppPenalViewToSheet.ViewportOrigin == null)
            {
                MessageBox.Show("You must choose a Viewport");
                return;
            }
            Viewport viewPortChoose = AppPenalViewToSheet.ViewportOrigin;
            var viewMain = doc.GetElement(viewPortChoose.ViewId) as Autodesk.Revit.DB.View;
            using (Transaction t6 = new Transaction(doc, "Showline2"))
            {
                t6.Start();
                viewMain.CropBoxActive = true;
                viewMain.CropBoxVisible = true;
                t6.Commit();
            }
            var locationPoint = viewPortChoose.GetBoxCenter();

            List<Autodesk.Revit.DB.View> listViewSelect = GetViewChecked(doc);
            List<ViewSheet> listSheetSelect = GetSheetChecked(doc);
            if (listSheetSelect.Count != listViewSelect.Count)
            {
                MessageBox.Show("You must choose count of sheets = count of views");
                return;
            }
            List<ViewSectionBox> listBoudingBoxOld = new List<ViewSectionBox>();
            foreach (var item in listViewSelect)
            {
                ViewSectionBox sectionBox = new ViewSectionBox();
                BoundingBoxXYZ box = new BoundingBoxXYZ();
                box.Min = item.CropBox.Min;
                box.Max = item.CropBox.Max;
                sectionBox.BoudingBoxOld = box;
                sectionBox.viewAssign = item;
                listBoudingBoxOld.Add(sectionBox);
            }

            for (int i = 0; i < listSheetSelect.Count; i++)
            {
                using (Transaction t2 = new Transaction(doc, "AssignViewSheet2"))
                {
                    t2.Start();
                    ViewSheet sheet = listSheetSelect[i];
                    Autodesk.Revit.DB.View view = listViewSelect[i];
                    BoundingBoxXYZ box = new BoundingBoxXYZ();
                    box.Min = viewMain.CropBox.Min;
                    box.Max = viewMain.CropBox.Max;
                    view.CropBox = box;
                    view.CropBoxActive = true;
                    view.CropBoxVisible = true;
                    Viewport viewNew = Viewport.Create(doc, sheet.Id, view.Id, locationPoint);
                    viewNew.ChangeTypeId(viewPortChoose.GetTypeId());
                    t2.Commit();
                }
            }
            foreach (var viewBox in listBoudingBoxOld)
            {
                using (Transaction t3 = new Transaction(doc, "notCropBox"))
                {
                    t3.Start();
                    viewBox.viewAssign.CropBox = viewBox.BoudingBoxOld;
                    viewBox.viewAssign.CropBoxActive = true;
                    viewBox.viewAssign.CropBoxVisible = true;
                    t3.Commit();
                }
            }
            AppPenalViewToSheet.AllViewAssigns = null;
            var listViewWpf = AppPenalViewToSheet.myFormViewToSheet.FindName("lvViewSelect") as ListView;
            listViewWpf.ItemsSource = AppPenalViewToSheet.AllViewAssigns;
        }

        public string GetName()
        {
            return "ViewToSheetHandlers";
        }

        public List<Autodesk.Revit.DB.View> GetViewChecked(Document doc)
        {
            List<Autodesk.Revit.DB.View> listView = new List<Autodesk.Revit.DB.View>();
            foreach (var item  in AppPenalViewToSheet.AllViewAssigns)
            {
                Autodesk.Revit.DB.View view = doc.GetElement(new ElementId(int.Parse(item.Id))) as Autodesk.Revit.DB.View;
                listView.Add(view);
            }
            return listView;
        }

        public List<ViewSheet> GetSheetChecked(Document doc)
        {
            ListView listItemSheet = AppPenalViewToSheet.myFormViewToSheet.FindName("lvSheet") as ListView;
            var listSheetChecked = listItemSheet.SelectedItems ;
            var listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>();
            List<ViewSheet> listViewSheetCheck = new List<ViewSheet>();
            foreach (var itemWpf in listSheetChecked)
            {
                SheetInfor item = itemWpf as SheetInfor;
                var sheet = listSheet.Where(x => x.SheetNumber == item.SheetNumber).First();
                listViewSheetCheck.Add(sheet);
            }
            return listViewSheetCheck;
        }
        
    }
    public class ViewSectionBox
    {
        public BoundingBoxXYZ BoudingBoxOld;
        public Autodesk.Revit.DB.View viewAssign;
    }
}
