using AgeRanger.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgeRanger.DTO.Models;
using AgeRanger.Models;

namespace AgeRanger.Services
{
    public class AgeGroupService : IAgeGroupService
    {
        private AgeRangerContext _ageRangerContext;

        public AgeGroupService(AgeRangerContext ageRangerContext)
        {
            _ageRangerContext = ageRangerContext;
        }
        public List<AgeGroupDto> GetAgeGroup()
        {
            var agegroups = _ageRangerContext.AgeGroups.ToList();
            List<AgeGroupDto> dto = new List<AgeGroupDto>();
            foreach (var agegroup in agegroups)
            {
                dto.Add(new AgeGroupDto() { Id = agegroup.Id, MinAge = agegroup.MinAge.Value, MaxAge = agegroup.MaxAge.Value, Description = agegroup.Description });
            }
            return dto;
        }

     

      
       
    }
}
