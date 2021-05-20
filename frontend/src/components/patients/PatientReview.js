import React from 'react';
import { connect } from 'react-redux';
import { fetchPatient } from '../../actions';

class PatientReview extends React.Component {
  
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
        <div>
          <div className="ui ordered steps">
            <div className="completed step">
              <div className="content">
                <div className="title">Edit Information</div>
                <div className="description">modify patient information</div>
              </div>
            </div>
            <div className="completed step">
              <div className="content">
                <div className="title">Draft Appeal</div>
                <div className="description">Edit appeal letter</div>
              </div>
            </div>
            <div className="active step">
              <div className="content">
                <div className="title">Preview Appeal</div>
                <div className="description">review appeal letter</div>
              </div>
            </div>
          </div>
        </div>
        <h3>Submit Review</h3>
        <h3>{name}</h3>
        <h3>{birthDate}</h3>
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
)(PatientReview);