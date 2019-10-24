using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectApiV3.DimOffset
{
    public partial class frmDimOffset : Form
    {
        private CancelDimOffsetHandler _cancelHandler;
        private ExternalEvent _cancelEvent;
        public frmDimOffset(ExternalEvent cancelEvent, CancelDimOffsetHandler cancelHandler)
        {
            InitializeComponent();
            _cancelEvent = cancelEvent;
            _cancelHandler = cancelHandler;
        }

        private void frmDimOffset_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDimOffsetCancel_Click(object sender, EventArgs e)
        {
            
            _cancelEvent.Raise();            
            this.Close();
        }

        private void txtMinimunDistanceDim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Constants.MinimumDistance = double.Parse(AppPanelDimOffset.myFormDimOffset.txtMinimunDistanceDim.Text.ToString());
            }catch { }
            
        }

        private void textBoxOffsetTextDimX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Constants.TrasformDistance = double.Parse(AppPanelDimOffset.myFormDimOffset.textBoxOffsetTextDimX.Text.ToString()) / (0.3048 * 1000);
            }
            catch { }
           
        }

        private void textBoxOffsetTextDimY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Constants.TrasformDistanceY = double.Parse(AppPanelDimOffset.myFormDimOffset.textBoxOffsetTextDimY.Text.ToString()) / (0.3048 * 1000);
            }
            catch { }
            
        }
    }
}
