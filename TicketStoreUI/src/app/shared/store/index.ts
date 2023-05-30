import {createSelector} from "@ngrx/store";
//import { ActionReducer, combineReducers } from '@ngrx/store';
//import {compose} from "@ngrx/store";

import * as fromCounter from './reducers/counter.reducer';
import * as fromAuth from './reducers/auth.reducers';

export interface State {
  counter: fromCounter.State
  auth: fromAuth.State
};

export const reducers = {
  counter: fromCounter.reducer,
  auth: fromAuth.reducer
}

/*export function store(state: any, action: any) {
  const store: ActionReducer<State> = compose(combineReducers)(reducers);
  return store(state, action);
}*/

export const getCounterState = (state: State) => state.counter;
export const getCounterValue = createSelector(getCounterState, fromCounter.getValue);

export const getAuthState = (state: State) => state.auth;
export const getAuthLoaded = createSelector(getAuthState, fromAuth.getLoaded);
export const getAuthLoading = createSelector(getAuthState, fromAuth.getLoading);
export const getAuthFailed = createSelector(getAuthState, fromAuth.getFailed);
export const getLoggedUser = createSelector(getAuthState, fromAuth.getLoggedUser);

