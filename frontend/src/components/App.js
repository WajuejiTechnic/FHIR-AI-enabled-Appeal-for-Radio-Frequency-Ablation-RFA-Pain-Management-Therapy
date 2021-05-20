import React from 'react';
import { Router, Route, Switch } from 'react-router-dom';
import PatientEdit from './patients/PatientEdit';
import PatientList from './patients/PatientList';
import PatientShow from './patients/PatientShow';
import PatientReview from './patients/PatientReview';
import PatientDraft from './patients/PatientDraft';
import PatientSubmit from './patients/PatientSubmit';
import PatientSubmitted from './patients/PatientSubmitted';

import Header from './Header';
import history from '../history';

const App = () => {
  return (
    <div className="ui container">
      <Router history={history}>
        <div>
          <Header />
          <Switch>
            <Route path="/" exact component={PatientList} />
            <Route path="/patients/edit/:id" exact component={PatientEdit} />
            <Route path="/patients/:id" exact component={PatientShow} />
            <Route path="/patients/review/:id" exact component={PatientReview} />
            <Route path="/patients/draft/:id" exact component={PatientDraft} />
            <Route path="/patients/submit/:id" exact component={PatientSubmit} />
            <Route path="/patients/submitted/:id" exact component={PatientSubmitted} />
          </Switch>
        </div>
      </Router>
    </div>
  );
};

export default App;
