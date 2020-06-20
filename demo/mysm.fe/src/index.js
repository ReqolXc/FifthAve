import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import PersonCard from './components/Main/PersonCard'
import Login from './components/Main/Login'
import * as serviceWorker from './serviceWorker';
import store from './store/store'
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom'
import Reducers from './reducers/allReducers'

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </Provider>
    , document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
