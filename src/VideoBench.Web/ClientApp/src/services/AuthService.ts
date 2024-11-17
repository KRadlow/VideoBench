import Keycloak from 'keycloak-js';


const keycloak = new Keycloak(process.env.PUBLIC_URL + '/keycloak.json')

const initAuth = (onAuthenticatedCallback: Function) => {
  keycloak
    .init({
      onLoad: "check-sso",
      pkceMethod: 'S256'
    })
    .then(() => {
      onAuthenticatedCallback();
    })
    .catch((e) => {
      console.log(`Init exception: ${e}`);
    });
};

const getUserName = () => keycloak.tokenParsed?.preferred_username;

const login = keycloak.login;

const register = keycloak.register;

const logout = keycloak.logout;

const isLoggedIn = () => !!keycloak.token;

const getToken = () => keycloak.token;

const updateToken = (callback: any) =>
  keycloak.updateToken(5).then(callback).catch(logout);

const AuthService = {
  initAuth,
  login,
  register,
  logout,
  isLoggedIn,
  getToken,
  updateToken,
  getUserName
}

export default AuthService;