using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgeRanger.WebApp.Models;
using AgeRanger.Services.Contracts;
using AgeRanger.DTO.Models;

namespace AgeRanger.WebApp.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IpersonService _ips;

        public PersonController(IpersonService ips)
        {
            _ips = ips;
        }
       
        // GET: Person
        public ActionResult Index(string searchString)
        {
            var pvm = GetList(searchString);
            return View(pvm);
        }
       
        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,Age")] PersonViewModel pvm)
        {
            if (ModelState.IsValid)
            {
            if  ( _ips.Insert(new PersonDto() {
                Age = pvm.Age,
                   FName = pvm.FName,
                   LName = pvm.LName
                }))
                return RedirectToAction("Index");
            }
            return View(pvm);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonViewModel personViewModel = GetPerson(id.Value);
            if (personViewModel == null)
            {
                return HttpNotFound();
            }
            return View(personViewModel);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,Age,AgeGroup")] PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_ips.Update(new PersonDto()
                {
                    Id = personViewModel.Id,
                    Age = personViewModel.Age,
                    FName = personViewModel.FName,
                    LName = personViewModel.LName
                }))
                    return RedirectToAction("Index");
            }
            return View(personViewModel);
        }

        #region Private Methods
        private IEnumerable<PersonViewModel> GetList(string searchString)
        {
            try
            {
                var str = string.IsNullOrEmpty(searchString) ? string.Empty : searchString;
                var list = _ips.GetList(str);
                List<PersonViewModel> pvm = new List<PersonViewModel>();
                foreach (var item in list)
                {
                    pvm.Add(new PersonViewModel() { Age = item.Age, Id = item.Id, FName = item.FName, LName = item.LName, AgeGroup = item.AgeGroup });
                }
                return pvm;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private PersonViewModel GetPerson(int Id)
        {
            var personDto = _ips.GetPerson(Id);
            return new PersonViewModel() { Id = personDto.Id, Age = personDto.Age, FName = personDto.FName, LName = personDto.LName };
        }
        #endregion
    }
}
