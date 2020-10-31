import React, { useEffect, Fragment, useContext } from 'react';
import { Grid } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import QuickList from './QuickList';
import DetailedList from './DetailedList';
import LoadingComponent from '../../app/customComponents/LoadingComponent';
import TimesheetStore from '../../app/store/TimesheetStore';
import NotFound from '../../app/layout/NotFound';
import TimesheetCalculations from './TimesheetCalculations';

const TimesheetDashboard = () => {
  const timesheetStore = useContext(TimesheetStore);
  const {
    timesheetList,
    selectedTimesheet: timesheet,
    loadTimesheets,
    loadingInitial,
  } = timesheetStore;

  useEffect(() => {
    loadTimesheets();
  }, [loadTimesheets]);

  if (loadingInitial)
    return <LoadingComponent content="Timesheet are loading...." />;
  if (!timesheetList) return <h1> Timesheets not found</h1>;

  return (
    <Fragment>
      <Grid style={{ marginTop: '40px' }}>
        <Grid.Column width="6">
          <QuickList timesheetList={timesheetList} />
        </Grid.Column>
        <Grid.Column width="10">
          <DetailedList timesheet={timesheet} />
          {timesheet && <TimesheetCalculations timesheet={timesheet} />}
        </Grid.Column>
      </Grid>
    </Fragment>
  );
};

export default observer(TimesheetDashboard);
