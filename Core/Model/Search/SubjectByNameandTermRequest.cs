using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;



namespace Core.Model.Search
{
    
    public class SubjectByNameandTermRequest : BaseEntity
    {
        public SubjectByNameandTermRequest()
        {

        }
        
        [Required]
        public int Student { get; set; }
        [Required]
        public int Term { get; set; }
        
    }
}
