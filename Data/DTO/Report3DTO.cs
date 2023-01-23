using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class Report3DTO
    {
        public Report3DTO()
        {

        }

        public int TermID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int studentCount { get; set; }
        //public float score { get; set; }
        public Marks Marks { get; set; } 
        public List<Student> Students { get; set; }
       public List<Parent> Parents { get; set; }

    }
}
