using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Model.Search
{
   

    public class SubjectByNameandTermResponse : BaseEntity
    {
        public SubjectByNameandTermResponse()
        {

        }
        //public Student student { get; set; }
        //public Term term { get; set; }
        public List<Marks> marks { get; set; }


    }
}
