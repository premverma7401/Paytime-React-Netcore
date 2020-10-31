import { format } from 'date-fns/esm/fp';
import React, { useState } from 'react';

const LearningComponent = ({ weekDays }) => {
  const [site, setSite] = useState([
    {
      days: weekDays.days, // shiftData: [
      //   {
      //     sitename: '',
      //   },
      // ],
    },
  ]);
  console.log('hellpo', site);

  const handleChange = (e) => {
    const siteInfo = { ...site };
    siteInfo[e.target.name] = e.target.value;
    console.log(siteInfo);
  };
  return (
    <div>
      {/* {site.days.map((days, i) => (
        <div key={i}>
          <div> {days.toDateString()} </div>
          <div>
            <input
              type="text "
              name={`sitename${i}`}
              value={site.sitename}
              onChange={(e) => handleChange(e)}
            />
          </div>
        </div>
      ))} */}
    </div>
  );
};

export default LearningComponent;
