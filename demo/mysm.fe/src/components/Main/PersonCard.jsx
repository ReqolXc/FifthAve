import React, { Component } from 'react';
import { Grid, Dimmer, Button, Image, Card, Icon, Container } from 'semantic-ui-react';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import axios from 'axios'
import { getPersonInfo } from '../../actions/Main/PersonCardActions';

class PersonCard extends Component {

    static propTypes = {
        name: PropTypes.string,
        imageLink: PropTypes.string,
        homeLink: PropTypes.string,
        nickname: PropTypes.string,
        friendsNumber: PropTypes.number,
        postsNumber: PropTypes.number
    }

    static defaultProps = {
        imageLink: '',
        name: '',
        homeLink: '',
        nickname: '',
        friendsNumber: 0,
        postsNumber: 0
    }

    componentDidMount() {
        this.props.setInfo();
    }

    state = {}

    handleShow = () => this.setState({ active: true })
    handleHide = () => this.setState({ active: false })

    render() {

        const {
            name,
            imageLink,
            homeLink,
            nickname,
            friendsNumber,
            postsNumber
        } = this.props;

        const { active } = this.state;

        const content = (
            <Button
                inverted
                href='/settings'
            >
                <Icon name='cog' />Settings
            </Button>
        );

        return (
            <Card>
                <Dimmer.Dimmable
                    blurring
                    as={Image}
                    dimmed={active}
                    dimmer={{ active, content }}
                    onMouseEnter={this.handleShow}
                    onMouseLeave={this.handleHide}
                    size='medium'
                    src={imageLink}
                />
                <Card.Content>
                    <Card.Header>{name}</Card.Header>
                    <Card.Meta>
                        <a href={homeLink}>@{nickname}</a>
                    </Card.Meta>
                </Card.Content>
                <Card.Content extra>
                    <a className="left floated">
                        <Icon name="user" />
                        {friendsNumber} Friends
                    </a>
                    <a className="right floated">
                        {postsNumber} Posts
        				<Icon name="sticky note" />
                    </a>
                </Card.Content>
            </Card>
        )
    }
}

const mapStateToProps = state => ({ ...state.PersonCardReducer });

const mapActionsToProps = dispatch => ({
    setInfo: bindActionCreators(getPersonInfo, dispatch)
});

const WrapedPersonCard = connect(mapStateToProps, mapActionsToProps)(PersonCard);

export default WrapedPersonCard;