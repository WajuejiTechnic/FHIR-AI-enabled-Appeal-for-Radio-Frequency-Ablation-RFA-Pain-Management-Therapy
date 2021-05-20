import React from 'react';
import { Field, reduxForm } from 'redux-form';

class PatientDraftEdit extends React.Component {

  onSubmit = formValues => {
    this.props.onSubmit(formValues);
  };

  renderTextArea = ({input}) => (
    <div>
      <textarea {...input} rows="40" cols="40"/>
    </div>
  );

  render() {
    if (!this.props.initialValues || !this.props.initialValues.appealTemplate) {
      return <div>Loading...</div>;
    }

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
        <form onSubmit={this.props.handleSubmit(this.onSubmit)} className="ui form error">
          <div>
            <label>Appeal Letter</label>
            <div>
              <Field name="appealTemplate" id="appealTemplate" component={this.renderTextArea} />
            </div>
          </div>
          <div>
            <label>Submit to the insurance company?</label>
            <br/>
            <label>
              <Field name="hasBeenSubmitted" id="hasBeenSubmitted" component="input" type="checkbox" /> Yes
                <br/>
            </label>
          </div>
            <button  className="ui primary button" type="submit">Next</button>
          <br />
        </form>
      </div>
    );
  }
}

export default reduxForm({
  form: 'patientForm'
})(PatientDraftEdit);
