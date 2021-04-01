using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text.RegularExpressions;
using ProjectApiV3.Helper;
using System.Windows.Controls;

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
                using (Transaction t = new Transaction(doc, "CropViewPlan"))
                {
                    t.Start();
                    try
                    {
                        view.CropBox = box;
                        view.CropBoxVisible = true;
                        view.CropBoxActive = true;
                        t.Commit();
                        AppPanelCropView.listAllCrops.Remove(view.Name + " ID=" + view.Id.ToString());
                    }
                    catch
                    {
                        t.RollBack();
                        continue;
                    }

                }
            }
            ListView listViewWPF = AppPanelCropView.myFormCropView.FindName("listViewCrop") as ListView;
            listViewWPF.ItemsSource = null;
            listViewWPF.ItemsSource = AppPanelCropView.listAllCrops;
        }

        public string GetName()
        {
            return "CropView";
        }
        public List<ViewPlan> getViewChecked(Document doc, out ViewPlan viewSimilar)
        {           
            List<ViewPlan> listViewChecked = new List<ViewPlan>();
            List<ElementId> listElementId = new List<ElementId>();
            foreach(string item in AppPanelCropView.listAllCrops)
            {
                ElementId elementId = new ElementId(int.Parse(Regex.Split(item," ID=").Last()));
                var element = doc.GetElement(elementId) as ViewPlan;
                if (element != null)
                {
                    listViewChecked.Add(element);
                }
            }
            ListView listView = AppPanelCropView.myFormCropView.FindName("CropViewExample") as ListView;
            string name = listView.Items.GetItemAt(0).ToString();
            ElementId elementIdOrigin = new ElementId(int.Parse(Regex.Split(name, " ID=").Last()));
            viewSimilar = doc.GetElement(elementIdOrigin) as ViewPlan;
            return listViewChecked;
        }
    }
}
