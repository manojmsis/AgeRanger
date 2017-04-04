using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.DTO.Models
{
    public class PersonDto
    {
        //Add the validations at view models
        public int Id { get; set; }
      
        public string  FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string AgeGroup { get; set; }
        //public List<AgeGroupDto> AgeGroups { get; }
        //// public string AgeGroup
        // {
        //     get
        //     {
        //         return AgeGroups.OrderBy(x=>x.MinAge & x.MaxAge ).FirstOrDefault(aG => (aG.MinAge.HasValue & aG.MinAge >= Age) & (aG.MaxAge.Value < Age)).Description;
        //     }
        // }

    }
}
