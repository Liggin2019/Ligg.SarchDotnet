#### About Ligg.SarchDotnet
English | [简体中文](./README.zh-CN.md)
## Introduction：
> This solution aims to bulid a full set of enterprise management system SAAS architecture ( for OA, ERP, HRMS, MES, etc). including 4 projects: Ligg.Abp, Ligg.Vue, Ligg.Ewa, Ligg.Mvc. Following is the diagram of their structure.
Ligg.Abp

## Ligg.Abp
Ligg.Abp is the main server end connected to main database to provide Restful interface to Ligg.Vue, Ligg.Ewa, Ligg.Mvc, based on ABP vNext 2.5(. Net core 3.1, webapi, mutiple tenants ) inluding JWT, Autofac, Redis, Hangfire, EF(code first), swagger. Support SqlServer and MySql database, other db such as sqllite and PostgreSQL are not tested;

## Ligg.Vue
Ligg.Vue is the main front end presentation UI , based on Vue 2.6, integrated into elementUI, ztree, echarts and Visual process design tool-jsplumb;

## Ligg.Eww
Ligg.Eww(EasyWinWeb) is a Winform web front end Configured from Ligg.EasyWinApp, used as system configuration, data initialization, program test (both press and function); also it can be used for MES or WMS as a bridge between device and Ligg.Abp, after all it is easy to connect device compared to the UI based on brower.
- This project will be uploaded after Ligg.EasyWinApp upgrades to version 3.52.


## Ligg.Mvc
Ligg.Mvc based on Asp.net core 3.1 MVC, tech stack including EF core(db first), autofac, quartz, bootstrap, etc. Ligg.Mvc will be used as CMS and portal generator for responsive web page, or mobile-end H5 page for the usage in the coexistence environment of large and small screen. For example, managerial large/small screens， order approval, survey, official site and intranet portals.
- This project will be uploaded after updating.

## Thanks
The codes reference the work of meowv/blog, PanJiaChen/vue-element-admin and other open-source contributors. Thank you all.

## How to Develop or test

# Clone Repository
- git clone https://github.com/Liggin2019/Ligg.SarchDotnet.git , or
- git clone https://gitee.com/Liggin2019/Ligg.SarchDotnet.git

# Publish Ligg.Abp
- Through  script or backup file  under  [home folder]\Ligg.SarchDotnet\Ligg.Abp\db to establish SQLSERVER database
- Publish Ligg.Abp by Visual Studioto  [home folder]\Ligg.SarchDotnet\Ligg.Abp\publish.

# Start Dservice of Ligg.Abp
- Double click  [home folder]\Ligg.SarchDotnet\Ligg.Abp\Run.bat,  The content  of Run.bat is as follows. You can modify it according to the location of your home folder.

```js
cd E:\Doing\coding\project\Ligg.Abp\publish
e:
dotnet Ligg.Abp.HttpApi.Hosting.dll --urls=http://localhost:5000
```
# Test Ligg.Vue
- Open Ligg.Vue by Vscode
- For the development and deployment of Vue project, please refer to PanJiaChen/vue element admin
- If run 'npm run dev' failed and get a error 'echarts has not been loaded successfully', run 'npm install echarts - S'
- Use [home folder]\ Ligg.Vue\ vue.config.js file to replace your file with the same location and same name, if your RESTFUL interface is not http://localhost : 5000, please modify the 'target' value in vue.config.js.  The file is as follows: 
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

## License

[MIT](https://gitee.com/Liggin2019/Ligg.SarchDotnet/blob/master/LICENSE) license.

Copyright (c) 2019-present Liggin2019

//## Demo snapshot
## Demo Snapshot