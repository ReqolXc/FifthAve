export const GET_PERSON_INFO = 'GET_PERSON_INFO'; 
export const REQUEST = "REQUEST";
export const REQUEST_SUCCEEDED = "REQUEST_SUCCEEDED";
export const REQUEST_FAILED = "REQUEST_FAILED";

export const getPersonInfo = () => {
    return { type: GET_PERSON_INFO };
};

export const requestData = () => {
    return { type: REQUEST };
  };
  
export const requestDataSuccess = payload => {
    return { type: REQUEST_SUCCEEDED, payload };
  };
  
export const requestDataError = () => {
    return { type: REQUEST_FAILED };
  };
  
