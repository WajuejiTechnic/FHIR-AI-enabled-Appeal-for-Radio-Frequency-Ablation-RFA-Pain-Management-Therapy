import React from 'react';
import { Link } from 'react-router-dom';

const Header = () => {
  return (
    <div className="ui secondary pointing menu">
      <Link to="/" className="ui button">
        Case List
      </Link>
      <div className="right menu">
        <Link to="/" className="ui button">
          All Cases
        </Link>
      </div>
    </div>
  );
};

export default Header;
