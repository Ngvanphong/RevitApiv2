using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace ProjectApiV3.FilterElementWpf
{
   public class ParameterUser
    {
        public string Name { set; get; }
        public ElementId Id { set; get; }
        public ParameterUser(Parameter para)
        {
            Name = para.Definition.Name;
            Id = para.Id;
        }
    }
}
