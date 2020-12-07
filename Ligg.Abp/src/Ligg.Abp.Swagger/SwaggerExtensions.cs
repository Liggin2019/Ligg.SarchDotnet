using Ligg.Abp.Swagger.Filters;
using Ligg.Abp.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ligg.Abp.Swagger
{
    public static class SwaggerExtensions
    {

        private static readonly string version = $"v{AppSettings.ApiVersion}";

        private static readonly string description = @"<b>LIGGTECH ERP 版本:</b>" + version + @" <code>Powered by .NET Core 3.1</code> <code>ABP Framework→</code><a target=""_blank"" href=""https://abp.io"">https://abp.io</a>";

        //#group
        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
             new SwaggerApiInfo
            {
                UrlPrefix = "com",
                Name = "通用接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "通用接口，用户登录/注销/设置、日志消息等",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "adm",
                Name = "系统管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "系统管理，包括部门、用户、权限管理。初级系统管理员适用",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "cfg",
                Name = "配置管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "全局系统配置管理，包括权限、事务、权限对象、定时运行等的配置，高级系统管理员（类似于SAP的Basis）适用",
                    Description = description
                }
            },
            //Erp
            new SwaggerApiInfo
            {
                UrlPrefix = "erp-cfg",
                Name = "ERP-配置管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "ERP-配置管理，包含组织、流程控制、接口等，系统实施顾问（类似于SAP的功能顾问）使用",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "erp-biz-pd",
                Name = "ERP-业务处理-产品数据",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "ERP-业务处理-产品数据",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "erp-biz-pm",
                Name = "ERP-业务处理-采购管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "ERP-业务处理-采购管理",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "erp-biz-wm",
                Name = "ERP-业务处理-仓储管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "ERP-业务处理-仓储管理",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "erp-biz-pp",
                Name = "ERP-业务处理-生产管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "ERP-业务处理-生产管理",
                    Description = description
                }
            },
            
            //Oa
            new SwaggerApiInfo
            {
                UrlPrefix = "oa-cfg",
                Name = "OA-配置管理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "OA-配置管理",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = "oa-biz",
                Name = "OA-业务处理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "OA-业务处理",
                    Description = description
                }
            },

            //Cms
            new SwaggerApiInfo
            {
                UrlPrefix = "cms",
                Name = "CMS-业务处理",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "CMS-业务处理",
                    Description = description
                }
            }

        };


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                // 遍历并应用Swagger分组信息
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });

                // API注释所需XML文件
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ligg.Abp.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ligg.Abp.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Ligg.Abp.Application.Contracts.xml"));

                #region 小绿锁，JWT身份认证配置

                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入 Bearer {Token} 进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("oauth2", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                #endregion

                // 应用Controller的API文档描述信息
                options.DocumentFilter<SwaggerDocumentFilter>();
            });
        }

        /// <summary>
        /// UseSwaggerUI
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                // 遍历分组信息，生成Json
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                });
                // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                options.DefaultModelsExpandDepth(-1);
                // API文档仅展开标记
                options.DocExpansion(DocExpansion.List);
                // API前缀设置为空
                options.RoutePrefix = string.Empty;
                // API页面Title
                options.DocumentTitle = "接口文档";
            });
        }

        internal class SwaggerApiInfo
        {
            /// <summary>
            /// URL前缀
            /// </summary>
            public string UrlPrefix { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// <see cref="Microsoft.OpenApi.Models.OpenApiInfo"/>
            /// </summary>
            public OpenApiInfo OpenApiInfo { get; set; }
        }
    }
}