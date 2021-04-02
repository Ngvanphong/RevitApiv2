﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ProjectApiV3.Helper;

namespace ProjectApiV3.FilterElementWpf
{
    public class UpdateValueParameterWpfHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UpdateInformation.UpdateElementTypeName(app.ActiveUIDocument.Document);
            var parameterChecked = AppPanelFilterWpf.myFormFilterElement.listViewParameter.SelectedItems;
            List<Element> listElementSe = new List<Element>();
            listElementSe = AppPanelFilterWpf.listElementName;
            List<string> valueParameteres = new List<string>();
            foreach (ParameterValue item in AppPanelFilterWpf.myFormFilterElement.listViewValueParameter.Items)
            {
                valueParameteres.Add(item.ParameterUser.Id.ToString()+item.Value);
            }
            foreach (ParameterUser pa in parameterChecked)
            {
                foreach (Element element in listElementSe)
                {
                    try
                    {
                        foreach (Parameter parae in element.Parameters)
                        {
                            
                            if (parae.Id == pa.Id)
                            {
                                string valuestring = ParameterRevit.ParameterToString(parae);
                                string value = parae.Id.ToString() + valuestring;
                                if (!valueParameteres.Exists(x => x == value))
                                {
                                    ParameterValue paraValue = new ParameterValue(pa, valuestring);
                                    AppPanelFilterWpf.myFormFilterElement.listViewValueParameter.Items.Add(paraValue);
                                }
                            }
                        }
                    }
                    catch { continue; }
                }
            }
           
        }

        public string GetName()
        {
            return "UpdateValueParameterWpf";
        }
    }
}