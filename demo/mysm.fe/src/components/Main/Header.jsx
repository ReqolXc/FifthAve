import React, { Component } from 'react';
import { Grid, Menu } from 'semantic-ui-react'

export default class Header extends Component {
    state = {}
  
    handleItemClick = (e, { name }) => this.setState({ activeItem: name })
  
    render() {
      const { activeItem } = this.state
  
      return (
            <Menu pointing secondary size="huge">
                <Menu.Item
                    href="/"
                    name='Fifth ave'
                />
                <Menu.Menu position='right'>
                    <Menu.Item
                        href="/logout"
                        name='Logout'
                        active={activeItem === 'Logout'}
                        onClick={this.handleItemClick}
                    />
                </Menu.Menu>
            </Menu>
      )
    }
  }
