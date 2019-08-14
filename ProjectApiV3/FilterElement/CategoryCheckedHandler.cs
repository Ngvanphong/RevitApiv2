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
namespace ProjectApiV3.FilterElement
{
   public class CategoryCheckedHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var listCategoryChecked = AppPanelFilterElement.myFormFilterElement.listViewCategory.CheckedItems;
            var listElementType = new FilteredElementCollector(app.ActiveUIDocument.Document).OfClass(typeof(ElementType)).Cast<ElementType>().OrderBy(x => x.Name);
            List<ElementType> listTypeChecked = new List<ElementType>();
           
            foreach (ListViewItem item in listCategoryChecked)
            {
                var name = item.Text;
                foreach (var ty in listElementType)
                {
                    try
                    {
                        Category category = null;
                        category = ty.Category;
                        if (category != null)
                        {
                            if (name == category.Name)
                            {
                                listTypeChecked.Add(ty);                               
                            }
                        }
                    }
                    catch { continue; }
                }
            }
            
            ////Load typeName
            AppPanelFilterElement.myFormFilterElement.listViewTypeName.Items.Clear();
            AppPanelFilterElement.listTypeOfCategory = listTypeChecked;
            foreach (var type in listTypeChecked)
            {
                var name = type.FamilyName + "/" + type.Name;
                var row = new string[] { name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelFilterElement.myFormFilterElement.listViewTypeName.Items.Add(lvi);
            }
        }

        public string GetName()
        {
            return "CategoryChecked";
        }
    }
}
