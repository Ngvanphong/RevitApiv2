using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Drawing;
using System.Windows.Media;
using System.Reflection;
namespace ProjectApiV3.Button
{
   public class ShowHideHeaderButton
    {
        public void ShowHideHeader(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "Grid&Level";
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
            Image img = ProjectApiV3.Properties.Resources.icons8_project_management_16;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("ShowHide", "ShowHide",
                Assembly.GetExecutingAssembly().Location, "ProjectApiV3.TrimGridLevel.ShowHideHeaderBinding")
            {
                ToolTip = "Show or hide header of grid and level",
                LongDescription = "Show or hide header of grid and level",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
