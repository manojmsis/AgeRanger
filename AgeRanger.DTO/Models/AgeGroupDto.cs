using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.DTO.Models
{
   public class AgeGroupDto
    {
        public int Id { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string Description { get; set; }
    }
}
