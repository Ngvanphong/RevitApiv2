using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace ProjectApiV3.FilterElementWpf
{
    public class ParameterValue
    {
        public ParameterUser ParameterUser {set;get;}
        public string Value { set; get; }
        public ParameterValue(ParameterUser paraUer,string value)
        {
            ParameterUser = paraUer;
            Value = value;
        }
    }
}
