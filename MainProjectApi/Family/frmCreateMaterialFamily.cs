using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProjectApi.CreateMaterialFamily
{
    public partial class frmCreateMaterialFamily : Form
    {

        private ExternalEvent _myEvent;
        private CreateMaterialFamilyHandler _handler;
        public frmCreateMaterialFamily(ExternalEvent myEvent, CreateMaterialFamilyHandler handler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;
        }

        private void Category_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateMaterialFamily_Click(object sender, EventArgs e)
        {
            _myEvent.Raise();
        }

        private void frmCreateMaterialCompont_Load(object sender, EventArgs e)
        {

        }
    }
}
