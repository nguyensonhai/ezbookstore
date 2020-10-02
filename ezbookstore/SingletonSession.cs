using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ezbookstore.Models;
using Castle.MicroKernel;
using Castle.Windsor;
namespace ezbookstore
{
    public class SingletonSession
    {
        private static ISession session;
        public static ISession Session
        {
            get
            {
                if (SingletonSession.session == null)
                {
                    SingletonSession.session = NHibernateSession.OpenSession();
                }
                return SingletonSession.session;
            }
        }
    }
}