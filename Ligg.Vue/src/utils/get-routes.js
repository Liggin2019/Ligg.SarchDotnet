import store from '@/store'
export function getRoutes() {
  const funcCode = store.getters.functionCode
  const js = funcCode + '.js'
  const routesData = require('@/data/routes/' + js)

  // const path = '@/data/routes/' + funcCode + '.js'
  // const routesData = require(path)

  const dt = routesData.data
  return {
    code: 20000,
    data: dt
  }
}

