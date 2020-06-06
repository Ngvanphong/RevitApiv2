using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectApiV3.Button
{
   public class RevisionCloudButton
    {
        public void CreateRevisionCloud(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "View&Sheet";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch (Exception ex) { }
            RibbonPanel panel = null;
            List<RibbonPanel> panels = application.GetRibbonPanels(ribbonTag);
            foreach (RibbonPanel pl in panels)
            {
                if (pl.Name == ribbonPanel)
                {
                    panel = pl;
                    break;
                }
            }
            if (panel == null)
            {
                panel = application.CreateRibbonPanel(ribbonTag, ribbonPanel);
            }
            Image img = ProjectApiV3.Properties.Resources.cloud_computing;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("RevisionCloud", "RevisionCloud",
                Assembly.GetExecutingAssembly().Location, "ProjectApiV3.RevisionCloud.RevisionCloudBinding")
            {
                ToolTip = "Revision cloud",
                LongDescription = "Revision cloud",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
