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
using System.IO;

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
                FamilyInstance familyInstance = item as FamilyInstance;
                if (familyInstance != null)
                {
                    Family family = familyInstance.Symbol.Family;

                    Document familyDoc = doc.EditFamily(family);
                    if (familyDoc != null && familyDoc.IsFamilyDocument == true)
                    {
                        using (Transaction t = new Transaction(familyDoc, "Set material"))
                        {
                            t.Start();
                            // app.OpenAndActivateDocument(item.Name);
                            FamilyParameter oldParamter = null;
                            try
                            {
                                oldParamter = familyDoc.FamilyManager.AddParameter("Structural Material", BuiltInParameterGroup.PG_MATERIALS, ParameterType.Material, true);
                            }
                            catch
                            {
                                oldParamter= familyDoc.FamilyManager.GetParameters().Where(x => x.Definition.Name == "Structural Material").First();
                            }
                            if (m != null)
                            {
                                familyDoc.FamilyManager.Set(oldParamter, m.Id);
                            }
                            var listFamilyAll = new FilteredElementCollector(familyDoc).WhereElementIsNotElementType();
                            List<Element> listFamily = new List<Element>();
                            foreach (Element e in listFamilyAll)
                            {
                                Options option = new Options();
                                option.ComputeReferences = true;
                                GeometryElement geroElment = e.get_Geometry(option);
                                if (geroElment != null)
                                {
                                    listFamily.Add(e);
                                }
                            }
                            foreach (var f in listFamily)
                            {
                                // f.get_Parameter("")
                                try
                                {
                                    if (m != null)
                                    {
                                        var paramter = f.LookupParameter("Material");
                                        if (paramter != null)
                                        {
                                            familyDoc.FamilyManager.AssociateElementParameterToFamilyParameter(paramter, oldParamter);
                                            familyDoc.LoadFamily(doc, new FamilyOption());
                                        }

                                    }

                                }
                                catch (Exception ex)
                                {
                                    var msg = ex.Message;
                                }
                            }
                            t.Commit();
                        }
                        
                        

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
    class FamilyOption : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            return true;
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            overwriteParameterValues = true;
            source = FamilySource.Family;
            return true;

        }

        
    }

}
