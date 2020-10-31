import React, { useCallback, useEffect } from 'react';
import { Segment, Tab, Table } from 'semantic-ui-react';

import { eachDayOfInterval, startOfWeek, endOfWeek, add } from 'date-fns';
import { useState } from 'react';
import TimesheetLabel from './TimesheetLabel';
import './timesheet.css';
const TimesheetMain = () => {
  const [weekArrow, setWeekArrow] = useState(0);

  const startDateHandler = add(startOfWeek(new Date(), { weekStartsOn: 1 }), {
    weeks: weekArrow,
  });
  const endDateHandler = endOfWeek(startDateHandler, { weekStartsOn: 1 });

  const daysOfWeek = eachDayOfInterval({
    start: startDateHandler,
    end: endDateHandler,
  });

  const [weekData, setWeekData] = useState({});

  useEffect(() => {
    setWeekData({
      ...weekData,
      dailyData: daysOfWeek.map((days) => ({
        day: days.toDateString(),
        shiftData: [
          {
            siteName: '',
            startTime: '',
            endTime: '',
            totalHours: '',
            notes: '',
          },
        ],
      })),
    });
  }, [weekArrow]);
  console.log('from main', weekData.dailyData);

  const handleChange = useCallback(
    (e, i, s, key) => {
      console.log(e, i, s);
      const inputData = { ...weekData };
      inputData.dailyData[i].shiftData[s] = {
        ...inputData.dailyData[i].shiftData[s],
        [key]: e.target.value,
      };
      setWeekData(inputData);
      console.log(inputData);
    },
    [weekData]
  );
  const onhandleAdd = useCallback(
    (s) => {
      const inputData = { ...weekData };
      inputData.dailyData[s].shiftData.push({
        siteName: '',
        startTime: '',
        endTime: '',
        totalHours: '',
        notes: '',
      });
      setWeekData(inputData);
    },
    [weekData]
  );
  return (
    <Segment>
      <TimesheetLabel weekArrow={weekArrow} setWeekArrow={setWeekArrow} />

      {weekData.dailyData &&
        weekData.dailyData.map((daily, i) => (
          <div className="daily-row">
            <div>{daily.day}</div>

            {daily.shiftData &&
              daily.shiftData.map((shift, s) => (
                <div>
                  {Object.entries(shift).map(([key, value]) => (
                    <div className="each-row">
                      <input
                        value={value}
                        onChange={(e) => handleChange(e, i, s, key)}
                      />
                    </div>
                  ))}
                  <button onClick={() => onhandleAdd(i)}>Add</button>
                </div>
              ))}
          </div>
        ))}
    </Segment>
  );
};

export default TimesheetMain;
