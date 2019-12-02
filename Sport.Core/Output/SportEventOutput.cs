using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sport.Core.Output
{
    public class SportEventOutput
    {
        [Required]
        public string Id { get; set; }
        [StringLength(50, ErrorMessage = "The 50 is Maximal Charter for name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Date { get; set; }
        [Required]
        public string EventStatus { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = "Max price 50 €")]
        public string Price { get; set; }

    }
}
