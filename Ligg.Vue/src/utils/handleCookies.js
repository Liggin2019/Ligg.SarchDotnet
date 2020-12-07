import Cookies from 'js-cookie'

const TokenKey = 'token'

export function getTokenCooky() {
  return Cookies.get(TokenKey)
}

export function setTokenCooky(token) {
  return Cookies.set(TokenKey, token)
}

export function removeTokenCooky() {
  return Cookies.remove(TokenKey)
}

export function getLanguageCooky() {
  return Cookies.get('language')
}

export function setLanguageCooky(str) {
  return Cookies.set('language', str)
}

export function getTenantCooky() {
  return Cookies.get('tenant')
}

export function setTenantCooky(str) {
  return Cookies.set('tenant', str)
}

export function getFunctionCooky() {
  const fCode = Cookies.get('function')
  return fCode
}

export function setFunctionCooky(str) {
  return Cookies.set('function', str)
}

