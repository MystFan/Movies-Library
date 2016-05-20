namespace MoviesLibrary.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using MoviesLibrary.Data;
    using MoviesLibrary.Data.Repositories;
    using MoviesLibrary.Services.Data.Contracts;
    using MoviesLibrary.Services.Web;
    using MoviesLibrary.Services.Web.Contracts;
    using MoviesLibrary.Web.Controllers;

    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new MoviesLibraryDbContext())
                .As<DbContext>()
                .InstancePerRequest();

            builder.Register(x => new HttpCacheService())
                .As<ICacheService>()
                .InstancePerRequest();

            builder.Register(x => new ImageEditorService())
                .As<IImageEditorService>()
                .InstancePerRequest();

            builder.Register(x => new YouTubeApiService())
                .As<IVideoApiService>()
                .InstancePerRequest();

            builder.Register(x => new OMDbApiService())
                .As<IMovieAdditionalInfoApiService>()
                .InstancePerRequest();

            var servicesAssembly = Assembly.GetAssembly(typeof(IService));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DbRepository<>))
                .As(typeof(IDbRepository<>))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();
        }
    }
}