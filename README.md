# About Ligg.SarchDotnet
English | [简体中文](./README.zh-CN.md)
- SarchDotnet is abbreviation of 'Set of Architectures with .Net for Enterprise Management Information System', it sounds like "傻吃多乐" in Chinese, means 'enjoy the happiness of a foodie'. 
- Current version: 1.2.1
- [Gitee Mirror](https://www.gitee.com/liggin2019/Ligg.SarchDotnet)
## Introduction：
> This solution aims to bulid a full set of enterprise information management system SAAS architecture ( for OA, ERP, HRMS, MES, etc). including 4 projects: Ligg.Abp, Ligg.Vue, Ligg.Ewa, Ligg.Mvc. Following is the project diagram and development progress.
![project diagram and development progress](https://liggin2019.gitee.io/Static/images/SarchDotnet/proj-status.png)

### Ligg.Abp
Ligg.Abp is the main server end connected to main database to provide Restful interface to Ligg.Vue, Ligg.Eww, Ligg.Mvc, based on ABP vNext 2.5(. Net core 3.1, webapi, multiple tenants ) inluding JWT, Autofac, Redis, Hangfire, EF(code first), swagger. Support SqlServer and MySql database (other dbs such as sqllite and PostgreSQL are not tested);
- Current version: 1.2.1

### Ligg.Vue
Ligg.Vue is the main front end presentation UI , based on Vue 2.6 and vue-element-admin 4.4.4, integrated into elementUI, ztree, echarts and Visual process design tool-jsplumb;
- Current version: 1.2.1

### Ligg.Eww
Ligg.Eww(EasyWinWeb) is a Winform web front end Configured from Ligg.EasyWinApp, used as system configuration, data initialization, program test (both press and function); also it can be used for MES or WMS as a bridge between device and Ligg.Abp, after all Winform is easy to connect device compared to the Front-end based on browser.
- Current version: 3.5.1
- This project will be uploaded after Ligg.EasyWinApp upgrades to version 3.52(to match Ligg.App 1.2.1).


### Ligg.Mvc
Ligg.Mvc based on Asp.net core 3.1 MVC, tech stack including EF core(db first), autofac, quartz, bootstrap, etc. Ligg.Mvc will be used as CMS and portal generator for responsive web page, or mobile-end H5 page for the usage in the coexistence environment of large and small screen. For example, managerial visualization large/small screens， order approval, survey, official site and intranet portals.
- Current version: 2.1.1
- This project will be uploaded after upgrading to version 2.2.1(to match Ligg.App 1.2.1).

## development enviroment
- Microsoft Visual Studio 2019, version: 16.4.5
- Microsoft .NET Framework version: 4.8.03752
- Vscode Version: 1.51.1
- Node.js version: 12.18.3; npm version: 6.14.6
- Vue version: 2.6.10, Vue Cli version: 4.5.4
- Db: SQL Server 2016, version: 13.0.1601.5, Connection String: "SqlServer": "Server=127.0.0.1; Database=LiggErpTesting; Uid=sa;Pwd=dba@pass123

## How to develop or test
#### Clone Repository
- git clone https://github.com/Liggin2019/Ligg.SarchDotnet.git , or
- git clone https://gitee.com/Liggin2019/Ligg.SarchDotnet.git

#### Publish Ligg.Abp
- Through  script or backup file  under  [home folder]\Ligg.SarchDotnet\Ligg.Abp\db to establish SQLSERVER database
- Publish Ligg.Abp by Visual Studio to  [home folder]\Ligg.SarchDotnet\Ligg.Abp\publish.

#### Start service of Ligg.Abp
- Double click  [home folder]\Ligg.SarchDotnet\Ligg.Abp\Run.bat,  The content  of Run.bat is as follows. You can modify it according to the location of your home folder.

```js
cd E:\Doing\coding\project-git\Ligg.SarchDotnet\Ligg.Abp\publish
e:
dotnet Ligg.Abp.HttpApi.Hosting.dll --urls=http://localhost:5000
```
#### Test Ligg.Vue
- Open Ligg.Vue by Vscode by open folder of '[home folder]\Ligg.SarchDotnet\Ligg.Vue\dev'
- For the development and deployment of Vue project, please refer to PanJiaChen/vue-element-admin
- If running 'npm run dev' failed and get an error of 'echarts has not been loaded successfully', run 'npm install echarts - S'
- If your RESTFUL interface is not http://localhost : 5000, please modify the 'target' value in '[home folde]\Ligg.SarchDotnet\Ligg.Vue\dev\vue.config.js' as below: 
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
## Thanks
The codes refers the work of meowv/blog, PanJiaChen/vue-element-admin and other open-source contributors. Thank you all.

## License

[MIT](https://gitee.com/Liggin2019/Ligg.SarchDotnet/blob/master/LICENSE) license.

Copyright (c) 2019-present Liggin2019

## Demo Snapshot
### Ligg.Vue
#### Login
![Login](https://liggin2019.gitee.io/Static/images/SarchDotnet/Ligg.Vue-login.png)

#### Dashboard
![Dashboard](https://liggin2019.gitee.io/Static/images/SarchDotnet/Ligg.Vue-dashboard.png)

### Ligg.Eww
#### Login
![Login](https://liggin2019.gitee.io/Static/images/SarchDotnet/Ligg.Eww-login.png)
#### System configuration
![System configuration](https://liggin2019.gitee.io/Static/images/SarchDotnet/Ligg.Eww-trs-cfg.png)
#### Data initiation
![Data initiation](https://liggin2019.gitee.io/Static/images/SarchDotnet/Ligg.Eww-usr-mtn.png)  
