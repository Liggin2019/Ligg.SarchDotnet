const routes = [
  {
    path: '/',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Home',
    children: [{
      path: '/dashboard',
      name: 'Dashboard',
      component: 'views/dashboard/index',
      meta: { title: 'Dashboard', icon: 'dashboard' }
    }
    ]
  },
  {
    path: '/nested',
    component: 'Layout',
    redirect: '/nested/menu1',
    name: 'Nested',
    meta: {
      title: 'Product Data',
      icon: 'table'
    },
    children: [
      {
        path: '/nested/menu1',
        redirect: '/nested/menu1/menu1-1',
        component: 'views/dashboard/index',
        name: 'Menu1',
        meta: { title: 'Material', icon: 'el-icon-s-operation' },
        children: [
          {
            path: '/nested/menu1/menu1-1',
            component: 'views/nested/menu1/menu1-1/index',
            name: 'Menu1-1',
            meta: { title: 'Material Mtn', icon: 'el-icon-s-operation' }
          },
          {
            path: '/nested/menu1/menu1-2',
            redirect: 'noRedirect',
            component: 'views/nested/menu1/menu1-2/index',
            name: 'Menu1-2',
            meta: { title: 'Material Report', icon: 'el-icon-s-operation' },
            children: [
              {
                path: '/nested/menu1/menu1-2/menu1-2-1',
                component: 'views/nested/menu1/menu1-2/menu1-2-1/index',
                name: 'Menu1-2-1',
                meta: { title: 'Material List', icon: 'el-icon-s-operation' }
              },
              {
                path: '/nested/menu1/menu1-2/menu1-2-2',
                component: 'views/nested/menu1/menu1-2/menu1-2-2/index',
                name: 'Menu1-2-2',
                meta: { title: 'Mat Cost List', icon: 'el-icon-s-operation' }
              }
            ]
          }
        ]
      },
      {
        path: '/nested/menu1',
        redirect: '/nested/menu1/menu1-1',
        component: 'views/404',
        name: 'Menu1',
        meta: { title: 'BOM', icon: 'el-icon-document' },
        children: [
          {
            path: '/nested/menu1/menu1-1',
            component: 'views/nested/menu1/menu1-1/index',
            name: 'Menu1-1',
            meta: { title: 'BOM Mtn', icon: 'el-icon-document' }
          },
          {
            path: '/nested/menu1/menu1-2',
            redirect: 'noRedirect',
            component: 'views/nested/menu1/menu1-2/index',
            name: 'Menu1-2',
            meta: { title: 'BOM Report', icon: 'el-icon-document' },
            children: [
              {
                path: '/nested/menu1/menu1-2/menu1-2-1',
                component: 'views/nested/menu1/menu1-2/menu1-2-1/index',
                name: 'Menu1-2-1',
                meta: { title: 'BOM List', icon: 'el-icon-document' }
              },
              {
                path: '/nested/menu1/menu1-2/menu1-2-2',
                component: 'views/nested/menu1/menu1-2/menu1-2-2/index',
                name: 'Menu1-2-2',
                meta: { title: 'BOM Cost List', icon: 'el-icon-document' }
              }
            ]
          }
        ]
      }
    ]
  },

  {
    path: '/Purchase',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Purchase',
    meta: { title: 'Purchase', icon: 'el-icon-news' },
    children: [
      {
        path: '/Purchase/Vendor',
        name: 'Vendor',
        component: 'views/dashboard/index',
        meta: { title: 'Vendor Mtn', icon: 'tree' }
      },
      {
        path: '/Purchase/Price',
        name: 'Price',
        component: 'views/404',
        meta: { title: 'Price Mgmt', icon: 'table' }
      },
      {
        path: '/Purchase/PurOrder',
        name: 'PurOrder',
        component: 'views/404',
        meta: { title: 'Purchase Order', icon: 'form' }
      }
    ]
  },
  {
    path: '/Warehouse',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Warehouse',
    meta: { title: 'Warehouse', icon: 'el-icon-guide' }
  },
  {
    path: '/Production',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Production',
    meta: { title: 'Production', icon: 'el-icon-postcard' }
  },
  {
    path: '/Quality',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Quality',
    meta: { title: 'Quality', icon: 'el-icon-bicycle' }
  },
  {
    path: '/Sales',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Sales',
    meta: { title: 'Sales', icon: 'el-icon-goods' }
  },
  {
    path: '/Finance',
    component: 'Layout',
    redirect: '/dashboard',
    name: 'Finance',
    meta: { title: 'Finance', icon: 'el-icon-success' }
  },
  {
    path: '/setting',
    component: 'Layout',
    redirect: '/setting/user',
    name: 'Setting',
    meta: { title: 'Setting', icon: 'el-icon-s-tools' },
    children: [
      {
        path: '/setting/user',
        name: 'User',
        component: 'views/dashboard/index',
        meta: { title: 'User', icon: 'el-icon-s-tools' }
      },
      {
        path: '/setting/role',
        name: 'Role',
        component: 'views/404',
        meta: { title: 'Role', icon: 'el-icon-s-tools' }
      },
      {
        path: '/setting/menu',
        name: 'Menu',
        component: 'views/dashboard/index',
        meta: { title: 'Menu', icon: 'el-icon-s-tools' }
      },
      {
        path: '/setting/log',
        name: 'Log',
        component: 'views/404',
        meta: { title: 'Log', icon: 'el-icon-s-tools' }
      }
    ]
  },

  {
    path: 'external-link',
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

