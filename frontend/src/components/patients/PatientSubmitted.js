import React from 'react';
import { submittedPatient } from '../../actions';
import {connect} from "react-redux";

class PatientSubmitted extends React.Component{

  componentDidMount() {
    const { id } = this.props.match.params;
    this.props.submittedPatient(id);
  }

  render() {

    if (!this.props.patient) {
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
          <div className="completed step">
            <div className="content">
              <div className="title">Submit Appeal</div>
              <div className="description">Submit Appeal Letter</div>
            </div>
          </div>
        </div>
        <h3 className="ui dividing header">Patient Information</h3>
        <table className="ui celled table">
          <thead>
          <tr>
            <th>Appeal for</th>
            <th>DOB</th>
          </tr>
          </thead>
          <tbody>
          <tr>
            <td data-label="Appeal for">{this.props.patient.name}</td>
            <td data-label="DOB">{this.props.patient.birthDate}</td>
          </tr>
          </tbody>
        </table>
        <div className="ui centered large image">
          <img alt="Submitted" src={require('./submit_image.png')} />
        </div>
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
  return {patient: state.patients[ownProps.match.params.id]};
};

export default connect(
  mapStateToProps,
  { submittedPatient }
)(PatientSubmitted);
