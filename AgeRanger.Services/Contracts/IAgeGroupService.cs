using AgeRanger.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Services.Contracts
{
    public interface IAgeGroupService
    {
        List<AgeGroupDto> GetAgeGroup();
    }
}
