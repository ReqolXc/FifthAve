import createSagaMiddleware from "redux-saga";
import { createStore, applyMiddleware, compose} from "redux";

import reducers from "../reducers/allReducers";
import rootSaga from "../sagas/Main/PersonCardSaga";

const sagaMiddleware = createSagaMiddleware();

const store = createStore(reducers, compose(
    applyMiddleware(sagaMiddleware),
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
));

sagaMiddleware.run(rootSaga);

export default store;
