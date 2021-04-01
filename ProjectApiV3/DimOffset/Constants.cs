using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApiV3.DimOffset
{
  public static class Constants
    {
        public static double MinimumDistance = double.Parse(AppPanelDimOffset.myFormDimOffset.txtMinimunDistanceDim.Text.ToString());

        public static  double TrasformDistance = double.Parse(AppPanelDimOffset.myFormDimOffset.textBoxOffsetTextDimX.Text.ToString())/ (0.3048 * 1000);

        public static double TrasformDistanceY = double.Parse(AppPanelDimOffset.myFormDimOffset.textBoxOffsetTextDimY.Text.ToString()) / (0.3048 * 1000);
    }
}
