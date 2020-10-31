import React, { Fragment } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Route, withRouter, Switch } from 'react-router-dom';
import { Container } from 'semantic-ui-react';
import { ToastContainer } from 'react-toastify';
import { observer } from 'mobx-react-lite';
import Login from './features/auth/Login';
import Register from './features/auth/Register';
import Navbar from './features/nav/Navbar';
import TimesheetMain from './features/create/TimesheetMain';
import TimesheetDashboard from './features/timesheetDashboard/TimesheetDashboard';
import Homepage from './features/homepage/Homepage';
import UserProfile from './features/user/UserProfile';
import DetailedList from './features/timesheetDashboard/DetailedList';
import NotFound from './app/layout/NotFound';

function App() {
  return (
    <Fragment>
      <ToastContainer position="bottom-right" />
      <Route path="/" exact component={Homepage} />
      <Route
        path={'/(.+)'}
        render={() => (
          <Fragment>
            <Navbar />
            <Container style={{ marginTop: '5em' }}>
              <Switch>
                <Route path="/dashboard" component={TimesheetDashboard} />
                <Route path="/dashboard/:id" component={DetailedList} />
                <Route path="/login" component={Login} />
                <Route path="/create" component={TimesheetMain} />
                <Route path="/register" component={Register} />
                <Route path="/profile/username" component={UserProfile} />
                <Route component={NotFound} />
              </Switch>
            </Container>
          </Fragment>
        )}
      ></Route>
    </Fragment>
  );
}

export default withRouter(observer(App));
