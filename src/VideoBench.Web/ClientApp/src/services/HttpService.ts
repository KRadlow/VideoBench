import axios from 'axios';
import AuthService from './AuthService';

const HttpMethods = {
  GET: 'GET',
  POST: 'POST',
}

const axiosClient = axios.create({ baseURL: 'http://localhost:5000' });

const configure = () => {
  axiosClient.interceptors.request.use((config: any) => {
    if (AuthService.isLoggedIn()) {
      const cb = () => {
        config.headers.Authorization = `Bearer ${AuthService.getToken()}`;
        return Promise.resolve(config);
      };
      return AuthService.updateToken(cb);
    }
    return config;
  });
};

const getClient = () => axiosClient;

const HttpService = {
  HttpMethods,
  getClient,
  configure
}

export default HttpService;