using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Marks
    {
        public Marks()
        {

        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Study Year is Required")]
        public string StudyYear { get; set; }

        [Required(ErrorMessage = "Student is Required")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Subject is Required")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "term is Required")]
        public int TermId { get; set; }
        [Range(minimum:0,maximum:100,ErrorMessage ="Mark out of range 0 to 100")]
        public float Mark { get; set; }
        public bool IsAbsent { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Term Term { get; set; }
    }
}
