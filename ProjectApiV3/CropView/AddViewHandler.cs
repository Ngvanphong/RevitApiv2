using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Controls;


namespace ProjectApiV3.CropView
{
   public class  AddViewHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc = uiDoc.Document;
            if (AppPanelCropView.ChooseButton == 1)
            {
                var elementSelectIds = uiDoc.Selection.GetElementIds();
                List<string> listViewAddNew = new List<string>();
                foreach (ElementId elementId in elementSelectIds)
                {
                    Element ele = doc.GetElement(elementId);
                    if (ele.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Views)
                    {
                        listViewAddNew.Add(ele.Name + " ID=" + ele.Id.ToString());
                    }
                }
                if (listViewAddNew.Count == 0)
                {
                    TaskDialog.Show("Select View", "You must choose views");
                    return;
                }
                ListView listView = AppPanelCropView.myFormCropView.FindName("listViewCrop") as ListView;
                AppPanelCropView.listAllCrops.AddRange(listViewAddNew);
                listView.ItemsSource = null;
                listView.ItemsSource = AppPanelCropView.listAllCrops;
            }else if (AppPanelCropView.ChooseButton == 2)
            {
                ListView listView = AppPanelCropView.myFormCropView.FindName("listViewCrop") as ListView;      
                var itemsSelecions = listView.SelectedItems;
                foreach(var item in itemsSelecions)
                {
                    AppPanelCropView.listAllCrops.Remove(item.ToString());
                }
                listView.ItemsSource = null;
                listView.ItemsSource = AppPanelCropView.listAllCrops;

            }
            else if (AppPanelCropView.ChooseButton == 3)
            {
                var elementSelectIds = uiDoc.Selection.GetElementIds();
                List<string> listViewAddNew = new List<string>();
                foreach (ElementId elementId in elementSelectIds)
                {
                    Element ele = doc.GetElement(elementId);
                    if (ele.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Views)
                    {
                        listViewAddNew.Add(ele.Name + " ID=" + ele.Id.ToString());
                        break;
                    }
                }
                if (listViewAddNew.Count == 0)
                {
                    TaskDialog.Show("Select View", "You must choose a view");
                    return;
                }
                ListView listView = AppPanelCropView.myFormCropView.FindName("CropViewExample") as ListView;
                listView.ItemsSource = null;
                listView.ItemsSource = listViewAddNew;
            }            
        }
        public string GetName()
        {
            return "AddViewCrop";
        }
    }
}
