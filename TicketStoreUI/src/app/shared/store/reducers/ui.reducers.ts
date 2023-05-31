import {createReducer, on} from "@ngrx/store";
import * as actions from '../actions/ui.actions';

export interface State {
  loading: boolean;
};

const INITIAL_STATE: State = {
  loading: false,
};

export const reducer = createReducer(
  INITIAL_STATE,
  on(actions.DoStartLoading, (state) => ({loading: true})),
  on(actions.DoStopLoading, (state) => ({loading: false}))
);

export const getLoading = (state: State) => state.loading;
