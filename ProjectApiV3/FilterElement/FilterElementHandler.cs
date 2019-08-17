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
using ProjectApiV3.Helper;

namespace ProjectApiV3.FilterElement
{
    public class FilterElementHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<ElementId> listSelectIds = new List<ElementId>();
            List<Element> listElementAll = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements().ToList();
            switch (AppPanelFilterElement.numberButtonClick)
            {
                case 0:
                    foreach (var item in listElementAll)
                    {

                        try
                        {
                            string categoryName = item.Category.Name;
                            foreach (var ca in AppPanelFilterElement.listCategoryChecked)
                            {
                                if (categoryName == ca.Name)
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
                    foreach (var item in AppPanelFilterElement.listElementName)
                    {                       
                        listSelectIds.Add(item.Id);                       
                    }
                    break;
                case 2:
                    UpdateInformation.UpdateElementTypeName(doc);
                    List<string> listValuePa = new List<string>();
                    foreach (ListViewItem viewItem in AppPanelFilterElement.myFormFilterElement.listViewValueParameter.CheckedItems)
                    {
                        listValuePa.Add(viewItem.Text);
                    }
                    foreach (var el in AppPanelFilterElement.listElementName)
                    {
                        var parametes = el.Parameters;
                        int count = 0;
                        int countChecked = AppPanelFilterElement.listParameterChecked.Count;
                        foreach (var pa in AppPanelFilterElement.listParameterChecked)
                        {
                            foreach (Parameter paE in el.Parameters)
                            {
                                if (pa.Definition.Name == paE.Definition.Name)
                                {
                                    string valueString = ParameterRevit.ParameterToString(paE);
                                    string value = paE.Definition.Name + "#@" + valueString;
                                    if (listValuePa.Exists(x => x == value))
                                    {
                                        count = count + 1;
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
            return "FilterElement";
        }
      
       
    }
    public static class UpdateInformation
    {
        public static void UpdateElementTypeName(Document doc)
        {
            List<string> nameParameteres = new List<string>();
            var listCollection = new FilteredElementCollector(doc, doc.ActiveView.Id).ToElements().ToList();
            List<Element> listElemnetCa = new List<Element>();
            foreach (var cat in AppPanelFilterElement.listCategoryChecked)
            {
                foreach (var ele in listCollection)
                {
                    try
                    {
                        Category catss = null;
                        catss = ele.Category;
                        if (catss != null)
                        {
                            if (catss.Name == cat.Name)
                            {
                                listElemnetCa.Add(ele);
                            }
                        }
                    }
                    catch { continue; }
                }
            }
            List<Element> listElementSe = new List<Element>();
            foreach (var type in AppPanelFilterElement.listTypeChecked)
            {
                foreach (var fa in listElemnetCa)
                {
                    if (type.Name == fa.Name)
                    {
                        try
                        {
                            FamilyInstance faInctance = null;
                            faInctance = fa as FamilyInstance;
                            if (fa != null && faInctance.Symbol.FamilyName == type.FamilyName)
                            {
                                listElementSe.Add(faInctance);
                            }
                            if (faInctance == null)
                            {
                                listElementSe.Add(fa);
                            }
                        }
                        catch
                        {
                            listElementSe.Add(fa);
                            continue;
                        }
                    }
                }
            }
            AppPanelFilterElement.listElementName = listElementSe;
        }
    }
}
