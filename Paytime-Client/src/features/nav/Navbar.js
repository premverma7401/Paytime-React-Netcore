import React from 'react';
import { Menu, Container, Button, Image, Dropdown } from 'semantic-ui-react';
import { NavLink, Link } from 'react-router-dom';

const Navbar = () => {
  return (
    <Menu fixed="top" inverted>
      <Container>
        <Menu.Item exact name="" as={NavLink} to="/">
          <img src="/logo512.png" alt="logo" style={{ marginRight: '10px' }} />
          Timesheets
        </Menu.Item>
        <Menu.Item name="Dashboard" as={NavLink} to="/dashboard" />
        <Menu.Item>
          <Button
            as={NavLink}
            to="/create"
            positive
            content="Create Timesheet"
          />
        </Menu.Item>

        <Menu.Item position="right">
          <Image avatar spaced="right" src="/user.png" />
          <Dropdown pointing="top left" text="User">
            <Dropdown.Menu>
              <Dropdown.Item
                as={Link}
                to={`/profile/username`}
                text="My profile"
                icon="user"
              />
              <Dropdown.Item text="Logout" icon="power" />
            </Dropdown.Menu>
          </Dropdown>
        </Menu.Item>
        <Menu.Item>
          <Button.Group floated="right">
            <Button as={NavLink} to="/login" positive content="Login" />
            <Button as={NavLink} to="/register" positive content="Register" />
          </Button.Group>
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default Navbar;
