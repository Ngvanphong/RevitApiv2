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

namespace MainProjectApi.CreateMaterialComponent
{
    public partial class frmCreateMaterialCompont : Form
    {

        private ExternalEvent _myEvent;
        private ExternalEvent _getInforEvent;
        private CreateMaterialComponentHandler _handler;
        private GetMaterialHandler _getInforhanler;
        public frmCreateMaterialCompont(ExternalEvent myEvent, CreateMaterialComponentHandler handler, ExternalEvent getInforEvent, GetMaterialHandler getInforhanler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;
            _getInforEvent = getInforEvent;
            _getInforhanler = getInforhanler;
        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateMaterialComponent_Click(object sender, EventArgs e)
        {
            _getInforEvent.Raise();
            _myEvent.Raise();
        }
    }
}
