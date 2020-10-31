import React, { useState } from 'react';
import { Button } from 'semantic-ui-react';

const Learn = () => {
  const [learn, setLearn] = useState(0);

  return (
    <div>
      <Button positive content="Click" onClick={() => setLearn(learn + 1)} />
      {learn}
      <Button positive content="Click" onClick={() => setLearn(0)} />
      {learn}
    </div>
  );
};

export default Learn;
