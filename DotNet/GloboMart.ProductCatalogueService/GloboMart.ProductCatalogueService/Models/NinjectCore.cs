using GloboMart.Entities;
using GloboMart.Interface;
using GloboMart.ProductRepository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboMart.ProductCatalogueService
{
    public class NinjectCore : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<ProductCatalogue>>().To<ProductCatalogueRepository>();
        }
    }
}