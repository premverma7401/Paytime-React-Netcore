import React, { Fragment, useState } from 'react';
import { Button, Grid, Divider, Segment } from 'semantic-ui-react';
import { Form, Formik, FieldArray } from 'formik';
import { eachDayOfInterval, format, startOfWeek, endOfWeek } from 'date-fns';
import FormikControl from '../../app/customComponents/FormikControl';
import TimeInput from '../../app/customComponents/TimeInput';
import TimesheetLabel from './TimesheetLabel';
import TButton from '../../app/customComponents/TButton';
import agent from '../../app/api/agent';
import { observer } from 'mobx-react-lite';

const TimesheetCreate = ({ weekData }) => {
  const inputStyle = {
    width: '100%',
    padding: '10px',
    height: '50px',
  };
  const [timesheet, setTimesheet] = useState({
    dailyData: [
      {
        days: weekData,
        ShiftData: [
          {
            siteName: '',
          },
        ],
      },
    ],
  });

  const handleChange = (e) => {
    const tSheet = { ...timesheet };
    tSheet[e.target.name] = e.target.value;
    console.log(tSheet);
  };
  return (
    <Fragment>
      <Segment>
        {timesheet.dailyData.map(({ days, ShiftData }, d) => (
          <div>
            {/* {format(days, 'PPPP')} */}
            {ShiftData.map((sd, s) => (
              <input
                type="text"
                placeholder="sitename"
                value={timesheet.dailyData.day}
                onChange={handleChange}
                name={`dailyData.${d}.ShiftData.${s}.siteName`}
              />
            ))}
          </div>
        ))}
      </Segment>
    </Fragment>
  );
};

export default observer(TimesheetCreate);
