using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace ProjectApiV3.Revision
{
    public class ExportExcelHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            ExportExcel(app);
        }

        public string GetName()
        {
            return "ExportToExcel";
        }
        public void ExportExcel(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<ViewSheet> listSheet = new FilteredElementCollector(doc).OfClass(typeof(ViewSheet)).Cast<ViewSheet>().OrderBy(x => x.SheetNumber).ToList();
            List<DataExcel> dataExcel = new List<DataExcel>();
            foreach (var data in listSheet)
            {
                DataExcel excelItem = new DataExcel();
                excelItem.SheetNumber = data.SheetNumber.ToString();
                excelItem.SheetName = data.ViewName;
                List<ElementId> revisionIds = data.GetAllRevisionIds().ToList();
                string revisions = string.Empty;
                foreach (var id in revisionIds)
                {
                    var revision = doc.GetElement(id) as Autodesk.Revit.DB.Revision;
                    if (revisions == string.Empty)
                    {
                        revisions = revision.Name;
                    }
                    else
                    {
                        revisions = revisions + ";" + revision.Name;
                    }


                }
                excelItem.Revisions = revisions;
                dataExcel.Add(excelItem);
            }
            string name = doc.Title + "_revision.xlsx";
            string fullPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + name;
            FileInfo file = new FileInfo(fullPath);
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(fullPath);
            }
            using (ExcelPackage package = new ExcelPackage(file))
            {
                try
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Revisions");
                    worksheet.Cells["A1"].LoadFromCollection(dataExcel, true, TableStyles.Light1);
                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                }
                catch{}
            }
        }
    }
    public class DataExcel
    {
        public string SheetNumber { get; set; }
        public string SheetName { get; set; }
        public string Revisions { get; set; }
    }



}
