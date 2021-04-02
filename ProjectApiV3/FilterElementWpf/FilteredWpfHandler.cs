using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ProjectApiV3.Helper;

namespace ProjectApiV3.FilterElementWpf
{
    public class FilteredWpfHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<ElementId> listSelectIds = new List<ElementId>();
            List<Element> listElementAll = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().ToList();
            List<CategoryUser> listCategoryChecked = (from item in AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedItems as List<CategoryUser>
                                                      select item).ToList();
            List<ParameterUser> listParameterChecked= (from item in AppPanelFilterWpf.myFormFilterElement.listViewParameter.SelectedItems as List<ParameterUser>
                                                       select item).ToList();
            switch (AppPanelFilterWpf.numberButtonClick)
            {
                case 0:
                    foreach (var item in listElementAll)
                    {
                        try
                        {
                            foreach (var ca in listCategoryChecked)
                            {
                                if (item.Category.Id == ca.Id)
                                {
                                    listSelectIds.Add(item.Id);
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    break;
                case 1:
                    UpdateInformation.UpdateElementTypeName(doc);
                    listSelectIds.AddRange((from item in AppPanelFilterWpf.listElementName select item.Id));
                    break;
                case 2:
                    UpdateInformation.UpdateElementTypeName(doc);
                    List<string> listValuePa = new List<string>();
                    foreach (var viewItem in AppPanelFilterWpf.myFormFilterElement.listViewValueParameter.SelectedItems)
                    {
                        ParameterValue parameterValue = viewItem as ParameterValue;
                        listValuePa.Add(parameterValue.ParameterUser.Id.ToString()+parameterValue.Value);
                    }
                    foreach (var el in AppPanelFilterWpf.listElementName)
                    {
                        var parametes = el.Parameters;
                        int count = 0;
                        int countChecked = listParameterChecked.Count;
                        foreach (var pa in listParameterChecked)
                        {
                            foreach (Parameter paE in el.Parameters)
                            {
                                if (pa.Id == paE.Id)
                                {
                                    string valueString = ParameterRevit.ParameterToString(paE);
                                    string value = pa.Id.ToString() + valueString;
                                    if (listValuePa.Exists(x => x == value))
                                    {
                                        count = count + 1;
                                        break;
                                    }
                                }
                            }
                        }
                        if (countChecked == count)
                        {
                            listSelectIds.Add(el.Id);
                        }
                    }
                    break;

            }
            app.ActiveUIDocument.Selection.SetElementIds(listSelectIds);
        }

        public string GetName()
        {
            return "FilteredWpf";
        }

        public static class UpdateInformation
        {
            public static void UpdateElementTypeName(Document doc)
            {
                List<string> nameParameteres = new List<string>();
                var listCollection = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().ToList();
                List<CategoryUser> listCategoryChecked = (from item in AppPanelFilterWpf.myFormFilterElement.listViewCategory.SelectedItems as List<CategoryUser>
                                                          select item).ToList();
                List<CategoryType> listTypeChecked = (from item in AppPanelFilterWpf.myFormFilterElement.listViewElementType.SelectedItems as List<CategoryType>
                                                          select item).ToList();
                List<Element> listElemnetCa = new List<Element>();
                foreach (var cat in listCategoryChecked)
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
                foreach (var type in listTypeChecked)
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
            }
        }
    }
}
