using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Domain.Interface;
using Book.Domain.Service;
using Core.Repository.MongoDB;
using SimpleInjector;

namespace Book.Infra.IoC
{
    public class BootStrapper
    {
        /// <summary>
        /// Simple injector container
        /// </summary>
        public static Container MyContainer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            container.Register<IBookService, BookService>(Lifestyle.Scoped);
            container.Register<IMongoDbRepository, MongoRepository>(Lifestyle.Scoped);
        }

        public static void RegisterNoScope(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            container.Register<IBookService, BookService>();
            container.Register<IMongoDbRepository, MongoRepository>();
        }
    }
}
