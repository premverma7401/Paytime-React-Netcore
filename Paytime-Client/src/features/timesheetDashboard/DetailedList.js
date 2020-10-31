import React, { Fragment, useContext } from 'react';
import { Table } from 'semantic-ui-react';
import { format } from 'date-fns';
import { observer } from 'mobx-react-lite';
import TimesheetLabel from '../create/TimesheetLabel';
import TimesheetStore from '../../app/store/TimesheetStore';
import SelectTimesheet from './SelectTimesheet';

const DetailedList = ({ timesheet }) => {
  const sideCardStyle = {
    position: '-webkit-sticky sticky',
    top: '50px',
  };

  return (
    <>
      {timesheet && timesheet.length > 1 ? (
        <Table style={sideCardStyle}>
          <tbody>
            {timesheet &&
              timesheet.map((ts, j) => (
                <tr key={j}>
                  <Fragment>
                    <td>{format(Date.parse(ts.day), 'PPPP')}</td>
                    {ts.shiftData.map((sd, i) => (
                      <Fragment key={i}>
                        <td>{sd.siteName}</td>
                        <td>
                          {sd.startTime &&
                            format(Date.parse(sd.startTime), 'p')}
                        </td>
                        <td>
                          {sd.endTime && format(Date.parse(sd.endTime), 'p')}
                        </td>
                        <td>{sd.shiftHourTotal}</td>
                        <td>{sd.shiftNotes}</td>
                      </Fragment>
                    ))}
                  </Fragment>
                </tr>
              ))}
          </tbody>
        </Table>
      ) : (
        <SelectTimesheet />
      )}
    </>
  );
};

export default observer(DetailedList);
