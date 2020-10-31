import { createContext } from 'react';
import { observable, action, decorate, computed } from 'mobx';
import agent from '../api/agent';

class TimesheetStore {
  timesheetRegister = new Map();
  selectTimesheet = {};
  loadingInitial = false;

  get timesheetList() {
    return Array.from(this.timesheetRegister.values());
  }

  loadTimesheets = async () => {
    this.loadingInitial = true;
    try {
      const timesheets = await agent.Timesheets.list();
      timesheets.forEach((tRes) => {
        this.timesheetRegister.set(tRes.tsheetId, tRes);
      });
      this.loadingInitial = false;
    } catch (error) {}
  };

  loadTimesheet = async (id) => {
    this.loadingInitial = true;
    try {
      var timesheet = await agent.Timesheets.details(id);
      this.selectedTimesheet = timesheet;
      this.loadingInitial = false;
    } catch (error) {
      console.log(error);
    }
  };
  selectTimesheet = (id) => {
    this.loadTimesheet(id);
  };
}
decorate(TimesheetStore, {
  timesheetRegister: observable,
  selectTimesheet: observable,
  selectedTimesheet: observable,
  loadingInitial: observable,
  loadTimesheets: action,
  loadTimesheet: action,
  timesheetList: computed,
});
export default createContext(new TimesheetStore());
