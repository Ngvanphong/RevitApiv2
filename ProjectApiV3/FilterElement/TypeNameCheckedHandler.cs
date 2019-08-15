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
    public class TypeNameCheckedHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var listTypeChecked = AppPanelFilterElement.myFormFilterElement.listViewTypeName.CheckedItems;
            List<ElementType> elementTypeSelect = new List<ElementType>();
            foreach (ListViewItem item in listTypeChecked)
            {
                
                string[] typeFa = Regex.Split(item.Text,"#@");
                string fami = typeFa[0];
                string nameType = typeFa[1];
                foreach (var type in AppPanelFilterElement.listTypeOfCategory)
                {
                    if (type.Name == nameType && type.FamilyName == fami)
                    {
                        if (!elementTypeSelect.Exists(x => x.Name==nameType && x.FamilyName == fami))
                        {
                            elementTypeSelect.Add(type);
                        }                       
                    }
                }
            }
            AppPanelFilterElement.listTypeChecked = elementTypeSelect;
            AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Clear();
            List<string> nameParameteres = new List<string>();
            var listCollection = AppPanelFilterElement.listAllElement;
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
            foreach (var type in elementTypeSelect)
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
            List<Parameter> listEleFa = new List<Parameter>();            
            foreach (var ele in listElementSe)
            {
                foreach (Parameter pa in ele.Parameters)
                {
                    string nameP = pa.Definition.Name;
                    if (!nameParameteres.Exists(x => x == nameP))
                    {
                        nameParameteres.Add(nameP);
                        listEleFa.Add(pa);
                    }
                }
            }
            AppPanelFilterElement.listParameter = listEleFa;
            foreach (var nameP in nameParameteres.OrderBy(x => x))
            {
                var name = nameP;
                var row = new string[] { name };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelFilterElement.myFormFilterElement.listViewParameter.Items.Add(lvi);
            }
        }

        public string GetName()
        {
            return "TypeNameChecked";
        }
    }
}
