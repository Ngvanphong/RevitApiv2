using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace MainProjectApi.ViewSheetAsign
{
    public class ViewToSheetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return "ViewToSheetHandlers";
        }
    }
}
