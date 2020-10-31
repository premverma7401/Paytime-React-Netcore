import { action, computed, observable, values } from 'mobx';
import agent from '../api/agent';

login = async (values) => {
  try {
    const user = await agent.Account.login(values);
    user = user;
  } catch (error) {
    console.log(error);
  }
};

isLoggedIn = () => {
  return !!this.user;
};
decorate(UserStore, {
  user: observable,
  isLoggedIn: computed,
  login: action,
});
export default createContext(new UserStore());
