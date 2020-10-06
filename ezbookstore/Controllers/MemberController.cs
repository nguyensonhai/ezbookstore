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
    public class MemberController : Controller
    {
        ISession session = SingletonSession.Session;
        // GET: Member
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            IList<Member> members;
             members = session.Query<Member>().ToList(); //  Querying to get all the members
            return View(members);
        }
        // GET: Member/Details/id
        public ActionResult Details(int id)
        {
            Member member = new Member();
            member = session.Query<Member>().Where(b => b.Id == id).FirstOrDefault();
            return View(member);
        }
        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Member member = new Member();     //  Creating a new instance of the member
                member.Id = 115;
                member.FirstName = collection["FirstName"].ToString();
                member.LastName = collection["LastName"].ToString();
                member.DateOfBirth = Convert.ToDateTime(collection["DateOfBirth"].ToString()); 
                member.Phone = int.Parse(collection["Phone"].ToString());
                member.Email = collection["Email"];
                member.Address = collection["Address"].ToString();
                member.DateJoined = Convert.ToDateTime(collection["DateJoined"].ToString());

                // TODO: Add insert logic here
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(member); //  Save the member in session
                    transaction.Commit();   //  Commit the changes to the database
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Member/Edit/id
        public ActionResult Edit(int id)
        {
            Member member = new Member();
            member = session.Query<Member>().Where(b => b.Id == id).FirstOrDefault();
            ViewBag.SubmitAction = "Save";
            return View(member);
        }

        // POST: Member/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Member member = new Member();
                member = session.Query<Member>().Where(b => b.Id == id).FirstOrDefault();
                member.FirstName = collection["FirstName"].ToString();
                member.LastName = collection["LastName"].ToString();
                member.DateOfBirth = Convert.ToDateTime(collection["DateOfBirth"].ToString());
                member.Phone = int.Parse(collection["Phone"].ToString());
                member.Email = collection["Email"];
                member.Address = collection["Address"].ToString();
                member.DateJoined = Convert.ToDateTime(collection["DateJoined"].ToString());
                // TODO: Add insert logic here
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(member);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Member/Delete/id
        public ActionResult Delete(int id)
        {
            // Delete the member
            Member member = new Member();
            member = session.Query<Member>().Where(b => b.Id == id).FirstOrDefault();
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", member);
        }

        // POST: Member/Delete/id
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Member member = session.Get<Member>(id);
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Delete(member);
                    trans.Commit();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}