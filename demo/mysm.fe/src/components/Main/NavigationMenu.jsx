import React, { Component } from 'react';
import { Menu, Label, Input } from 'semantic-ui-react'
import PropTypes from 'prop-types';

class NavigationMenu extends Component {

    static propTypes = {
        items: PropTypes.arrayOf(PropTypes.object)
    }

    static defaultProps = {
        items: [ 
            {content: "inbox", label: 23, url:"#"},
            {content: "settings", url:"#"},
            {content: "home", label: 100, url:"#"},
            {content: "feed", url:"#"},
            {content: "Inbox", url:"#"},
            {content: "at", label: 1250, url:"#"} 
        ]
    }

    state = {}

    handleItemClick = (e, {name}) => this.setState({ active: name });

    render() {
        const {
            items
        } = this.props;

        const { active } = this.state;

        return (
            <Menu vertical>
                {items.map((item, i) => {
                    return (
                    <Menu.Item
                        name={i.toString()}
                        active={active === i.toString()}
                        onClick={this.handleItemClick}
                    >
                        {item.label && <Label color={active === i.toString() && 'teal'}>{item.label}</Label>}
                        {item.content}
                    </Menu.Item>)

                })}
            </Menu>
        )
    }
}

export default NavigationMenu;