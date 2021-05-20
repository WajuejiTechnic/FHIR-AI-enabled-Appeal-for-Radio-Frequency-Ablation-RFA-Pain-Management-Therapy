import React from 'react';
import { connect } from 'react-redux';
import { fetchPatient, fetchTemplate, reviewPatient } from '../../actions';
import PatientDraftEdit from './PatientDraftEdit';

class PatientDraft extends React.Component {

  async componentWillMount() {
    await this.props.fetchTemplate(this.props.match.params.id);
  }

  onSubmit = formValues => {
    this.props.reviewPatient(this.props.match.params.id, formValues);
  };
  
  render() {
    if (!this.props.patient || !this.props.patient.appealTemplate) {
      return <div>Loading...</div>;
    }
    
    return (
      <div>
        <div className="ui ordered steps">
          <div className="completed step">
            <div className="content">
              <div className="title">Edit Information</div>
              <div className="description">Modify Patient Information</div>
            </div>
          </div>
          <div className="active step">
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
        <PatientDraftEdit
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
  { fetchPatient, fetchTemplate, reviewPatient }
)(PatientDraft);