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
    public class TypeNameCheckedWpfHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var listTypeChecked = AppPanelFilterWpf.myFormFilterElement.listViewElementType.SelectedItems;
            List<string> nameParameteres = new List<string>();
            var listCollection = new FilteredElementCollector(app.ActiveUIDocument.Document, app.ActiveUIDocument.Document.ActiveView.Id).WhereElementIsNotElementType().ToList();
            List<Element> listElemnetCa = new List<Element>();
            var listCategoryChecked = AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedItems;
            foreach (CategoryUser cat in listCategoryChecked)
            {
                foreach (var ele in listCollection)
                {
                    try
                    {
                        Category catss = null;
                        catss = ele.Category;
                        if (catss != null)
                        {
                            if (catss.Id == cat.Id)
                            {
                                listElemnetCa.Add(ele);
                            }
                        }

                    }
                    catch { continue; }
                }
            }
            List<Element> listElementSe = new List<Element>();
            foreach (CategoryType type in listTypeChecked)
            {
                foreach (var fa in listElemnetCa)
                {
                    try
                    {
                        if (type.Id == fa.GetTypeId())
                        {
                            listElementSe.Add(fa);
                        }
                    }
                    catch { continue; }
                }
            }
            AppPanelFilterWpf.listElementName = listElementSe;
            List<ParameterUser> listParameterUser = new List<ParameterUser>();
            foreach (var ele in listElementSe)
            {
                foreach (Parameter pa in ele.Parameters)
                {
                    if (!listParameterUser.Exists(x => x.Id == pa.Id))
                    {
                        ParameterUser paraUser = new ParameterUser(pa);
                        listParameterUser.Add(paraUser);
                    }                 
                }
            }
            listParameterUser= listParameterUser.OrderBy(x => x.Name).ToList();
            ObservableCollection<ParameterUser> observableParameterUser = new ObservableCollection<ParameterUser>();
            listParameterUser.ForEach(x => observableParameterUser.Add(x));
            AppPanelFilterWpf.myFormFilterElement.listViewParameter.ItemsSource = observableParameterUser;
        }

        public string GetName()
        {
            return "TypeNameCheckedWpf";
        }
    }
}
