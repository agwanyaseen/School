using System;
using System.Collections.Generic;
using System.Text;

namespace School.Dto.DomainModels
{
    public class Class
    {
        public int ClassId { get; set; }

        public int ClassTeacherId { get; set; }

        public int StandardId { get; set; }

        public int DivisionId { get; set; }

        public List<StudentClass> StudentsClass { get; set;}
    }
}
