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
    path: '/role',
    component: 'Layout',
    redirect: '/user/user-mtn',
    name: 'role',
    meta: { title: 'Role Mgmt', icon: 'tree' }
  },
  {
    path: '/user',
    component: 'Layout',
    redirect: '/user/user-mtn',
    name: 'user',
    meta: { title: 'User', icon: 'form' },
    children: [
      {
        path: '/user/user-mtn',
        name: 'user-mtn',
        component: 'views/dashboard/index',
        meta: { title: 'User Mtn', icon: 'tree' }
      },
      {
        path: '/user/Pms-mgmt',
        name: 'Pms-mgmt',
        component: 'views/404',
        meta: { title: 'Pms Mgmt', icon: 'table' }
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

