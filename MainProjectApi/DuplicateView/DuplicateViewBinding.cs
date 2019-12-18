using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
namespace MainProjectApi.DuplicateView
{
    [Transaction(TransactionMode.Manual)]
    public class DuplicateViewBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AppPenalDuplicateView.ShowDuplicateForm();
            return Result.Succeeded;
        }
    }
}
