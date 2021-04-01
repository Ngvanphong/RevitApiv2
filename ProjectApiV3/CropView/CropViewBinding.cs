using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using ProjectApiV3.Helper;

namespace ProjectApiV3.CropView
{
    [Transaction(TransactionMode.Manual)]
    public class CropViewBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            //if (CheckAccess.CheckLicense() == true)
            //{
                AppPanelCropView.ShowFromCropView();
                           
            //}
            return Result.Succeeded;
        }
    }
    //public static class GetViewInfor
    //{
    //    public static void InformationForm(Document doc)
    //    {
    //        var listView = new FilteredElementCollector(doc).OfClass(typeof(ViewPlan)).Cast<ViewPlan>();
    //        foreach(var item in listView.OrderBy(x => x.ViewType + "/Name: " + x.Name))
    //        {
    //            var row = new string[] { item.ViewType + "/Name: " + item.Name };
    //            var lvi = new ListViewItem(row);
    //            lvi.Tag = lvi;
    //            AppPanelCropView.myFormCropView.listViewViewCrop.Items.Add(lvi);
    //        }
    //        foreach (var item in listView.OrderBy(x => x.ViewType + "/Name: " + x.Name))
    //        {
    //            var row = new string[] { item.ViewType + "/Name: " + item.Name };
    //            var lvi = new ListViewItem(row);
    //            lvi.Tag = lvi;
    //            AppPanelCropView.myFormCropView.listViewViewCropSimilar.Items.Add(lvi);
    //        }
    //    }
    //}
}
