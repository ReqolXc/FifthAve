import React, { Component } from 'react';
import { Grid, Dimmer, Button, Segment, Form, Divider } from 'semantic-ui-react';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import axios from 'axios'
import { login } from '../../api/MainApi'
import { getPersonInfo } from '../../actions/Main/PersonCardActions';

class Login extends Component {
    constructor(props) {
        super(props);
        this.state = { login: '', pass: ''};

        this.handleLoginChange = this.handleLoginChange.bind(this);
        this.handlePassChange = this.handlePassChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleLoginChange(event) {
        this.setState({ login: event.target.value });
    }

    handlePassChange(event) {
        this.setState({ pass: event.target.value });
    }

    handleSubmit(event) {
        

        let data ={
            username: this.state.login,
            password: this.state.pass
        };

        login(data);
    }

    render() {
        return (
            <Segment placeholder>
                <Form>
                    <Form.Input
                        value={this.state.login}
                        onChange={this.handleLoginChange}
                        icon='user'
                        iconPosition='left'
                        label='Username'
                        placeholder='Username'
                    />
                    <Form.Input
                        value={this.state.pass}
                        onChange={this.handlePassChange}
                        icon='lock'
                        iconPosition='left'
                        label='Password'
                        type='Password'
                        placeholder='Password'
                    />
                    <Button content='Login' onClick={this.handleSubmit} primary />
                </Form>
            </Segment>
        )
    }
}

export default Login;