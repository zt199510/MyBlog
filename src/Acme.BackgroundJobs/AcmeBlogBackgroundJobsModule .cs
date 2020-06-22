using Acme.BookStore.Domain.Configurations;
using Acme.BookStore.Domain.Shared;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.Logging.LogProviders;
using Hangfire.MySql.Core;
using Hangfire.SQLite;
using Microsoft.Data.Sqlite;
using System;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace Acme.BackgroundJobs
{
    [DependsOn(
        typeof(AbpBackgroundJobsHangfireModule)
        )]
    public class AcmeBlogBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(
                    new MySqlStorage(AppSettings.ConnectionStrings,
                    new MySqlStorageOptions
                    {
                        TablePrefix = AcmeBlogConsts.DbTablePrefix + "hangfire"
                    }));
            });
            //context.Services.AddHangfire(config =>
            //{


            //    //Console.WriteLine(AppSettings.ConnectionStrings);
            //    //var sqliteOptions = new SQLiteStorageOptions();

            //    //config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //    //.UseSimpleAssemblyNameTypeSerializer().UseRecommendedSerializerSettings()
            //    //.UseLogProvider(new ColouredConsoleLogProvider())
            //    //.UseSQLiteStorage(AppSettings.ConnectionStrings, sqliteOptions);


            //});
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {


            var app = context.GetApplicationBuilder();

            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[]
                            {
                                new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                                {
                                    RequireSsl = false,
                                    SslRedirect = false,
                                    LoginCaseSensitive = true,
                                    Users = new []
                                    {
                                        new BasicAuthAuthorizationUser
                                        {
                                            Login = AppSettings.Hangfire.Login,
                                            PasswordClear =  AppSettings.Hangfire.Password
                                        }
                                    }
                                })
                            },
                DashboardTitle = "任务调度中心"

            });

            var service = context.ServiceProvider;
            // 壁纸数据抓取
            service.UseWallpaperJob();
            //// 每日热点数据抓取
            service.UseHotNewsJob();
            //service.UseHangfireTest();
        }
    }
}
