using Serenity;
using Serenity.Abstractions;
using Serenity.Caching;
using Serenity.Configuration;
using Serenity.Data;
using Serenity.Extensibility;
using Serenity.Localization;
using Serenity.Logging;
using System;
using System.IO;

namespace SerenityWinForm
{
    public static partial class AppInitialization
    {
        public static void Run()
        {
            SqlSettings.AutoQuotedIdentifiers = true;
            Serenity.Services.DesktopInitialization.Run();
            var registrar = Dependency.Resolve<IDependencyRegistrar>();
            //registrar.RegisterInstance<IAuthorizationService>(new Administration.AuthorizationService());
            //registrar.RegisterInstance<IAuthenticationService>(new Administration.AuthenticationService());
            registrar.RegisterInstance<IPermissionService>(new PermissionService());
            //registrar.RegisterInstance<IUserRetrieveService>(new Administration.UserRetrieveService());

            foreach (var databaseKey in databaseKeys)
            {
                EnsureDatabase(databaseKey);
                RunMigrations(databaseKey);
            }
        }
    }
}