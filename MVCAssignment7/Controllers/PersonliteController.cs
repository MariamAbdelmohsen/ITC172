using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAssignment7.Models;

namespace MVCAssignment7.Controllers
{
    public class PersonliteController : Controller
    {
        Community_AssistEntities db = new Community_AssistEntities();

        // GET: Personlite
        public ActionResult Index()
        {
            var peeps = from p in db.People
                        from a in p.PersonAddresses
                        from c in p.Contacts
                        where c.ContactTypeKey == 1
                        select new
                        {
                            p.PersonLastName,
                            p.PersonFirstName,
                            p.PersonEmail,
                            a.PersonAddressApt,
                            a.PersonAddressStreet,
                            a.PersonAddressCity,
                            a.PersonAddressState,
                            a.PersonAddressZip,
                            c.ContactNumber
                        };
            List<Personlite> personList = new List<Personlite>();

            foreach ( var pers in peeps)
            {
                Personlite pl = new Models.Personlite();
                pl.LastName = pers.PersonLastName;
                pl.FirstName = pers.PersonFirstName;
                pl.Email = pers.PersonEmail;
                pl.Apartment = pers.PersonAddressApt;
                pl.City = pers.PersonAddressCity;
                pl.State = pers.PersonAddressState;
                pl.Zipcode = pers.PersonAddressZip;
                pl.HomePhone = pers.ContactNumber;
                personList.Add(pl);
            }
            return View();
        }
    }
}