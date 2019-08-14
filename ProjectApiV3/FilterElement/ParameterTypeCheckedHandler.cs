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
    public class ParameterTypeCheckedHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            var parameterChecked = AppPanelFilterElement.myFormFilterElement.listViewParameter.CheckedItems;
            List<Parameter> elementParameterSelect = new List<Parameter>();

            foreach (ListViewItem item in parameterChecked)
            {
                string parameterName = item.Text;
                foreach (var type in AppPanelFilterElement.listElementTypeChecked)
                {
                    var parameteres = type.Parameters;
                    foreach (Parameter par in parameteres)
                    {
                        if (par.Definition.Name == parameterName)
                        {
                            if (!elementParameterSelect.Exists(x => x.Definition.Name == par.Definition.Name))
                            {
                                elementParameterSelect.Add(par);
                            }

                        }
                    }
                }

            }
            List<Element> listElementSe = new List<Element>();
            var listCollection = new FilteredElementCollector(app.ActiveUIDocument.Document).WhereElementIsNotElementType().ToList();
            foreach (var type in AppPanelFilterElement.listElementTypeChecked)
            {
                foreach (var fa in listCollection)
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

            AppPanelFilterElement.listParameterChecked = elementParameterSelect;
            AppPanelFilterElement.myFormFilterElement.listViewValueParameter.Items.Clear();
            List<string> valueParameteres = new List<string>();

            foreach (var pa in elementParameterSelect)
            {
                foreach (Element element in listElementSe)
                {
                    try
                    {
                        ElementType elementType = app.ActiveUIDocument.Document.GetElement(element.GetTypeId()) as ElementType;
                        foreach (Parameter parae in elementType.Parameters)
                        {
                            string name = parae.Definition.Name;
                            if (name == pa.Definition.Name)
                            {
                                Parameter parameterEle = null;

                                parameterEle = element.LookupParameter(name);
                                if (parameterEle == null)
                                {
                                    FamilyInstance fains = element as FamilyInstance;
                                    fains.Symbol.LookupParameter(name);
                                }
                                string valuestring = ParameterRevit.ParameterToString(parae);
                                if (!valueParameteres.Exists(x => x == valuestring))
                                {
                                    valueParameteres.Add(valuestring);
                                }

                            }
                        }
                    }
                    catch { continue; }
                    
                }

            }
            foreach (var va in valueParameteres)
            {
                var row = new string[] { va };
                var lvi = new ListViewItem(row);
                lvi.Tag = lvi;
                AppPanelFilterElement.myFormFilterElement.listViewValueParameter.Items.Add(lvi);

            }
        }

        public string GetName()
        {
            return "Parametertypechecked";
        }
    }
}
