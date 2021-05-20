import React from 'react';
import { connect } from 'react-redux';
import { fetchPatient } from '../../actions';

class PatientShow extends React.Component {
  
  componentDidMount() {
    const { id } = this.props.match.params;

    this.props.fetchPatient(id);
  }

  render() {
    if (!this.props.patient) {
      return <div>Loading...</div>;
    }

    const { name, birthDate } = this.props.patient;

    return (
      <div>
        <h1>{name}</h1>
        <h5>{birthDate}</h5>
      </div>
    );
  }
}

const mapStateToProps = (state, ownProps) => {
  return { patient: state.patients[ownProps.match.params.id] };
};

export default connect(
  mapStateToProps,
  { fetchPatient }
)(PatientShow);
