using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ezbookstore.Models;


namespace ezbookstore.Controllers
{
    public class MemberControllers : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            IList<Member> members;

            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                members = session.Query<Member>().ToList(); //  Querying to get all the books
            }

            return View(members);
        }
        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}