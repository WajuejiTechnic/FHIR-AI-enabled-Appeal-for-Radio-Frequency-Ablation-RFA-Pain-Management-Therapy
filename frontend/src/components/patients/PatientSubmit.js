import React from 'react';
import {connect} from 'react-redux';
import {fetchPatient, submitPatient} from '../../actions';
import PatientSubmitEdit from './PatientSubmitEdit';


class PatientSubmit extends React.Component {

  componentDidMount() {
    console.log('PatientSubmit Fetch: patient id: ', this.props.match.params.id);
    this.id = this.props.match.params.id;
    this.props.fetchPatient(this.props.match.params.id);
  }

  onSubmit = formValues => {
    this.props.submitPatient(this.props.match.params.id, formValues);
  };

  id = null;

  render() {
    if (!this.props.patient) {
      console.log(this.props);
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
          <div className="completed step">
            <div className="content">
              <div className="title">Draft Appeal</div>
              <div className="description">Edit Appeal Letter</div>
            </div>
          </div>
          <div className="active step">
            <div className="content">
              <div className="title">Submit Appeal</div>
              <div className="description">Submit Appeal Letter</div>
            </div>
          </div>
        </div>
        <PatientSubmitEdit
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
  {fetchPatient, submitPatient}
)(PatientSubmit);