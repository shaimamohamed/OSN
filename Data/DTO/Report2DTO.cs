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

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int studentCount { get; set; }

    }
}
