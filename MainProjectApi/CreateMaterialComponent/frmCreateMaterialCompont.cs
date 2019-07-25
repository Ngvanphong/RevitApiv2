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
        private CreateMaterialComponentHandler _handler;
        public frmCreateMaterialCompont(ExternalEvent myEvent, CreateMaterialComponentHandler handler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;
        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateMaterialComponent_Click(object sender, EventArgs e)
        {
            _myEvent.Raise();
        }
    }
}
