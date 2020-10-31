import React from 'react';
import { Message } from 'semantic-ui-react';

const SelectTimesheet = () => {
  return (
    <Message
      style={{ padding: '50px', position: 'fixed', width: '30%' }}
      icon="hand point left"
      header="Welcome to ETimesheets"
      content="Please select any timesheet to view details."
    />
  );
};

export default SelectTimesheet;
