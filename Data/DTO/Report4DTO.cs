using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class Report4DTO
    {
        public Report4DTO()
        {

        }
        public int TermID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int StudentID { get; set; }
        public int studentCount { get; set; }
        public float score { get; set; }
        public bool isAbsent { get; set; }
        public Marks Marks { get; set; } //include student and parents
        public List<Student> Students { get; set; }
        public List<Parent> Parents { get; set; }

    }
}
