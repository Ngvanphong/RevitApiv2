using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Forms;
namespace MainProjectApi.DuplicateView
{
    public class DuplicateViewHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            int numberDuplicate = int.Parse(AppPenalDuplicateView.myFormDuplicateView.textBoxNumberDuplicate.Text);
            ElementId idSelect = null;
            try
            {
                idSelect = app.ActiveUIDocument.Selection.GetElementIds().First();
            }
            catch
            {
                MessageBox.Show("You must select a view");
                return;
            }
            Autodesk.Revit.DB.View viewChoose = doc.GetElement(idSelect) as Autodesk.Revit.DB.View;  
            using(Transaction t= new Transaction(doc, "DuplicateViewTra"))
            {
                t.Start();
                ViewDuplicateOption option = ViewDuplicateOption.WithDetailing;
                if (AppPenalDuplicateView.myFormDuplicateView.radioButtonDuplicateNormalView.Checked)
                {
                    option = ViewDuplicateOption.Duplicate;
                }
                else if (AppPenalDuplicateView.myFormDuplicateView.radioButtonDuplicateDependent.Checked)
                {
                    option = ViewDuplicateOption.AsDependent;
                }
                try
                {
                    for (int i = 0; i < numberDuplicate; i++)
                    {
                        Autodesk.Revit.DB.View viewDuplicate = null;
                        ElementId id = viewChoose.Duplicate(option);
                        viewDuplicate = doc.GetElement(id) as Autodesk.Revit.DB.View;
                    }
                }
                catch
                {
                    MessageBox.Show("Error: View cannot duplicate");
                    t.Commit();
                    return;
                }                              
                t.Commit();
            }
        }

        public string GetName()
        {
            return "DuplicateViewHandlers";
        }
    }
}
