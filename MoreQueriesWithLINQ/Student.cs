using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreQueriesWithLINQ
{
    public class Student
    {
        public int StudentId { get; internal set; }
        public string Name { get; internal set; }
        public int Marks { get; internal set; }
        public string Gender { get; internal set; }
        public List<string> Subjects { get; internal set; }
    }
}
