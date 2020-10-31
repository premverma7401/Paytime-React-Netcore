import React, { Fragment } from 'react';
import { Segment, Header, Image, Message } from 'semantic-ui-react';
import { format } from 'date-fns';

const TimesheetHeader = () => {
  return (
    <Fragment>
      <Segment clearing attached>
        <Header as="h5" floated="right">
          {format(new Date(), 'eeee do MMMM')}
        </Header>
        <Header as="h5" floated="left">
          <img src="user.png" alt="logo" />
          Prem Sager
        </Header>

        <Image centered size="medium" src="logo.png" />

        <Header as="h5" textAlign="center">
          Timesheet
        </Header>
        <Message>
          <Message.Header>Reminder</Message.Header>
          <p>
            Please submit your timesheet no later than 9am Monday, following the
            week being claimed..
          </p>
        </Message>
      </Segment>
    </Fragment>
  );
};

export default TimesheetHeader;
