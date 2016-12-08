using Serenity.Abstractions;
using Serenity.Caching;
using Serenity.Configuration;
using Serenity.Extensibility;
using Serenity.Localization;
using Serenity.Logging;
using System;
using System.IO;

namespace SerenityWinForm
{
    public class PermissionService : IPermissionService
    {
        public bool HasPermission(string permission)
        {
            return true;
        }
    }
}