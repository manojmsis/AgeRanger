using AgeRanger.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using AgeRanger.DTO.Models;
using AgeRanger.Models;
using System;

namespace AgeRanger.Services
{
  public  class PersonService : IpersonService
    {
        private AgeRangerContext _ageRangerContext;
        private string _ageGroupNotFoundtext;

        public PersonService(AgeRangerContext ageRangerContext )
        {
            _ageRangerContext = ageRangerContext;
        }
        public string AgeGroupNotFoundtext
        {
            get
            {
                return string.IsNullOrEmpty(_ageGroupNotFoundtext) ? "" : _ageGroupNotFoundtext;
            }

            set
            {
                _ageGroupNotFoundtext = value;
            }
        }

        public List<PersonDto> GetList(string name)
        {
            var people = _ageRangerContext.Persons.Where(
                x => string.IsNullOrEmpty(name)?true:(
                x.FirstName.ToLower().Contains(name.ToLower())
                || x.LastName.ToLower().Contains(name.ToLower())
                )
                ).ToList();
            List<PersonDto> list = new List<PersonDto>();
           
            foreach (var item in people)
            {
                var person = new PersonDto()
                {
                    Id=item.Id,
                    Age = item.Age,
                    LName = item.LastName,
                    FName = item.FirstName,
                    AgeGroup = GetAgeGroupDescription(item.Age)
                };
                list.Add(person);
            }
            return list;
        }

        public PersonDto GetPerson(int Id)
        {
            var person = _ageRangerContext.Persons.FirstOrDefault(x => x.Id == Id);
            if (person == null)
            {
                throw new KeyNotFoundException(string.Format("Person with ID  {0} is not available", Id));
            }
                var personDto = new PersonDto()
                {
                    Id = person.Id,
                    Age = person.Age,
                    LName = person.LastName,
                    FName = person.FirstName
                };
            return personDto;
        }

        public bool Insert(PersonDto personDto)
        {
            try
            {

           
            var person = new Person()
            {
                Age = personDto.Age,
                FirstName = personDto.FName,
                LastName = personDto.LName
            };
            _ageRangerContext.Persons.Add(person);
            _ageRangerContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(PersonDto personDto)
        {
            var dbPerson = _ageRangerContext.Persons.FirstOrDefault(x => x.Id == personDto.Id);
            dbPerson.Age = personDto.Age;
            dbPerson.FirstName = personDto.FName;
            dbPerson.LastName = personDto.LName;
            var outcome = _ageRangerContext.SaveChanges();
            return true;
        }

        private string GetAgeGroupDescription(int age)
        {
            var ageGroup = _ageRangerContext.AgeGroups.ToList();
            int maxMinAge = ageGroup.Max(x => x.MinAge).Value;
            int maxMaxAge = ageGroup.Max(x => x.MaxAge).Value;

            foreach (var item in ageGroup)
            {
                if (item.MaxAge.HasValue & (age < item.MaxAge.GetValueOrDefault()) || (item.MinAge.HasValue && item.MinAge.GetValueOrDefault() == age))
                {
                    if (item.MinAge.HasValue & age >= item.MinAge.GetValueOrDefault())
                    {
                        return item.Description;
                    }
                    else
                    {


                        return _ageGroupNotFoundtext;
                    }
                }
                else if (item.MinAge == maxMinAge)//last item max age might be null
                {
                    if ((maxMinAge >= maxMaxAge) & age >= maxMinAge)
                    {
                        return item.Description;
                    }
                }
            }
            return _ageGroupNotFoundtext;
        }
    }
}
