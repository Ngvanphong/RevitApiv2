using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApiV3.DimOffset
{
    public class CancelDimOffsetHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
        
            UpdaterRegistry.UnregisterUpdater(AppPanelDimOffset._updater.GetUpdaterId());
        }

        public string GetName()
        {
            return "CancelDimOffset";
        }
    }
}
