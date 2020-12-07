using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ligg.Abp.Swagger.Filters
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        //#Controllers
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tags = new List<OpenApiTag>
            {
                //com
                new OpenApiTag {
                    Name = "UsrAth",
                    Description = "用户验证",
                    ExternalDocs = new OpenApiExternalDocs { Description = "用户验证" }
                },
                new OpenApiTag {
                    Name = "UsrRlv",
                    Description = "用户相关操作",
                    ExternalDocs = new OpenApiExternalDocs { Description = "用户相关操作" }
                },

                //adm
                new OpenApiTag {
                    Name = "UsrMtn",
                    Description = "用户维护",
                    ExternalDocs = new OpenApiExternalDocs { Description = "用户维护" }
                },
                new OpenApiTag {
                    Name = "RolMtn",
                    Description = "角色维护",
                    ExternalDocs = new OpenApiExternalDocs { Description = "角色维护" }
                },

                //cfg
                new OpenApiTag {
                    Name = "TrsCfg",
                    Description = "事务配置",
                    ExternalDocs = new OpenApiExternalDocs { Description = "事务配置" }
                },
                new OpenApiTag {
                    Name = "OrgCfg",
                    Description = "组织配置",
                    ExternalDocs = new OpenApiExternalDocs { Description = "事务配置" }
                },

                //#erp-cfg
                new OpenApiTag {
                    Name = "BpmCfg",
                    Description = "ERP流程配置",
                    ExternalDocs = new OpenApiExternalDocs { Description = "ERP流程配置" }
                },
                //##erp-biz-pd
                new OpenApiTag {
                    Name = "MatMtn",
                    Description = "物料维护",
                    ExternalDocs = new OpenApiExternalDocs { Description = "物料维护" }
                },
                //##erp-biz-pm
                new OpenApiTag {
                    Name = "VndMtn",
                    Description = "供应商维护",
                    ExternalDocs = new OpenApiExternalDocs { Description = "供应商维护" }
                },
                //##erp-biz-wm
                new OpenApiTag {
                    Name = "MatRcv",
                    Description = "物料入库",
                    ExternalDocs = new OpenApiExternalDocs { Description = "物料入库" }
                },
                new OpenApiTag {
                    Name = "MatIss",
                    Description = "物料出库",
                    ExternalDocs = new OpenApiExternalDocs { Description = "物料出库" }
                },
                //##erp-biz-pp
                new OpenApiTag {
                    Name = "ProMtn",
                    Description = "工单维护",
                    ExternalDocs = new OpenApiExternalDocs { Description = "工单维护" }
                },

                //Oa
                //#oa-cfg
                new OpenApiTag {
                    Name = "TabCfg",
                    Description = "表单配置",
                    ExternalDocs = new OpenApiExternalDocs { Description = "表单配置" }
                },
                new OpenApiTag {
                    Name = "WflCfg",
                    Description = "流程配置",
                    ExternalDocs = new OpenApiExternalDocs { Description = "流程配置" }
                },
                //#oa-biz
                new OpenApiTag {
                    Name = "DocMgr",
                    Description = "资料管理",
                    ExternalDocs = new OpenApiExternalDocs { Description = "资料管理" }
                },
                new OpenApiTag {
                    Name = "WflMgr",
                    Description = "流程管理",
                    ExternalDocs = new OpenApiExternalDocs { Description = "资料管理" }
                },
                new OpenApiTag {
                    Name = "ResMgr",
                    Description = "资源管理",
                    ExternalDocs = new OpenApiExternalDocs { Description = "资料管理" }
                },
                new OpenApiTag {
                    Name = "AssMgr",
                    Description = "资产管理",
                    ExternalDocs = new OpenApiExternalDocs { Description = "资料管理" }
                },
                //Cms
                new OpenApiTag {
                    Name = "SitMtn",
                    Description = "站点维护",
                    ExternalDocs = new OpenApiExternalDocs { Description = "站点维护" }
                }

            };

            #region 实现添加自定义描述时过滤不属于同一个分组的API

            // 当前分组名称
            var groupName = context.ApiDescriptions.FirstOrDefault().GroupName;

            // 当前所有的API对象
            var apis = context.ApiDescriptions.GetType().GetField("_source", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(context.ApiDescriptions) as IEnumerable<ApiDescription>;

            // 不属于当前分组的所有Controller
            // 注意：配置的OpenApiTag，Name名称要与Controller的Name对于才会生效。
            var controllers = apis.Where(x => x.GroupName != groupName).Select(x => ((ControllerActionDescriptor)x.ActionDescriptor).ControllerName).Distinct();

            // 筛选一下tags
            swaggerDoc.Tags = tags.Where(x => !controllers.Contains(x.Name)).OrderBy(x => x.Name).ToList();

            #endregion
        }
    }
}