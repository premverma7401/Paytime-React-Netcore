import React from 'react';
import { Field } from 'formik';

function TextfieldInput(props) {
  const { name, label, ...rest } = props;

  return (
    <div>
      <label style={{ fontSize: 'medium', fontWeight: 'bold' }} htmlFor={name}>
        {label}
        <Field className="form-control" id={name} name={name} {...rest} />
      </label>
    </div>
  );
}

export default TextfieldInput;
