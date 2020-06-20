import { put, call, takeEvery } from "redux-saga/effects";
import {
    requestData,
    requestDataSuccess,
    requestDataError
} from "../../actions/Main/PersonCardActions";
import { GET_PERSON_INFO } from '../../actions/Main/PersonCardActions';
import { getPersonInfo } from "../../api/MainApi";

export default function* rootSaga() {
    yield takeEvery(GET_PERSON_INFO, request);
}

function* request() {
    try {
        yield put(requestData());
        const response = yield call(getPersonInfo);
        yield put(requestDataSuccess(response.data));
    } catch (error) {
        yield put(requestDataError());
    }
}