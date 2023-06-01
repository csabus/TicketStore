import {createAction, props} from "@ngrx/store";
import {UIMessage} from "../../models";

export const ActionTypes = {
  DO_START_LOADING: '[UI] Do Start Loading',
  DO_STOP_LOADING: '[UI] Do Stop Loading',
  DO_SHOW_MESSAGE: '[UI] Do Show Message',
};

export const DoStartLoading = createAction(ActionTypes.DO_START_LOADING);
export const DoStopLoading = createAction(ActionTypes.DO_STOP_LOADING);
export const DoShowMessage = createAction(ActionTypes.DO_SHOW_MESSAGE, props<UIMessage>());



