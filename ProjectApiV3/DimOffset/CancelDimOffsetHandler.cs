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
            try
            {
                UpdaterRegistry.UnregisterUpdater(AppPanelDimOffset._updater.GetUpdaterId());
                AppPanelDimOffset._updater = null;
            }
            catch (Exception e) { AppPanelDimOffset._updater = null; }

        }

        public string GetName()
        {
            return "CancelDimOffset";
        }
    }
}
