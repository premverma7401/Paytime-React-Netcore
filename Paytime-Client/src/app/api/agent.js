import axios from 'axios';
import { history } from '../../index';
import { toast } from 'react-toastify';

axios.defaults.baseURL = 'http://localhost:5000/api';

axios.interceptors.response.use(undefined, (error) => {
  // check network error object
  if (error.message === 'Network Error' && !error.response) {
    toast.error('Network Error, Check API Server');
  }
  const { status } = error.response;
  // check if status 404
  if (status === 404) {
    history.push('/notfound');
  }
  // check if 500 internal server
  if (status === 500) {
    toast.error('Server Error');
  }
});

const responseBody = (response) => response.data;

const sleep = (ms) => (response) =>
  new Promise((resolve) => setTimeout(() => resolve(response), ms));

const request = {
  get: (url) => axios.get(url).then(sleep(500)).then(responseBody),
  post: (url, body) => axios.post(url, body).then(responseBody),
  put: (url, body) => axios.put(url, body).then(responseBody),
};

const Timesheets = {
  list: () => request.get('/timesheet/summary'),
  details: (id) => request.get(`/timesheet/summary/${id}/detail`),
  create: (timesheet) => request.post('/timesheet', timesheet),
  update: (timesheet, id) => request.put(`/timesheet/${id}`, timesheet),
};
const Account = {
  current: () => request.get('/Account/currentUser'),
  login: (user) => request.post(`/Account/login`, user),
  register: (user) => request.post(`/Account/register`, user),
};

export default { Timesheets, Account };
