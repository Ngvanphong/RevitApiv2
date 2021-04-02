using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace ProjectApiV3.FilterElementWpf
{
   public class CategoryUser
    {
        public string Name { set; get; }
        public ElementId Id { set; get; }

        public CategoryUser(Category ca)
        {
            Name = ca.Name;
            Id = ca.Id;
        }
    }
}
