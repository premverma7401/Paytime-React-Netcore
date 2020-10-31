import React from 'react';
import { Field } from 'formik';

const TextAreaInput = (props) => {
  const { name, ...rest } = props;

  return (
    <Field
      className="form-control"
      id={name}
      name={name}
      as="textarea"
      {...rest}
    />
  );
};

export default TextAreaInput;
