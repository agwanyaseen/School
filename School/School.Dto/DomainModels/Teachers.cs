using System;
using System.Collections.Generic;
using System.Text;

namespace School.Dto.DomainModels
{
    public class Teachers
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherPassword { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
