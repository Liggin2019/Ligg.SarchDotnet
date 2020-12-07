const routes = [
  {
    path: '/',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Home',
    children: [{
      path: '/dashboard',
      name: 'dashboard',
      component: 'views/dashboard/index',
      meta: { title: 'Dashboard', icon: 'dashboard' }
    }
    ]
  },
  {
    path: '/organization',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'organization',
    meta: { title: 'Organization', icon: 'el-icon-s-operation' }
  },
  {
    path: '/workflow',
    component: 'Layout',
    name: 'workflow',
    meta: { title: 'Workflow', icon: 'table' }
  },
  {
    path: '/form',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'form',
    meta: { title: 'Form', icon: 'form' }
  },
  {
    path: '/report',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'report',
    meta: { title: 'Report', icon: 'tree' }
  },
  {
    path: 'help',
    component: 'Layout',
    children: [
      {
        path: 'https://panjiachen.gitee.io/vue-element-admin-site/zh/',
        meta: { title: 'Help', icon: 'el-icon-link' }
      }
    ]
  }
]

module.exports =
  {
    data: routes
  }

