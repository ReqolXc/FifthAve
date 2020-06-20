import React, { Component } from 'react';
import {Card, Image, Rating, Icon } from 'semantic-ui-react'
import PropTypes from 'prop-types';

class Post extends Component {

    static propTypes = {
        items: PropTypes.arrayOf(PropTypes.object)
    }

    static defaultProps = {
        
    }

    state = {}

    handleItemClick = (e, { name }) => this.setState({ active: name });

    render() {
        return(
        <Card>
            <Card.Content>
        <div className="right floated meta">{}}</div>
                <Image src='/default/images/didnt_found.webp' avatar />
                <span>@username</span>
            </Card.Content>
            <Image src='/default/images/didnt_found.webp' wrapped ui={false} />
            <Card.Content>
                <Card.Header>Matthew</Card.Header>
                <Card.Meta>
                    <span className='date'>Joined in 2015</span>
                </Card.Meta>
                <Card.Description>
                            Draw from upon here gone add one. Am wound worth water he linen at vexed.. Painful
							so he an comfort is manners. Their saved linen downs tears son add music. Took sold
							add play may none him few. To things so denied admire. Pain son rose more park way
							that. As so seeing latter he should thirty whence
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <span className="right floated">
                    <Rating icon='heart'/>
                </span>
                <a>
                    <Icon disabled name='comment' />
                    3 comments
                </a>
            </Card.Content>
        </Card>
        )
    }
}

export default Post;