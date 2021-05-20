import React from 'react';
import { Field, reduxForm } from 'redux-form';
import './textDisplay.css'

class PatientSubmitEdit extends React.Component {

  onSubmit = formValues => {
    this.localPatient.hasBeenSubmitted = formValues.hasBeenSubmitted;
    this.props.onSubmit(this.localPatient);
  };

  localPatient = null;

  render() {
    this.localPatient = this.props.initialValues;
    return (
      <div>
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
            <td data-label="Appeal for">{this.props.initialValues.name}</td>
            <td data-label="DOB">{this.props.initialValues.birthDate}</td>
          </tr>
          </tbody>
        </table>
        <div className="ui message"><pre>{this.props.initialValues.appealTemplate}</pre></div>
        <form onSubmit={this.props.handleSubmit(this.onSubmit)} className="ui form error">
          <div>
            <div>
              <Field name="id" component="input" value={this.props.initialValues.id}  type="hidden" style={{ height: 0 }} />
              <Field name="name" component="input" value={this.props.initialValues.name} type="hidden" style={{ height: 0 }} />
              <Field name="birthDate" component="input" value={this.props.initialValues.birthDate} type="hidden" style={{ height: 0 }} />
              <Field name="birthDate" component="input" value={this.props.initialValues.birthDate} type="hidden" style={{ height: 0 }} />
              <Field name="appealTemplate" component="input" value={this.props.initialValues.birthDate} type="hidden" style={{ height: 0 }} />
              <Field name="stepTherapy" component="input" value={this.props.initialValues.stepTherapy} type="hidden" style={{ height: 0 }} />
              <Field name="efficacy" component="input" value={this.props.initialValues.efficacy} type="hidden" style={{ height: 0 }} />
              <Field name="cost" component="input" value={this.props.initialValues.cost} type="hidden" style={{ height: 0 }} />
              <Field name="sideEffect" component="input" value={this.props.initialValues.sideEffect} type="hidden" style={{ height: 0 }} />
              <Field name="patientFactors" component="input" value={this.props.initialValues.patientFactors} type="hidden" style={{ height: 0 }} />
              <Field name="hasBeenSubmitted" component="input" value={this.props.initialValues.hasBeenSubmitted} type="hidden" style={{ height: 0 }} />
            </div>
          </div>
          <button  className="ui primary button" type="submit">Submit</button>
        </form>
      </div>
    );
  }
}

export default reduxForm({
  form: 'patientForm'
})(PatientSubmitEdit);