import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Grid } from 'semantic-ui-react'
import Header from './components/Main/Header';
import Post from './components/Main/Post';
import PersonCard from './components/Main/PersonCard';
import Login from './components/Main/Login'
import NavigationMenu from './components/Main/NavigationMenu';
import { Switch, Route } from 'react-router-dom'


function App() {
  return (
    <div>
      <Grid centered>
        <Route exact path="/login" component={Login} />
      </Grid>
    </div>
  );
}

export default App;
