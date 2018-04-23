using NHibernate;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using System;
using System.IO;
using EniWine.Core.Repositories.Tools;
using FluentNHibernate.Automapping;
using EniWine.Investigation.Models;

namespace EniWine.Core.Repositories.ORM
{
    public class SessionManager
    {
        #region [ Metodos Privados ]

        private static string GetPathBinMap()
        {
            var uriBuilder = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var assemblyPath = Uri.UnescapeDataString(uriBuilder.Path);
            var pathBase = Path.GetDirectoryName(assemblyPath);
            var nameAssembly = ApplicationSettings.NameAssemblyMappin;

            return Path.Combine(pathBase, nameAssembly);
        }

        private static ISessionFactory _sessionFactory;

        #endregion [ Metodos Privados ]

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        static SessionManager()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(SessionFactory))
                CurrentSessionContext.Bind(SessionFactory.OpenSession());

            return SessionFactory.GetCurrentSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {

            //var sessionHibernate = Fluently.Configure()
            //.Database(MsSqlConfiguration.MsSql2008
            //            .ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection"))
            //            //@"Data Source=(localdb)\Projects;Initial Catalog=Teste;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False") //HOME
            //                                //@"Data Source=(localdb)\Projects;Initial Catalog=Chifon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;") //WORK
            //            .ShowSql()
            //         )
            //         .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Chifon.Cadastro.Map.UsuarioMap>()) //TESTARx => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
            //         //m =>
            //         //          m.FluentMappings
            //         //          .AddFromAssemblyOf<PedidoMap>())

            //                            //.ExposeConfiguration(cfg => new SchemaExport(cfg)
            //                            //                                .Create(true, true))

            //    .CurrentSessionContext<WcfOperationSessionContext>()
            //        .BuildSessionFactory();

            //var sessionHibernate = Fluently.Configure()
            //    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection")).ShowSql())
            //    //.ExposeConfiguration(c => c.SetProperty("current_session_context_class", "wcf_operation"))
            //    //.ExposeConfiguration(x => x.SetInterceptor(new SqlStatementInterceptor()))
            //    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadFile(GetPathBinMap())))
            //    .CurrentSessionContext<WcfOperationSessionContext>()
            //    .BuildSessionFactory();

            var sessionHibernate = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=XPS-CRIS\SQLEXPRESS;Initial Catalog=Chifon;Integrated Security=True"))
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Arma>()))
                .CurrentSessionContext<WcfOperationSessionContext>()
                .BuildSessionFactory();

            return sessionHibernate;
        }
    }
}
