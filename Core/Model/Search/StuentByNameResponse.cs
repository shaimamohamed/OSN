using Core.Entities;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Model.Search
{
   

    public class StuentByNameResponse : BaseEntity
    {
        public StuentByNameResponse()
        {

        }

        public Student student { get; set; }
        public List<Parent> parents { get; set; }

    }
}
