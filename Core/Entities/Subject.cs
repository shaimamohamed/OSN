using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Subject
    {
        public Subject()
        {

        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Subject Name is Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TermID { get; set; }
        public Term Term { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
