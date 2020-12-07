import { constantRoutes } from '@/router'
import { getRoutes } from '@/utils/get-routes'
import store from '@/store'
import Layout from '@/layout'

function loopCreateRouter(routes) {
  const res = []
  routes.forEach(route => {
    const tmp = { ...route }
    const tpl = Object.assign({}, tmp)
    if (typeof tmp['component'] !== 'undefined' && tmp['component']) {
      if (tmp['component'] === 'Layout') {
        tpl['component'] = Layout
      } else {
        tpl['component'] = resolve => require([`../../${tmp['component']}.vue`], resolve)
      }
    }
    if (tmp['children']) {
      tpl['children'] = loopCreateRouter(tmp['children'])
    }
    res.push(tpl)
  })
  return res
}

function judgePermissionByRoles(roles) {
  const roles1 = store.getters.roles
  return roles1.some(x => roles.includes(x))
}

function judgePermissionByView(ctrl) {
  return store.getters.accesibleControllers.includes(ctrl)
}

function judgePermissionByAction(act) {
  return store.getters.accesibleActions.includes(act)
}

function hasPermission(route) {
  let isOk = false
  let judged = false
  if (!(route.meta && route.meta.roles && route.meta.roles.length !== 0) || !(judgePermissionByRoles(route.meta.roles))) {
    if (route.meta && route.meta.roles && route.meta.roles.length !== 0) judged = true
    if (!(route.meta && route.meta.controller) || !(judgePermissionByView(route.meta.controller))) {
      if (route.meta && route.meta.controller) judged = true

      if (!judged) {
        if (!(route.meta && route.meta.action)) {
          isOk = true
        } else {
          if (judgePermissionByAction(route.meta.action)) { isOk = true } else { isOk = false }
        }
      } else { if (judgePermissionByAction(route.meta.action)) { isOk = true } }
    } else { isOk = true }
  } else {
    isOk = true
  }
  return isOk
}

export function filterDynamicRoutes(routes) {
  const res = []
  routes.forEach(route => {
    const tmp = { ...route }
    if (hasPermission(tmp)) {
      if (tmp.children) {
        tmp.children = filterDynamicRoutes(tmp.children)
      }
      res.push(tmp)
    }
  })
  return res
}

const state = {
  routes: [],
  addRoutes: []
}

const mutations = {
  SET_ROUTES: (state, routes) => {
    state.addRoutes = routes
    state.routes = constantRoutes.concat(routes)
  }
}

const actions = {
  getDynamicRoutes({ commit, state }) {
    return new Promise(resolve => {
      const dynamicRoutes = getRoutes().data
      let accessibleRoutes
      if (store.getters.roles.includes('root')) {
        accessibleRoutes = dynamicRoutes
      } else {
        accessibleRoutes = filterDynamicRoutes(dynamicRoutes)
      }
      const availableRoutes = loopCreateRouter(accessibleRoutes)
      availableRoutes.push({ path: '*', redirect: '/404', hidden: true })
      commit('SET_ROUTES', availableRoutes)
      resolve(availableRoutes)
    })
  },

  IsAuthValid({ commit }, data) {
    const roles = data.roles
    const controller = data.controller
    const action = data.action
    let isOk = false
    let judged = false
    if (store.getters.roles.includes('admin') || store.getters.roles.includes('root')) {
      isOk = true
    } else {
      if (!(roles && roles.length !== 0) || !(judgePermissionByRoles(roles))) {
        if (roles && roles.length !== 0) judged = true
        if (!(controller) || !(judgePermissionByView(controller))) {
          if (controller) judged = true

          if (!judged) {
            if (!(action)) {
              isOk = true
            } else {
              if (judgePermissionByAction(action)) { isOk = true } else { isOk = false }
            }
          } else { if (judgePermissionByAction(action)) { isOk = true } }
        } else { isOk = true }
      } else {
        isOk = true
      }
    }

    return isOk
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}
