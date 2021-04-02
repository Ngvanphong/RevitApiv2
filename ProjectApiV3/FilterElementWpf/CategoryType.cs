using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace ProjectApiV3.FilterElementWpf
{
   public class CategoryType
    {
        public CategoryUser CategoryUser { set; get; }

        public string Name { set; get; }

        public ElementId Id { set; get; }

        public CategoryType(CategoryUser cateUser,ElementType type)
        {
            CategoryUser = cateUser;
            Name = type.Name;
            Id = type.Id;
        }
    }
}
