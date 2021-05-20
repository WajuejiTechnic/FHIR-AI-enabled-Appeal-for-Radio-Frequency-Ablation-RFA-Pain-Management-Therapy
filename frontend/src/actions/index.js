import  patients from '../apis/patients';
import history from '../history';


import {
  FETCH_PATIENTS,
  FETCH_PATIENT,
  EDIT_PATIENT,
  FETCH_TEMPLATE,
  REVIEW_PATIENT,
  SUBMIT_PATIENT,
  SUBMITTED_PATIENT
} from './types';

export const fetchPatients = () => async dispatch => {
  const response = await patients.get('/patient');

  dispatch({ type: FETCH_PATIENTS, payload: response.data });
};

export const fetchPatient = id => async dispatch => {
  const response = await patients.get(`/patient/${id}`);
  console.log("action fetch patient", typeof id, id);
  dispatch({ type: FETCH_PATIENT, payload: response.data });
};

export const editPatient = (id, formValues) => async dispatch => {
  const response = await patients.put(`/patient/${id}`, formValues);
  console.log("action edit patient", typeof id, id);
  dispatch({ type: EDIT_PATIENT, payload: response.data });
  history.push(`/patients/draft/${id}`);
};

export const fetchTemplate = id => async dispatch => {
  console.log("action fetch template", typeof id, id);
  const response = await patients.get(`/template/${id}`);

  dispatch({ type: FETCH_TEMPLATE, payload: response.data });
};

export const reviewPatient = (id, formValues) => async dispatch => {
  const response = await patients.put(`/patient/${id}`, formValues);

  dispatch({ type: REVIEW_PATIENT, payload: response.data });
  history.push(`/patients/submit/${id}`);
};

export const submitPatient = (id, formValues) => async dispatch => {
  const response = await patients.put(`/patient/${id}`, formValues);

  dispatch({ type: SUBMIT_PATIENT, payload: response.data });
  history.push(`/patients/submitted/${id}`);
};

export const submittedPatient = id => async dispatch => {
  const response = await patients.get(`/patient/${id}`);

  dispatch({ type: SUBMITTED_PATIENT, payload: response.data });
};
