using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventSportAplicationCore.Models
{
    public class ViewModelEvent
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The 50 is Maximal Charter for name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> Date { get; set; }
        [Required]
        public string EventStatus { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = "Max price 50 €")]
        public string Price { get; set; }
        [Required]
        public string State_Delete { get; set; }
    }
}
