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
   public class Trim2DGridLevelButton
    {
        public void Trim2D(UIControlledApplication application)
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
            Image img = ProjectApiV3.Properties.Resources.iconfinder_application_sidebar_expand_25531;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("Extend2D", "Extend2D",
                Assembly.GetExecutingAssembly().Location, "ProjectApiV3.TrimGridLevel.Trim2DGridLevelBinding")
            {
                ToolTip = "Trim 2D grid and level",
                LongDescription = "Trim 2D grid and level",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            Image img2 = ProjectApiV3.Properties.Resources.iconfinder_application_side_expand_4965;
            ImageSource imgSrc2 = Helper.Extension.GetImageSource(img2);
            PushButtonData btnData2 = new PushButtonData("Extend3D", "Extend3D",
                Assembly.GetExecutingAssembly().Location, "ProjectApiV3.TrimGridLevel.Trim3DGridLevelBinding")
            {
                ToolTip = "Trim 3D grid and level",
                LongDescription = "Trim 3D grid and level",
                Image = imgSrc2,
                LargeImage = imgSrc2,
            };

            Image img3 = ProjectApiV3.Properties.Resources.icons8_project_management_16;
            ImageSource imgSrc3 = Helper.Extension.GetImageSource(img3);
            PushButtonData btnData3 = new PushButtonData("ShowHide", "ShowHide",
                Assembly.GetExecutingAssembly().Location, "ProjectApiV3.TrimGridLevel.ShowHideHeaderBinding")
            {
                ToolTip = "Show or hide header of grid and level",
                LongDescription = "Show or hide header of grid and level",
                Image = imgSrc3,
                LargeImage = imgSrc3,
            };

            SplitButtonData splitData = new SplitButtonData("Grid&Level", "Grid&Level");
            SplitButton splitButton = panel.AddItem(splitData) as SplitButton;
            splitButton.IsSynchronizedWithCurrentItem = true;
            splitButton.AddPushButton(btnData);
            splitButton.AddPushButton(btnData2);
            splitButton.AddPushButton(btnData3);
        }
    }
}
