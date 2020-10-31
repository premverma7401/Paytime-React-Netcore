import React from 'react';
import { Link } from 'react-router-dom';
import { Segment, Container, Header, Image, Button } from 'semantic-ui-react';

const Homepage = () => {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image
            size="massive"
            src="logo512.png"
            alt="logo"
            style={{ marginBottom: 12 }}
          />
          ETimesheets
        </Header>
        <Header as="h2" inverted content="Welcome to ETimesheetsa" />
        <Button as={Link} to="/dashboard" size="huge" inverted>
          Take me to the Timesheet Portal!
        </Button>
      </Container>
    </Segment>
  );
};

export default Homepage;
