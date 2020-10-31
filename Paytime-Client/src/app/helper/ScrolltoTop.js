import { useEffect } from 'react';
import { withRouter } from 'react-router-dom';

const ScrolltoTop = ({ children, location: { pathname } }) => {
  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);
  return children;
};

export default withRouter(ScrolltoTop);
