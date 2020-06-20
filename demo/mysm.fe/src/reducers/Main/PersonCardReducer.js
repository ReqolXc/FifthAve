import { REQUEST, REQUEST_SUCCEEDED, REQUEST_FAILED } from '../../actions/Main/PersonCardActions'

const defaultState = {
    imageLink: '',
    name: '',
    homeLink: '',
    nickname: '',
    friendsNumber: 0,
    postsNumber: 0
}

const reducer = (state = defaultState, action) => {
    let { type, payload } = action;
    switch (type) {
        case REQUEST:
            return state;
        case REQUEST_SUCCEEDED:
            return payload;
        case REQUEST_FAILED:
            return state;
        
        default:
            return state;
    };
};

export default reducer;