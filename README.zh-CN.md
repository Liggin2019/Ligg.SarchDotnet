# 关于Ligg.SarchDotnet
简体中文 | [English](./README.md)
- 当前版本: 1.2.1
## 介绍
> 本解决方案旨在构建一套完整的企业管理系统SAAS架构（用于OA、ERP、HRMS、MES等）。包括4个项目：Ligg.Abp, Ligg.Vue, Ligg.Eww, Ligg.Mvc下面是项目结构图和开发进度。
![项目结构图和开发进度](https://liggin2019.gitee.io/static/images/proj-diagram-dev-progress.png)
### Ligg.Abp
Ligg.Abp作为主服务器端连接到主数据库提供Restful接口供Ligg.Vue, Ligg.Eww, Ligg.Mvc访问。技术栈基于ABP vNext 2.5（. Net core 3.1, webapi, 多租户），包括JWT，Autofac，Redis，Hangfire，EF（codefirst)，swagger等，支持SqlServer、MySql数据库(其他数据库如SqlLite、PostgreSql未测试)；
- 当前版本: 1.2.1

### Ligg.Vue
Ligg.Vue作为主前端界面，基于VUE2.6和vue-element-admin 4.4.4，集成elementUI、ztree、echarts和可视化流程设计工具jsplumb；
- 当前版本: 1.2.1

###  Ligg.Eww
 Ligg.Eww（EasyWinWeb），Winform web前端，是由Ligg.EasyWinApp配置而来，用于系统配置、数据初始化、程序测试（包括功能和压力测试）；也可以作为MES或WMS的主前端，毕竟Winform与浏览器的前端更加容易连接设备。
- 当前版本: 3.5.1
- 本项目待Ligg.EasyWinApp升级到3.52后上传。


### Ligg.Mvc
Ligg.Mvc基于Asp.net core 3.1 MVC，技术堆栈包括EF核心（db first）、autofac、quartz、bootstrap, jQuery等。Ligg.Mvc将用作CMS和门户生成器，采用响应式网页或移动端H5页面。用于大小屏共存环境下的应用，例如，管理大/小屏、订单审批、问卷调查、官方网站和内部网门户等。
- 当前版本: 1.1.1
- 本项目待更新至1.21后上传。

## 开发环境
- Microsoft Visual Studio 2019, version: 16.4.5
- Microsoft .NET Framework version: 4.8.03752
- Vscode Version: 1.51.1
- Node.js version: 12.18.3; npm version: 6.14.6
- Vue version: 2.6.10, Vue Cli version: 4.5.4
- Db: SQL Server 2016, version: 13.0.1601.5, Connection String: "SqlServer": "Server=127.0.0.1; Database=LiggErpTesting; Uid=sa;Pwd=dba@pass123

## 开发/测试
#### 克隆仓库
git clone https://github.com/Liggin2019/Ligg.SarchDotnet.git , 或
git clone https://gitee.com/Liggin2019/Ligg.SarchDotnet.git

#### 发布Ligg.Abp
- 通过[主文件夹]\Ligg.SarchDotnet\Ligg.Abp\db下的数据库脚本或备份，建立SqlServer数据库
- 通过Visual Studio发布Ligg.Abp至 [主文件夹]\Ligg.SarchDotnet\Ligg.Abp\publish

#### 启动Ligg.Abp服务
双击 [主文件夹]t\Ligg.SarchDotnet\Ligg.Abp\Run.bat, Run.bat内容如下，可根据你的主文件夹的位置做修改
```js
cd E:\Doing\coding\project\Ligg.Abp\publish
e:
dotnet Ligg.Abp.HttpApi.Hosting.dll --urls=http://localhost:5000
```
#### 测试Ligg.Vue
- 用Vscode打开Ligg.Vue
- 关于Vue项目的开发部署可参见PanJiaChen/vue element admin
- 如果运行npm run dev时提示echarts未加载成功，运行npm install echarts -S即可
- 用[主文件夹]\Ligg.Vue\vue.config.js文件替换你的同位置、同名文件，如果你的Restful接口的不是http://localhost:5000，可在vue.config.js文件的target，如下：
```js
 proxy: {
      [process.env.VUE_APP_BASE_API]: {
        target: 'http://localhost:5000',
        changeOrigin: true,
        pathRewrite: {
          ['^' + process.env.VUE_APP_BASE_API]: ''
        }
      }
    }
```

## 鸣谢
代码参考了meowv/blog、PanJiaChen/vue element admin和其他开源贡献者的工作。在此致谢！

## License

[MIT](https://gitee.com/Liggin2019/Ligg.SarchDotnet/blob/master/LICENSE) license.

Copyright (c) 2019-present Liggin2019

## 示例截图