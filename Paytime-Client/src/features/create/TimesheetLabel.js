import React, { Fragment } from 'react';
import { Icon } from 'semantic-ui-react';

const TimesheetLabel = ({ setWeekArrow, weekArrow }) => {
  return (
    <Fragment>
      <Icon
        size="big"
        name="arrow left"
        onClick={() => {
          setWeekArrow(weekArrow - 1);
        }}
      />
      <Icon
        size="big"
        name="circle"
        onClick={() => {
          setWeekArrow(weekArrow * 0);
        }}
      />

      <Icon
        size="big"
        name="arrow right"
        onClick={() => {
          setWeekArrow(weekArrow + 1);
        }}
      />
      <table>
        <thead>
          <tr>
            <th>Day & Date</th>
            <th>Site Name</th>
            <th>Start Time</th>
            <th>End Time</th>
            <th>Hours</th>
            <th>Notes</th>
          </tr>
        </thead>
      </table>
    </Fragment>
  );
};

export default TimesheetLabel;
