
const functions = [

  {
    app: 'erp',
    name: 'ERP',
    title: 'Enterprise Resource Management System',
    description: 'buld efficient, concise and measurable operation system',
    description1: '打造高效、精简、可测量的生产运营体系',
    functions: [{
      code: 'erp-main',
      title: 'ERP Business',
      title1: 'ERP业务系统'
    },
    {
      code: 'erp-admin',
      title: 'ERP Admin',
      title1: 'ERP系统管理'
    },
    {
      code: 'erp-cfg',
      title: 'ERP Config',
      title1: 'ERP系统配置'
    }]
  },
  {
    app: 'oa',
    name: 'SAC',
    title: 'Sharing&Co-orperation System',
    description: 'Building efficient, sharing and collaborative learning org.',
    description1: '打造高效、分享、协作的学习型组织',
    functions: [{
      code: 'oa-main',
      title: 'OA System',
      title1: 'OA共享与协作系统'
    }]
  },
  {
    app: 'pserv',
    name: 'PSERV',
    title: 'Ligg SAAS Public Service',
    description: 'SAAS Public Serv',
    description1: 'SAAS公共服务',
    functions: [{
      code: 'pserv-main',
      title: 'SAAS Public Serv',
      title1: 'SAAS公共服务'
    }]
  }
]

module.exports =
  {
    data: functions
  }
