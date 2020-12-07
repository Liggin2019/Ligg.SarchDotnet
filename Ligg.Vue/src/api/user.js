import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/UsrAth/Login',
    method: 'post',
    data
  })
}

export function getAuthInfo(token) {
  return request({
    url: '/UsrRlv/GetAuthInfo',
    method: 'post'
    // params: { token }
  })
}

export function logout() {
  return request({
    url: '/user/logout',
    method: 'post'
  })
}
