import Keycloak from 'keycloak-js';


const keycloak = new Keycloak(process.env.PUBLIC_URL + '/keycloak.json')

const initAuth = async () => {
  try {
    return await keycloak.init({
      onLoad: 'check-sso',
      silentCheckSsoRedirectUri: window.location.origin + process.env.PUBLIC_URL + '/silent-check-sso.html',
      checkLoginIframe: false,
      pkceMethod: 'S256'
    });
  } catch (message) {
    return console.error(message);
  }
}

const login = keycloak.login;

const logout = keycloak.logout;

const isAuthenticated = () => keycloak.authenticated;

const getToken = () => keycloak.token;

const updateToken = async (callback?: any) => {
  try {
    await keycloak.updateToken(60);
    if (callback) {
      callback();
    }
  } catch {
    logout();
  }
}

const AuthService = {
  initAuth,
  login,
  logout,
  isAuthenticated,
  getToken,
  updateToken
}

export default AuthService;