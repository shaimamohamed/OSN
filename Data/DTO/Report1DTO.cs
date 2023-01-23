using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
    public class Report1DTO
    {
        public Report1DTO()
        {

        }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string mobile { get; set; }
        public string CurrentTermName { get; set; }
        public List<Parent> Parents { get; set; }

        public Student Student { get; set; }
        public Term Term { get; set; }
        public Subject Subjects { get; set; }
        public Marks Marks { get; set; }

    }
}
