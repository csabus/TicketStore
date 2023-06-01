import {createReducer, on} from "@ngrx/store";
import * as actions from '../actions/ui.actions';
import {UIMessage} from "../../models";

export interface State {
  loading: boolean;
  message: UIMessage | null
};

const INITIAL_STATE: State = {
  loading: false,
  message: null
};

export const reducer = createReducer(
  INITIAL_STATE,
  on(actions.DoStartLoading, (state) => ({...state, loading: true})),
  on(actions.DoStopLoading, (state) => ({...state, loading: false})),
  on(actions.DoShowMessage, (state, action) => (
    {
      ...state, message: {
        message: action.message, action: action.action, duration: action.duration
      }
    }))
);

export const getLoading = (state: State) => state.loading;
export const getMessage = (state: State) => state.message;
