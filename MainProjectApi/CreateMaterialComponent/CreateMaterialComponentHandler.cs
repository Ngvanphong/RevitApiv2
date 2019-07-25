using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Threading;
using MainProjectApi.Helper;

namespace MainProjectApi.CreateMaterialComponent
{
    public class CreateMaterialComponentHandler : IExternalEventHandler
    {
        public frmCreateMaterialCompont myFormComponent;
        public void Execute(UIApplication app)
        {
            myFormComponent = AppPanelMaterial.formCreateMaterial;
            Document doc = app.ActiveUIDocument.Document;
            string categoryName = myFormComponent.dropCategory.GetItemText(myFormComponent.dropCategory.SelectedItem);
            Category category = null;
            foreach (var item in doc.Settings.Categories)
            {
                var cate = item as Category;
                if (cate != null)
                {
                    if (cate.Name == categoryName) category = cate;
                }
            }
            IList<Element> collection = app.ActiveUIDocument.Selection.PickElementsByRectangle(new SelectionFilterCategory(category));
            string materialName = myFormComponent.dropMaterial.GetItemText(myFormComponent.dropMaterial.SelectedItem);
            Material m = GetMaterialValue(doc, materialName);
            foreach (var item in collection)
            {
                using (Transaction t = new Transaction(doc, "Set material"))
                {
                    t.Start();
                    foreach (Parameter parameter in item.Parameters)
                    {
                        Definition definition = parameter.Definition;
                        // material is stored as element id
                       
                            if (definition.ParameterGroup == BuiltInParameterGroup.PG_MATERIALS &&definition.ParameterType == ParameterType.Material)
                            {
                                Autodesk.Revit.DB.Material material = null;
                                Autodesk.Revit.DB.ElementId materialId = parameter.AsElementId();
                                if (-1 == materialId.IntegerValue)
                                {
                                    //Invalid ElementId, assume the material is "By Category"
                                    if (null != item.Category)
                                    {
                                        material = item.Category.Material;
                                    }
                                }
                                else
                                {
                                    material = doc.GetElement(materialId) as Material;
                                }

                                TaskDialog.Show("Revit", "Element material: " + material.Name);
                                break;
                            }
                     
                        t.Commit();
                    }
                }
            }
        }

        public string GetName()
        {
            return "Assign material";
        }
        public Material GetMaterialValue(Document doc, string matName)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Material mat = null;
            var materials = collector.WherePasses(new ElementClassFilter(typeof(Material))).Cast<Material>();
            foreach (Material m in materials)
            {
                if (m.Name == matName)
                {
                    mat = m;
                    break;
                }
            }

            return mat;
        }


    }
}
