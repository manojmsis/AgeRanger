using AgeRanger.DTO.Models;
using AgeRanger.Services.Contracts;
using AgeRanger.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AgeRanger.WebApp.Api
{
    public class PersonApiController : ApiController
    {
        private IpersonService _ips;
        public PersonApiController(IpersonService ips)
        {
            _ips = ips;
        }
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutPerson(int id, [FromBody] PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            try
            {
                var person = _ips.GetPerson(id);
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
          
            try
            {
                if (_ips.Update(new PersonDto()
                {
                    Id = personViewModel.Id,
                    Age = personViewModel.Age,
                    FName = personViewModel.FName,
                    LName = personViewModel.LName
                }))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}