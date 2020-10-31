import React, { Fragment, useContext } from 'react';
import { Button, Card, Image } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { format } from 'date-fns';
import TimesheetStore from '../../app/store/TimesheetStore';

const QuickList = ({ timesheetList }) => {
  const timesheetStore = useContext(TimesheetStore);
  const { selectTimesheet } = timesheetStore;
  return (
    <Fragment>
      {timesheetList.map((ts) => (
        <Card key={ts.tsheetId} fluid>
          <Card.Content>
            <Image floated="right" size="tiny" src="/logo.png" />
            <Card.Header>{ts.mainSite}</Card.Header>
            <Card.Meta>Week Range : {ts.weekRange}</Card.Meta>
            <Card.Description>
              Total Hours : {ts.weekHoursTotal}
            </Card.Description>
            <Card.Description>Days Worked : {ts.daysWorked}</Card.Description>
            <Card.Description>Days Off : {ts.daysOff}</Card.Description>
            <Card.Description>
              Sent at : {format(Date.parse(ts.created), 'PPPP')}
            </Card.Description>
          </Card.Content>
          <Card.Content extra>
            <Button
              basic
              floated="right"
              color="green"
              onClick={() => {
                selectTimesheet(ts.tsheetId);
              }}
            >
              View Details
            </Button>
          </Card.Content>
        </Card>
      ))}
    </Fragment>
  );
};

export default observer(QuickList);
