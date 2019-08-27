using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApiV3.RevisionCloud
{
    public class FilterRevisionCloudHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            AppPanelRevisionCloud.myFormRevisionCloud.listViewRevisionCloud.Items.Clear();
            var valueChoice = AppPanelRevisionCloud.myFormRevisionCloud.dropChooseFilterCloud.SelectedItem.ToString();
            if (valueChoice == Constants.haveSheet)
            {
                GetInforRevisionCloud.GetInforRevionCloud(doc, Constants.haveSheet);
            }
            else if (valueChoice == Constants.havenotSheet)
            {
                GetInforRevisionCloud.GetInforRevionCloud(doc, Constants.havenotSheet);
            }
            else
            {
                GetInforRevisionCloud.GetInforRevionCloud(doc, Constants.all);
            }

        }

        public string GetName()
        {
            return "FilterRevisionCloud";
        }
    }
}
