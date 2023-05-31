import {createAction, props} from "@ngrx/store";

export const ActionTypes = {
  DO_START_LOADING: '[UI] Do Start Loading',
  DO_STOP_LOADING: '[UI] Do Stop Loading',
};

export const DoStartLoading = createAction(ActionTypes.DO_START_LOADING);
export const DoStopLoading = createAction(ActionTypes.DO_STOP_LOADING);

