import React from 'react';
import { useField, useFormikContext } from 'formik';
import DatePicker from 'react-datepicker';

export const TimeInput = ({ ...props }) => {
  const { setFieldValue } = useFormikContext();
  const [field] = useField(props);
  return (
    <DatePicker
      className="form-control inputStyle"
      {...field}
      {...props}
      selected={(field.value && new Date(field.value)) || null}
      onChange={(val) => {
        setFieldValue(field.name, val);
      }}
      timeCaption="Time"
      dateFormat="h:mm aa"
      showTimeSelect
      showTimeSelectOnly
      timeIntervals={15}
    />
  );
};

export default TimeInput;
