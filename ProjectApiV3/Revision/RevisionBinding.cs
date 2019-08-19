using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using ProjectApiV3.Helper;

namespace ProjectApiV3.Revision
{
    [Transaction(TransactionMode.Manual)]
    public class RevisionBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            if (CheckAccess.CheckLicense() == true)
            {
                AppPanelRevision.ShowFormRevision();              
            }
            return Result.Succeeded;
        }
    }
}
