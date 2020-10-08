using System;
using System.Collections.Generic;
using System.Text;

namespace School.Dto.DomainModels
{
    public class Students
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public string DateOfBirth { get; set; }

        public List<StudentClass> StudentClasses { get; set; }
    }
}
