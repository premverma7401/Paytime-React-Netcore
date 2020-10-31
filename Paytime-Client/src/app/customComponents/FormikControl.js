import React from 'react';
import TextfieldInput from './TextfieldInput';
import TextAreaInput from './TextAreaInput';
import TimeInput from './TimeInput';

const FormikControl = (props) => {
  const { control, ...rest } = props;
  switch (control) {
    case 'input':
      return <TextfieldInput {...rest} />;
    case 'textarea':
      return <TextAreaInput {...rest} />;
    case 'time':
      return <TimeInput {...rest} />;
    default:
      return null;
  }
};

export default FormikControl;
