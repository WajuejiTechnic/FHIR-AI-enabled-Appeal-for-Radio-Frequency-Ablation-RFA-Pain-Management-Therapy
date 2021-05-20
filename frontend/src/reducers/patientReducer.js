import _ from 'lodash';
import {
  FETCH_PATIENT,
  FETCH_PATIENTS,
  FETCH_TEMPLATE,
  SUBMITTED_PATIENT
} from '../actions/types';

export default (state = {}, action) => {
  switch (action.type) {
    case FETCH_PATIENTS:
      return {...state, ..._.mapKeys(action.payload, 'id')};
    case FETCH_PATIENT:
      console.log("fetch patient reducer action type: ", action.type);
      console.log('fetch patient reducer', action.payload.id);
      return {...state, [parseInt(action.payload.id, 10)]: action.payload};
    // case EDIT_PATIENT:
    //   console.log("edit patient reducer action type: ", action.type);
    //   console.log('edit patient reducer', action.payload.id);
    //   if (action.payload.id === undefined){
    //     console.log('undefined reached');
    //     return state;
    //   }
    //   return {...state, [parseInt(action.payload.id, 10)]: action.payload};
    case FETCH_TEMPLATE:
      console.log('fetch template reducer', action.payload.id);
      return {...state, [parseInt(action.payload.id, 10)]: action.payload};
    // case REVIEW_PATIENT:
    //   return {...state, [parseInt(action.payload.id, 10)]: action.payload};
    // case SUBMIT_PATIENT:
    //   return {...state, [parseInt(action.payload.id, 10)]: action.payload};
    case SUBMITTED_PATIENT:
      return {...state, [parseInt(action.payload.id, 10)]: action.payload};
    default:
      return state;
  }
};
