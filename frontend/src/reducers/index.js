import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import patientReducer from './patientReducer';

export default combineReducers({
  form: formReducer,
  patients: patientReducer
});
