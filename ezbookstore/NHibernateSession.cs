﻿using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ezbookstore
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var memberConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Member.hbm.xml");
            configuration.AddFile(memberConfigurationFile);
            var bookConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Book.hbm.xml");
            configuration.AddFile(bookConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}