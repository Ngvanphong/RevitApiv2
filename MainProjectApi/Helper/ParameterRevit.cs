﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.IO;

namespace MainProjectApi.Helper
{
   public class ParameterRevit
    {
        UIApplication _uiApp;
        Document _doc;
        Application _app;
        public ParameterRevit(UIApplication uiApp)
        {
            _uiApp = uiApp;
            _doc = uiApp.ActiveUIDocument.Document;
            _app = uiApp.Application;
        }
        //Create parameter
        public void CreateParameterRevit(string groupName, string parameterName,BuiltInCategory category)
        {
            DefinitionFile definitionFile = _app.OpenSharedParameterFile();
            string path = Path.Combine(Environment.SystemDirectory, @"\Autodesk\ShareParameterArmo.txt");
            if (definitionFile == null)
            {
                StreamWriter stream = new StreamWriter(path);
                stream.Close();
                _app.SharedParametersFilename = path;
                definitionFile = _app.OpenSharedParameterFile();
            }
            using(Transaction t = new Transaction(_doc, "CreateParamater"))
            {
                t.Start();
                SetNewParamatertoInstance(definitionFile, BuiltInCategory.OST_GenericModel, groupName, parameterName);
                t.Commit();
            }
        }
        public bool SetNewParamatertoInstance(DefinitionFile definitionFile,BuiltInCategory category,string groupName,string parameter)
        {
           try
            {
                DefinitionGroups myGroups = definitionFile.Groups;
                DefinitionGroup myGroup = null;
                Definition myDefinition_ProductDate = null;
                foreach(var item in myGroups)
                {
                    if (item.Name == groupName)
                    {
                        myGroup = item;
                        myDefinition_ProductDate = item.Definitions.get_Item(parameter);
                        if (myDefinition_ProductDate == null)
                        {
                            ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions(parameter, ParameterType.Material);
                            myDefinition_ProductDate = myGroup.Definitions.Create(option);
                        }
                        break;

                    }
                }
                if (myGroup == null)
                {
                    myGroup = myGroups.Create(groupName);
                    ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions(parameter, ParameterType.Material);
                    myDefinition_ProductDate = myGroup.Definitions.Create(option);
                }
                CategorySet categorySet = _uiApp.Application.Create.NewCategorySet();
                Category myCategory = _uiApp.ActiveUIDocument.Document.Settings.Categories.get_Item(category);
                categorySet.Insert(myCategory);
                InstanceBinding instantBinding = _uiApp.Application.Create.NewInstanceBinding(categorySet);
                BindingMap bindingMap = _uiApp.ActiveUIDocument.Document.ParameterBindings;

                bool instanceBindOk = bindingMap.Insert(myDefinition_ProductDate, instantBinding, BuiltInParameterGroup.PG_MATERIALS);

                return instanceBindOk;

            }
            catch
            {
                return false;
            }
        }
    }
}
