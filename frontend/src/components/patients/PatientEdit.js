import React from 'react';
import { connect } from 'react-redux';
import { fetchPatient, editPatient } from '../../actions';
import PatientForm from './PatientForm';

class PatientEdit extends React.Component {
  componentDidMount() {
    console.log('PatientEdit Fetch: patient id: ', this.props.match.params.id);
    this.props.fetchPatient(this.props.match.params.id);
  }

  onSubmit = formValues => {
    console.log('PatientEdit Edit: patient id:', this.props.match.params.id);
    this.props.editPatient(this.props.match.params.id, formValues);
  };

  render() {
    if (!this.props.patient) {
      return <div>Loading...</div>;
    }
    
    return (
      <div>
        <div className="ui ordered steps">
          <div className="active step">
            <div className="content">
              <div className="title">Edit Information</div>
              <div className="description">Modify Patient Information</div>
            </div>
          </div>
          <div className="disable step">
            <div className="content">
              <div className="title">Draft Appeal</div>
              <div className="description">Edit Appeal Letter</div>
            </div>
          </div>
          <div className="disable step">
            <div className="content">
              <div className="title">Submit Appeal</div>
              <div className="description">Submit Appeal Letter</div>
            </div>
          </div>
        </div>
        <PatientForm
          initialValues={this.props.patient}
          onSubmit={this.onSubmit}
        />
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
  return { patient: state.patients[ownProps.match.params.id] };
};

export default connect(
  mapStateToProps,
  { fetchPatient, editPatient }
)(PatientEdit);
