using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ProjectApiV3.FilterElementWpf
{
    public class CategoryCheckedWpfHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var listCategoryChecked = AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedItems;
            List<CategoryType> listType = new List<CategoryType>();
            List<Category> listCategory = new List<Category>();
            List<Element> listElementAll = new FilteredElementCollector(app.ActiveUIDocument.Document, app.ActiveUIDocument.Document.ActiveView.Id).WhereElementIsNotElementType().ToList();
            foreach (CategoryUser item in listCategoryChecked)
            {
                foreach (var el in listElementAll)
                {
                    try
                    {
                        Category category = null;
                        category = el.Category;
                        if (category != null)
                        {
                            if (item.Id == category.Id)
                            {
                                if (!listType.Exists(x=>x.Id==el.GetTypeId()))
                                {
                                    ElementType elementType = app.ActiveUIDocument.Document.GetElement(el.GetTypeId()) as ElementType;
                                    if(elementType!=null) listType.Add(new CategoryType(item, elementType));
                                } 
                            }
                        }
                    }
                    catch { continue; }
                }
            }
            listType = listType.OrderBy(x => x.CategoryUser.Name).ThenBy(x=>x.Name).ToList();
            ObservableCollection<CategoryType> observable = new ObservableCollection<CategoryType>();
            foreach (var type in listType)
            {
                observable.Add(type);
            }
            AppPanelFilterWpf.listTypeOfCategory = observable;
            AppPanelFilterWpf.myFormFilterElement.listViewElementType.ItemsSource = observable;
        }

        public string GetName()
        {
            return "WpfCategoryChecked";
        }
    }
}
