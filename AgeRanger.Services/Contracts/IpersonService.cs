using AgeRanger.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Services.Contracts
{
   public  interface IpersonService
    {
        List<PersonDto> GetList(string Fname);
        PersonDto GetPerson(int Id);
        bool Update(PersonDto personDto);
        bool Insert(PersonDto personDto);
        string AgeGroupNotFoundtext { get; set; }
    }
}
