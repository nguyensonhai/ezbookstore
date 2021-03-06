﻿using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ezbookstore.Models;

namespace ezbookstore.Controllers
{
    public class BookController : Controller
    {
        ISession session = SingletonSession.Session;
        // GET: Book
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            IList<Book> books;
            books = session.Query<Book>().ToList(); //  Querying to get all the books
            return View(books);
        }

        // GET: Book/Details/id
        public ActionResult Details(int id)
        {
            Book book = new Book();
            book = session.Query<Book>().Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Book book = new Book();     //  Creating a new instance of the Book
                book.Id = 115;
                book.Title = collection["Title"].ToString();
                book.Genre = collection["Genre"].ToString();
                book.Author = collection["Author"].ToString();
                book.Language = collection["Language"].ToString();
                book.Price = collection["Price"];

                // TODO: Add insert logic here

                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(book); //  Save the book in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Book/Edit/id
        public ActionResult Edit(int id)
        {
            Book book = new Book();
            book = session.Query<Book>().Where(b => b.Id == id).FirstOrDefault();
            ViewBag.SubmitAction = "Save";
            return View(book);
        }

        // POST: Book/Edit/id
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Book book = new Book();
                book = session.Query<Book>().Where(b => b.Id == id).FirstOrDefault();
                book.Title = collection["Title"].ToString();
                book.Genre = collection["Genre"].ToString();
                book.Author = collection["Author"].ToString();
                book.Language = collection["Language"].ToString();
                book.Price = collection["Price"];
                // TODO: Add insert logic here
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(book);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/id
        public ActionResult Delete(int id)
        {
            // Delete the book
            Book book = new Book();
            book = session.Query<Book>().Where(b => b.Id == id).FirstOrDefault();
            ViewBag.SubmitAction = "Confirm delete";
            return View("Edit", book);
        }

        // POST: Book/Delete/id
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Book book = session.Get<Book>(id);
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Delete(book);
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