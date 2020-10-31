import React from 'react';
import { Label } from 'semantic-ui-react';

const TLabel = (props) => {
  const { content } = props;
  return (
    <div>
      <Label content={content} {...props} />
    </div>
  );
};

export default TLabel;
