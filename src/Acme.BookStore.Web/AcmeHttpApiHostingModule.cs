using Acme.BackgroundJobs;
using Acme.Blog.Swagger;
using Acme.BookStore.Domain.Configurations;
using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Hosting.Filter;
using Acme.BookStore.Hosting.Middleware;
using Acme.ToolKits.Base;
using Meowv.Blog.ToolKits.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Hosting
{
   [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(AcmeHttpApiModule),
        typeof(MeowvBlogSwaggerModule),
        typeof(AcmeBlogFrameworkCoreModule),
        typeof(AcmeBlogBackgroundJobsModule)
        )]
    public class AcmeHttpApiHostingModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options=> {

                      options.Events = new JwtBearerEvents
                      {
                          OnChallenge = async context =>
                          {
                              context.HandleResponse();
                              context.Response.ContentType = "application/json;charset=utf-8";
                              context.Response.StatusCode = StatusCodes.Status200OK;
                              var result = new ServiceResult();
                              result.IsFailed("UnAuthorized");

                              await context.Response.WriteAsync(result.ToJson());
                          }
                      };
                      options.TokenValidationParameters = new TokenValidationParameters
                      {

                          // 是否验证颁发者
                          ValidateIssuer = true,
                          // 是否验证访问群体
                          ValidateAudience = true,
                          // 是否验证生存期
                          ValidateLifetime = true,
                          // 验证Token的时间偏移量
                          ClockSkew = TimeSpan.FromSeconds(30),
                          // 是否验证安全密钥
                          ValidateIssuerSigningKey = true,
                          // 访问群体
                          ValidAudience = AppSettings.JWT.Domain,
                          // 颁发者
                          ValidIssuer = AppSettings.JWT.Domain,
                          // 安全密钥
                          IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                      };
                  });
            // 跨域配置
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            context.Services.AddRouting(options =>
            {
                // 设置URL为小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
            });

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加自己实现的 MeowvBlogExceptionFilter
                options.Filters.Add(typeof(MeowvBlogExceptionFilter));
            });
            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }
            // 使用HSTS的中间件，该中间件添加了严格传输安全头
            app.UseHsts();

            // 转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // 路由
            app.UseRouting();

            // 跨域
            app.UseCors();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // HTTP => HTTPS
            app.UseHttpsRedirection();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
