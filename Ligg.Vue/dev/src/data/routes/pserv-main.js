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
    path: '/tenant',
    component: 'Layout',
    redirect: '/tenant/mtn',
    name: 'tenant',
    meta: { title: 'Tenant', icon: 'el-icon-help' },
    children: [
      {
        path: '/tenant/mtn',
        name: 'tenant-mtn',
        component: 'views/dashboard/index',
        meta: { title: 'Tenant Mtn', icon: 'el-icon-help' }
      },
      {
        path: '/tenant/cfg',
        name: 'tenant-cfg',
        component: 'views/404',
        meta: { title: 'Tenant Cfg', icon: 'el-icon-help' }
      }
    ]
  },
  {
    path: '/system',
    component: 'Layout',
    redirect: '/system/view-mtn',
    name: 'system',
    meta: { title: 'System', icon: 'form' },
    children: [
      {
        path: '/system/view-mtn',
        name: 'view-mtn',
        component: 'views/dashboard/index',
        meta: { title: 'View Mtn', icon: 'form' }
      },
      {
        path: '/system/action-mtn',
        name: 'action-mtn',
        component: 'views/404',
        meta: { title: 'Action Mtn', icon: 'form' }
      }
    ]
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

