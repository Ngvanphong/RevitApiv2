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
            List<ElementType> listType = new List<ElementType>();
            List<Category> listCategory = new List<Category>();
            foreach (ListViewItem item in listCategoryChecked)
            {
                var name = item.Text;               
                foreach (var el in AppPanelFilterElement.listAllElement)
                {
                    try
                    {
                        Category category = null;
                        category = el.Category;
                        if (category != null)
                        {
                            if (name == category.Name)
                            {
                                ElementType elmentTyp = app.ActiveUIDocument.Document.GetElement(el.GetTypeId()) as ElementType;
                                if(!listType.Exists(x=>x.FamilyName== elmentTyp.FamilyName && x.Name == elmentTyp.Name))
                                {
                                    listType.Add(elmentTyp);
                                }                               
                                if (!listCategory.Exists(x => x.Name == name))
                                {
                                    listCategory.Add(category);
                                }
                            }
                        }
                    }
                    catch { continue; }
                }
            }
            listType = listType.OrderBy(x => x.FamilyName).ToList();
            ////Load typeName
            AppPanelFilterElement.myFormFilterElement.listViewTypeName.Items.Clear();
            AppPanelFilterElement.listTypeOfCategory = listType;
            AppPanelFilterElement.listCategoryChecked = listCategory;
            foreach (var type in listType)
            {
                var name = type.FamilyName + "#@" + type.Name;
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
