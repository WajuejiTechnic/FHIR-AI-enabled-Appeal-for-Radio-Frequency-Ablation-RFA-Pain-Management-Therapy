import React from 'react';
import { Field, reduxForm } from 'redux-form';

class PatientForm extends React.Component {
  onSubmit = formValues => {
    this.props.onSubmit(formValues);
  };
  
  render() {
    return (
      <div>
        <h3 className="ui dividing header">Patient Information</h3>
        <table className="ui celled table">
          <thead>
          <tr>
            <th>Name</th>
            <th>DOB</th>
            <th>Gender</th>
            <th>Marital Status</th>
            <th>Race</th>
            <th>Language</th>
          </tr>
          </thead>
          <tbody>
          <tr>
            <td data-label="Name">{this.props.initialValues.name}</td>
            <td data-label="DOB">{this.props.initialValues.birthDate}</td>
            <td data-label="Gender">{this.props.initialValues.gender}</td>
            <td data-label="Marital Status">{this.props.initialValues.maritalStatus}</td>
            <td data-label="Race">Unknown</td>
            <td data-label="Language">Unknown</td>
          </tr>
          </tbody>
        </table>
        
        <h3 className="ui dividing header">Insurance Information</h3>
        <table className="ui celled table">
          <thead>
          <tr>
            <th>Carrier</th>
            <th>Coverage</th>
          </tr>
          </thead>
          <tbody>
          <tr>
            <td data-label="Name">BCBS - Georgia</td>
            <td data-label="DOB">Pref PA</td>
          </tr>
          </tbody>
        </table>
  
        <h3 className="ui dividing header">Select Approval Pathway</h3>
        
        <form
          onSubmit={this.props.handleSubmit(this.onSubmit)}
          className="ui form error"
        >
          
          <div>
            <label>Has patient been through Step Therapy?</label>
            <div>
              <label>
                <Field name="stepTherapy" component="input" type="radio" value="true" /> Yes
              </label>
              <br />
              <label>
                <Field name="stepTherapy" component="input"  type="radio" value="false" /> No
              </label>
            </div>
          </div>
  
          <br />
          <div>
            <label>Please provide information</label>
            <div>
              <Field name="information" component="textarea" />
            </div>
          </div>
  
          <div>
            <label>Additional reasons for appeal</label>
            <div>
              <label>
                <Field name="efficacy" id="efficacy" component="input" type="checkbox" /> Efficacy
                <br/>
              </label>
              <label>
                <Field name="cost" id="cost" component="input" type="checkbox" /> Cost
                <br/>
              </label>
              <label>
                <Field name="sideEffect" id="sideEffect" component="input" type="checkbox" /> Side Effect
                <br/>
              </label>
              <label>
                <Field name="patientFactors" id="patientFactors" component="input" type="checkbox" /> Patient Specific Factors
                <br/>
              </label>
              
            </div>
          </div>
            <button  className="ui primary button" type="submit">Next</button>
      </form>
      </div>
    );
  }
}

export default reduxForm({
  form: 'patientForm'
})(PatientForm);
