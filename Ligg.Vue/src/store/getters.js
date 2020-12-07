const getters = {
  sidebar: state => state.app.sidebar,
  device: state => state.app.device,
  token: state => state.user.token,
  avatarUrl: state => state.user.avatarUrl,
  userCode: state => state.user.code,
  languageCode: state => state.user.languageCode,
  tenantCode: state => state.user.tenantCode,
  functionCode: state => state.user.functionCode,
  roles: state => state.user.roles,
  accesibleViews: state => state.user.accesibleViews,
  accesibleActions: state => state.user.accesibleActions,
  user_routes: state => state.user.routes,
  authorization_routes: state => state.authorization.routes
}
export default getters
