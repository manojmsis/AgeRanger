
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgeRanger.WebApp.Models
{
    public class PersonViewModel
    {
        //No need to use this, we can straight away use DTO, but to follow the standard we are using View model.
        //We use view models to generate the view, 
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string FName { get; set; }
        [MaxLength(40)]
        public string LName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }

        public string AgeGroup { get; set; }
        //to demonstrate the purpose of viewmodel
        public string FullName { get; set; }
    }
}