using Autofac;
using Autofac.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
//using NopUI.Plugin.Widgets.Unit.Controllers;
using NopUI.Plugin.Widgets.Unit.Data;
using NopUI.Plugin.Widgets.Unit.Domain;
using NopUI.Plugin.Widgets.Unit.Services;
using Nop.Web.Framework.Mvc;

namespace NopUI.Plugin.Widgets.Unit
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_product_view_unit";
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<UnitService>().As<IUnitService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<UnitEntityContext>(builder, CONTEXT_NAME);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<UnitEntity>>()
                .As<IRepository<UnitEntity>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            //we cache presentation models between requests
           // builder.RegisterType<WidgetsCategoryChannelDiyController>()
                //.WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
