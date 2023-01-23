using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class Report2DTO
    {
        public Report2DTO()
        {

        }

        public int TermID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int studentCount { get; set; }
        public List<Student> Students { get; set; }

    }
}
