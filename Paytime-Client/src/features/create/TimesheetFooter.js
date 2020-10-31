import React from 'react';
import {
  List,
  Divider,
  Header,
  Icon,
  Button,
  Statistic,
} from 'semantic-ui-react';
import TButton from '../../app/customComponents/TButton';

const TimesheetFooter = ({ sendEmail }) => {
  return (
    <div style={{ marginTop: '20px' }}>
      {/*   
  "weekHoursTotal": 50.0,
    "daysWorked": 5,
    "daysOff": 2,
 */}
      <Divider horizontal>
        <Header as="h4">
          <Icon name="tag" />
          Confirm
        </Header>
      </Divider>
      <List horizontal relaxed="very">
        <List.Item>
          <List.Content>
            <List.Header as="a">Week Hour Total</List.Header>
            <Statistic.Value>40</Statistic.Value>
          </List.Content>
        </List.Item>
        <List.Item>
          <List.Content>
            <List.Header as="a">Total Days Worked</List.Header>
            <Statistic.Value>5</Statistic.Value>
          </List.Content>
        </List.Item>
        <List.Item>
          <List.Content>
            <List.Header as="a">Total Days Off</List.Header>
            <Statistic.Value>2</Statistic.Value>
          </List.Content>
        </List.Item>
      </List>
      <Button.Group fluid>
        <TButton
          content="Send To Simply"
          color="teal"
          onClick={sendEmail}
          type="button"
        />
        <TButton content="Save" color="blue" type="submit" />
        <TButton content="Reset" color="red" type="reset" />
      </Button.Group>
    </div>
  );
};

export default TimesheetFooter;
