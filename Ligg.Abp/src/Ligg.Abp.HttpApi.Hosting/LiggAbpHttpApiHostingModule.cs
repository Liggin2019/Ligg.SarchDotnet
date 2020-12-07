using Ligg.Abp.Domain;
using Ligg.Abp.EntityFrameworkCore;
using Ligg.Abp.HttpApi.Hosting.Middleware;
using Ligg.Abp.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ligg.Abp.HttpApi.Hosting
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(LiggAbpHttpApiModule),
        typeof(LiggAbpSwaggerModule),
        typeof(LiggAbpFrameworkCoreModule)
        )]
    public class LiggAbpHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // ·������
            context.Services.AddRouting(options =>
            {
                // ����URLΪСд
                options.LowercaseUrls = true;
                // �����ɵ�URL�������б��
                options.AppendTrailingSlash = true;
            });

            // �����֤֮JWT
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           // �Ƿ���֤�䷢��
                           ValidateIssuer = true,
                           // �Ƿ���֤����Ⱥ��
                           ValidateAudience = true,
                           // �Ƿ���֤������
                           ValidateLifetime = true,
                           // ��֤Token��ʱ��ƫ����
                           ClockSkew = TimeSpan.FromSeconds(30),
                           // �Ƿ���֤��ȫ��Կ
                           ValidateIssuerSigningKey = true,
                           // ����Ⱥ��
                           ValidAudience = AppSettings.JWT.Domain,
                           // �䷢��
                           ValidIssuer = AppSettings.JWT.Domain,
                           // ��ȫ��Կ
                           IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                       };
                   });

            // ��֤��Ȩ
            context.Services.AddAuthorization();

            // Http����
            context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // ������������������
            if (env.IsDevelopment())
            {
                // �����쳣ҳ��
                app.UseDeveloperExceptionPage();
            }

            // ʹ��HSTS���м�������м��������ϸ��䰲ȫͷ
            app.UseHsts();

            // ת������ͷ������ǰ������� Nginx ʹ�ã���ȡ�û���ʵIP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // ·��
            app.UseRouting();

            // ����
            app.UseCors();

            // �쳣�����м��
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // �����֤
            app.UseAuthentication();

            // ��֤��Ȩ
            app.UseAuthorization();

            // HTTP => HTTPS
            app.UseHttpsRedirection();

            // ·��ӳ��
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}