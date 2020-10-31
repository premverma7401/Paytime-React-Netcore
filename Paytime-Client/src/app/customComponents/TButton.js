import React from 'react';
import { Button } from 'semantic-ui-react';

const TButton = (props) => {
  const { content } = props;
  return <Button content={content} {...props} />;
};

export default TButton;
