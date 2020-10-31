import React from 'react';
import { Message, Label, Grid } from 'semantic-ui-react';
import { format } from 'date-fns';

const TimesheetCalculations = ({ timesheet }) => {
  return (
    <Message>
      <Grid columns="2" centered verticalAlign="middle" textAlign="center">
        <Grid.Row>
          <Grid.Column>
            <div>Week Range : 22/7/20 - 29/7/20</div>
          </Grid.Column>
          <Grid.Column>
            <div>Total Days worked :5</div>
          </Grid.Column>
          <Grid.Column>
            <div>Total Hours worked : 40</div>
          </Grid.Column>
          <Grid.Column>
            <div>Total Days Off :2</div>
          </Grid.Column>
        </Grid.Row>
      </Grid>
    </Message>
  );
};

export default TimesheetCalculations;
