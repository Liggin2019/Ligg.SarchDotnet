import { login, logout, getAuthInfo } from '@/api/user'
import { getTokenCooky, setTokenCooky, removeTokenCooky, getLanguageCooky, setLanguageCooky, getTenantCooky, setTenantCooky, getFunctionCooky, setFunctionCooky } from '@/utils/handleCookies'
import { resetRouter } from '@/router'
import { isEmptyString } from '@/utils/validate'

const getDefaultState = () => {
  return {
    token: getTokenCooky(),
    code: '',
    avatarUrl: '',
    roles: [],
    languageCode: getLanguageCooky(),
    tenantCode: getTenantCooky(),
    functionCode: getFunctionCooky(),
    accesibleViews: [],
    accesibleActions: []
  }
}

const state = getDefaultState()

const mutations = {
  RESET_STATE: (state) => {
    Object.assign(state, getDefaultState())
  },
  SET_TOKEN: (state, token) => {
    state.token = token
  },
  SET_USERCODE: (state, code) => {
    state.code = code
  },
  SET_AVATAR: (state, avatarUrl) => {
    state.avatarUrl = avatarUrl
  },
  SET_ROLES: (state, array) => {
    state.roles = array
  },
  SET_LANGUAGE: (state, code) => {
    state.languageCode = code
  },
  SET_TENANT: (state, code) => {
    state.tenantCode = code
  },
  SET_FUNCTION: (state, code) => {
    state.functionCode = code
  },
  SET_ACCESIBLEVIEWS: (state, accesibleControllers) => {
    state.accesibleViews = accesibleControllers
  },
  SET_ACCESIBLEACTIONS: (state, accesibleActions) => {
    state.accesibleActions = accesibleActions
  }
}

const actions = {
  // user login
  login({ commit }, userInfo) {
    const { langugeCode, tenantCode, functionCode, accountType, userCode, password } = userInfo
    return new Promise((resolve, reject) => {
      login({ langueCode: langugeCode, tenantCode: tenantCode, functionCode: functionCode, accountType: accountType, userCode: userCode.trim(), password: password }).then(response => {
        // const { data } = response
        const data = response.result
        commit('SET_TOKEN', data)
        setTokenCooky(data)
        commit('SET_LANGUAGE', langugeCode)
        setLanguageCooky(langugeCode)

        let tenantCode1 = tenantCode
        if (isEmptyString(tenantCode)) {
          tenantCode1 = 'ligg'
        }
        commit('SET_TENANT', tenantCode1)
        setTenantCooky(tenantCode1)
        commit('SET_FUNCTION', functionCode)
        setFunctionCooky(functionCode)
        resolve()
      }).catch(error => {
        reject(error)
      })
    })
  },

  // get user info
  getAuthInfo({ commit, state }) {
    return new Promise((resolve, reject) => {
      getAuthInfo(state.token).then(response => {
        // const { data } = response.result , data undefined
        const data = response.result
        if (!data) {
          return reject('Verification failed, please Login again.')
        }
        commit('SET_USERCODE', data.userCode)
        commit('SET_AVATAR', data.avatarUrl)
        commit('SET_ROLES', data.roleCodes)
        commit('SET_ACCESIBLEVIEWS', data.accesibleViewCodes)
        commit('SET_ACCESIBLEACTIONS', data.accesibleActions)
        resolve(data)
      }).catch(error => {
        reject(error)
      })
    })
  },

  // user logout
  logout({ commit, state }) {
    return new Promise((resolve, reject) => {
      logout(state.token).then(() => {
        removeTokenCooky() // must remove  token  first
        resetRouter()
        commit('RESET_STATE')
        resolve()
      }).catch(error => {
        reject(error)
      })
    })
  },

  // remove token
  resetToken({ commit }) {
    return new Promise(resolve => {
      removeTokenCooky() // must remove  token  first
      commit('RESET_STATE')
      resolve()
    })
  }
}

export default {
  namespaced: true,
  state,
  mutations,
  actions
}

