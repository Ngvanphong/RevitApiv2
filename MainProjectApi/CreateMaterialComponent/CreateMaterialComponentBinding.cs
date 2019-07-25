using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
namespace MainProjectApi.CreateMaterialComponent
{
    [Transaction(TransactionMode.Manual)]
    public class CreateMaterialComponentBinding : IExternalCommand
    {
        public frmCreateMaterialCompont myForm;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;
            AppPanelMaterial.ShowCrateMaterial(uiApp);
            myForm = AppPanelMaterial.formCreateMaterial;
            var categories = doc.Settings.Categories;
            myForm.dropCategory.DisplayMember = "Text";
            myForm.dropCategory.ValueMember = "Value";
            foreach(var item in categories)
            {
                Category cate = item as Category;
                if(cate!=null) myForm.dropCategory.Items.Add(new { Text = cate.Name, Value = cate.Name });
            }
            var materials = new FilteredElementCollector(doc).OfClass(typeof(Material)).Cast<Material>();
            myForm.dropMaterial.DisplayMember = "Text";
            myForm.dropMaterial.ValueMember = "Value";
            foreach (var item in materials)
            {
                myForm.dropMaterial.Items.Add(new { Text = item.Name, Value = item.Name });
            }
            return Result.Succeeded;
        }
    }
}
