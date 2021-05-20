import React from 'react';
import { connect } from 'react-redux';
// import { Link } from 'react-router-dom';
import { fetchPatients } from '../../actions';
import history from '../../history';

class PatientList extends React.Component {
  componentDidMount() {
    this.props.fetchPatients();
  }

  renderAdmin (patient) {
    if (!patient.hasBeenSubmitted) {
      return (
        <div className="right floated content">
          <button onClick={()=> {history.push(`/patients/edit/${patient.id}`);}} className="ui primary button">
            Appeal
          </button>
        </div>
          );
    }
    
    if (patient.hasBeenSubmitted) {
      return (
        <div className="right floated content">
          <button onClick={()=> {history.push(`/patients/submit/${patient.id}`);}} className="ui button negative">
            Review
          </button>
        </div>
      );
    }
  };
  
  renderList() {
    return this.props.patients.map(patient => {
      if (patient === "") {
        return;
      }
      return (
        <tr key={patient.id}>
          <td data-label="ID">{patient.id}</td>
          <td data-label="Patient Name"><i className="large middle aligned icon id badge" />{patient.name}</td>
          <td data-label="DOB">{patient.birthDate}</td>
          <td data-label="Action">{this.renderAdmin(patient)}</td>
        </tr>
      );
    });
  }

  render() {
    return (
      <div>
        <h2>Patients</h2>
        <table className="ui celled table">
          <thead>
          <tr>
            <th>ID</th>
            <th>Patient Name</th>
            <th>DOB</th>
            <th>Action</th>
          </tr>
          </thead>
          <tbody>
            {this.renderList()}
          </tbody>
        </table>

        
        
      </div>
    );
  }
}

const mapStateToProps = state => {
  return {
    patients: Object.values(state.patients)
  };
};

export default connect(
  mapStateToProps,
  { fetchPatients }
)(PatientList);
