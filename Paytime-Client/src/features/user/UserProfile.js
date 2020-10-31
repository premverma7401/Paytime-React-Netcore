import React, { Fragment, useState, useEffect } from 'react';
import { Segment, Grid, Image, Button, Input } from 'semantic-ui-react';
import { Formik, Form } from 'formik';
import FormikControl from '../../app/customComponents/FormikControl';
import Axios from 'axios';

const UserProfile = () => {
  const [userProfile, setUserProfile] = useState({});

  useEffect(() => {
    fetchUserProfile();
  }, []);

  const fetchUserProfile = async () => {
    await Axios.get(
      'http://localhost:5000/api/User/premsager?username=premsager'
    ).then((response) => {
      let userProfile = response.data;
      setUserProfile(userProfile);
    });
  };

  const initialValues = {
    firstName: '',
    lastName: '',
    displayName: '',
    contract: '',
    coa: '',
    userName: '',
    email: '',
    phoneNumber: '',
    image: null,
  };
  const handleSubmit = (values) => {};
  return (
    <Segment raised clearing>
      <Formik
        initialValues={userProfile || initialValues}
        onSubmit={handleSubmit}
        enableReinitialize
      >
        {({ values }) => (
          <Form autoComplete="off">
            <Grid columns={3} divided padded>
              <Grid.Row stretched>
                <Grid.Column>
                  <Fragment>
                    <Segment>
                      <Image src="/user.png" alt="image" />
                    </Segment>
                    <Input type="file" />

                    {/* <Button.Group widths="2">
                      <Button content="Upload" icon="upload" color="blue">
                      </Button>
                      <Button content="Remove" icon="delete" color="red" />
                    </Button.Group> */}
                  </Fragment>
                </Grid.Column>
                <Grid.Column>
                  <FormikControl
                    control="input"
                    placeholder="First Name"
                    name="firstName"
                    label="First Name"
                  />
                  <FormikControl
                    control="input"
                    placeholder="User Name"
                    name="userName"
                    label="User Name"
                  />
                  <FormikControl
                    control="input"
                    placeholder="Email Address"
                    name="email"
                    type="email"
                    label="Email Address"
                  />
                  <FormikControl
                    control="input"
                    placeholder="Mobile"
                    name="phone"
                    label="Phone"
                  />
                </Grid.Column>

                <Grid.Column>
                  <FormikControl
                    control="input"
                    placeholder="Last Name"
                    name="lastName"
                    label="Last Name"
                  />
                  <FormikControl
                    control="input"
                    placeholder="Display Name"
                    name="displayName"
                    label="Display Name"
                  />
                  <FormikControl
                    label="COA"
                    control="input"
                    placeholder="COA"
                    name="coa"
                  />
                  <FormikControl
                    control="input"
                    placeholder="Contract Type"
                    name="contract"
                    label="Contract Type"
                  />
                </Grid.Column>
              </Grid.Row>
              <Grid.Column floated="right">
                <Button.Group widths="2">
                  <Button content="Save" positive type="submit" />
                  <Button content="Reset" type="reset" color="blue" />
                </Button.Group>
              </Grid.Column>
            </Grid>
          </Form>
        )}
      </Formik>
    </Segment>
  );
};

export default UserProfile;
