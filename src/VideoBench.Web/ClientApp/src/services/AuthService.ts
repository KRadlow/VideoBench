import Keycloak from 'keycloak-js';

const keycloack = new Keycloak('/keycloak.json');

const initAuth = () => {
    return keycloack.init({
        onLoad: 'check-sso',
        silentCheckSsoRedirectUri: `${location.origin}/silent-check-sso.html`
    })
}

const login = keycloack.login;

const logout = keycloack.logout;

const isAuthenticated = () => keycloack.authenticated;

const AuthService = {
    initAuth,
    login,
    logout,
    isAuthenticated
}

export default AuthService;