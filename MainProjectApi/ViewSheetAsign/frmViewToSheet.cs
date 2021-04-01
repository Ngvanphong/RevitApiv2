using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
namespace MainProjectApi.ViewSheetAsign
{
    public partial class frmViewToSheet : Form
    {
        private ViewToSheetHandler _handlerViewToSheet;
        private ExternalEvent _eventViewToSheet;
        public frmViewToSheet(ExternalEvent eventViewToSheet, ViewToSheetHandler handlerViewToSheet)
        {
            InitializeComponent();
            _eventViewToSheet = eventViewToSheet;
            _handlerViewToSheet = handlerViewToSheet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _eventViewToSheet.Raise();
        }

        private void frmViewToSheet_Load(object sender, EventArgs e)
        {

        }
    }
}
