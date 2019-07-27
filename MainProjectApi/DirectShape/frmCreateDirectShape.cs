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

namespace MainProjectApi.DirectShape
{
    public partial class frmCreateDirectShape : Form
    {
        private ExternalEvent _myEvent;
        private CreateDirectShapeHandler _handler;
        public frmCreateDirectShape(ExternalEvent myEvent, CreateDirectShapeHandler handler)
        {
            InitializeComponent();
            _myEvent = myEvent;
            _handler = handler;
        }

        private void frmCreateDirectShape_Load(object sender, EventArgs e)
        {

        }

        private void dataGridPointImport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
