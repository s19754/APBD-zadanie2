using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter
{
    class StudentComparer : IEqualityComparer<Student>
    {
        

        public bool Equals(Student x, Student y)
        {
            return (x.Fname == y.Fname)
                && (x.Lname == y.Lname)
                && (x.IndexNumber == y.IndexNumber);
        }
        public int GetHashCode(Student obj)
        {
            return obj.IndexNumber.GetHashCode();
        }
    }
}
