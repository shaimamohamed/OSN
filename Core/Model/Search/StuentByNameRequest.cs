using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;



namespace Core.Model.Search
{
    
    public class StuentByNameRequest : BaseEntity
    {
        public StuentByNameRequest()
        {

        }
        [Required]
        public string StudentName { get; set; }
    }
}
