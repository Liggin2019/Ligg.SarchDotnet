
export function validateTenantCode(str) {
  if (str === null || typeof str === 'undefined' || str === '') return true
  const tenants = require('@/data/tenants.js')
  const tenantCodes = []
  for (const val of tenants.data) {
    tenantCodes.push(val.code)
  }
  return tenantCodes.indexOf(str.trim()) >= 0
}

export function validateUserCode(str) {
  const validate_map = ['admin', 'job.li', 'bill.li']
  return validate_map.indexOf(str.trim()) >= 0
}

export function isEmptyString(str) {
  if (str === null || typeof str === 'undefined' || str.trim() === '') {
    return true
  } else {
    return false
  }
}

export function isExternal(path) {
  return /^(https?:|mailto:|tel:)/.test(path)
}
