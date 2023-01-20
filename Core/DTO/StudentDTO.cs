using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class StudentDTO
    {
        public StudentDTO()
        {

        }

        public int ID { get; set; }
        // ///////////// Student
        public int StudentName { get; set; }
        public string StudentGender { get; set; }
        public string StudentEmail { get; set; }
        public string StudentMobile { get; set; }
        public DateTime StudentDOB { get; set; }

        // ///////////// Parent
        public List<Parent> Parents { get; set; }

    }
}
