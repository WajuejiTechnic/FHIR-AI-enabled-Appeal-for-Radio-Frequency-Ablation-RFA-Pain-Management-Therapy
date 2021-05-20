import axios from 'axios';

export default axios.create({
  baseURL: document.location.hostname === 'localhost' ? 'http://' + document.location.hostname + ':8080/api' : 'https://' + document.location.hostname + '/api'
});
