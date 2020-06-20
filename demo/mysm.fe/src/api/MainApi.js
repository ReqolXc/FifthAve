import axios from 'axios'

let token = localStorage.getItem('token');

let instance = axios.create({
    baseURL: 'https://localhost:44359',
    headers: { 'Authorization': 'Bearer ' + token }
});

export function getPersonInfo() {
    return instance.get('/user-info');
};

export function login(data) {
    return instance.post('/token', {
        ...data
    }).then(x => {
        localStorage.setItem('token', x.data.access_token);
    });
};
