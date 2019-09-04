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
using ProjectApiV3.Helper;
namespace ProjectApiV3.CropView
{
    public class CropViewHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ViewPlan viewChoice = null;
            List<ViewPlan> listView = getViewChecked(doc, out viewChoice);
            BoundingBoxXYZ box = new BoundingBoxXYZ();
            box.Min = viewChoice.CropBox.Min;
            box.Max = viewChoice.CropBox.Max;
            foreach (ViewPlan view in listView)
            {
                using (Transaction t= new Transaction(doc, "CropViewPlan"))
                {                   
                    t.Start();
                    try
                    {
                        view.CropBox = box;
                        view.CropBoxVisible = true;
                        view.CropBoxActive = true;
                       
                        //var choiceShare = viewChoice.GetCropRegionShapeManager();
                        //var bouding = choiceShare.GetAnnotationCropShape();
                        //var viewShare = view.GetCropRegionShapeManager();
                        //viewShare.SetCropShape(bouding);
                        t.Commit();
                    }
                    catch
                    {
                        t.Commit();
                        continue;

                    }
                    
                }
            }

        }

        public string GetName()
        {
            return "CropView";
        }
        public List<ViewPlan> getViewChecked(Document doc, out ViewPlan viewSimilar )
        {
            ViewPlan viewChoice = null;
            List<ViewPlan> listViewChecked = new List<ViewPlan>();
            var listItemView = AppPanelCropView.myFormCropView.listViewViewCrop.CheckedItems;
            var listAllView = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>();
            foreach ( ListViewItem view in listItemView)
            {
                var name = view.Text;
                foreach(var viewCheck in listAllView)
                {
                    var viewname = viewCheck.ViewType + "/Name: " + viewCheck.Name;
                    if (viewname == name)
                    {
                        listViewChecked.Add(viewCheck);
                    }
                }
            }
            var listItemChoose = AppPanelCropView.myFormCropView.listViewViewCropSimilar.CheckedItems;
            foreach (ListViewItem view in listItemChoose)
            {
                var name = view.Text;
                foreach (var viewsl in listAllView)
                {
                    var viewname = viewsl.ViewType + "/Name: " + viewsl.Name;
                    if (viewname == name)
                    {
                        viewChoice = viewsl;
                    }
                }
            }
            viewSimilar = viewChoice;
            return listViewChecked;
        }


    }
}
