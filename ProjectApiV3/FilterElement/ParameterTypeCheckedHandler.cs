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
                foreach(var pare in AppPanelFilterElement.listParameter)
                {
                    if (pare.Definition.Name == parameterName)
                    {
                        elementParameterSelect.Add(pare);
                    }
                }              
            }
            List<Element> listElementSe = new List<Element>();
            listElementSe = AppPanelFilterElement.listElementName;
            AppPanelFilterElement.listParameterChecked = elementParameterSelect;
            AppPanelFilterElement.myFormFilterElement.listViewValueParameter.Items.Clear();
            List<string> valueParameteres = new List<string>();
            foreach (var pa in elementParameterSelect)
            {
                foreach (Element element in listElementSe)
                {
                    try
                    {                       
                        foreach (Parameter parae in element.Parameters)
                        {
                            string name = parae.Definition.Name;
                            if (name == pa.Definition.Name)
                            {                               
                                foreach(Parameter paE in element.Parameters)
                                {
                                    if (paE.Definition.Name == name)
                                    {
                                        string valuestring = ParameterRevit.ParameterToString(paE);
                                        string value = name + "#@" + valuestring;
                                        if (!valueParameteres.Exists(x => x == value))
                                        {
                                            valueParameteres.Add(value);
                                        }
                                    }
                                }                                
                            }
                        }
                    }
                    catch { continue; }
                }
            }
            foreach (var va in valueParameteres.OrderBy(x=>x))
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
