
export function getAvailablefunctions(tenantCode) {
  let availableApps = []
  if (tenantCode === '') {
    availableApps = ['pserv']
  } else {
    const settingJs = tenantCode + '-setting.js'
    const settingData = require('@/data/tenant/' + settingJs)
    availableApps = settingData.availableApps
  }

  const funcs = require('@/data/functions.js')
  const funcsData = funcs.data
  const availableFuncs = []
  for (const val of availableApps) {
    const appFuncs = funcsData.filter(x => x.app === val)
    for (const val1 of appFuncs[0].functions) {
      availableFuncs.push(val1)
    }
  }
  return {
    code: 20000,
    data: availableFuncs
  }
}

export function getAppInfo(funcCode) {
  const funcs = require('@/data/functions.js')
  const funcsData = funcs.data
  let appCode = ''
  let appName = ''
  let appDes = ''
  for (const val of funcsData) {
    const funcs = val.functions
    for (const val1 of funcs) {
      if (val1.code === funcCode) {
        appCode = val.app
        appName = val.name
        appDes = val.description
        break
      }
    }
  }
  return {
    code: 20000,
    data: { appCode: appCode, appName: appName, appDes: appDes }
  }
}

