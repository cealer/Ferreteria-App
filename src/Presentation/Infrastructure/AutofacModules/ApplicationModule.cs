using Application.Queries.ProductsQueries;
using Autofac;
using Domain.AggregatesModel.InventoryAggregate;
using Domain.AggregatesModel.ProductAggregate;
using Infrastructure.Repositories;

namespace Presentation.Infrastructure.AutofacModules
{
    public class ApplicationModule
        : Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new ProductQueries(QueriesConnectionString))
                .As<IProductQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InventoryRepository>()
                .As<IInventoryRepository>()
                .InstancePerLifetimeScope();


        }
    }
}
