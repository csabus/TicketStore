import { createSelector } from '@ngrx/store';
//import { ActionReducer, combineReducers } from '@ngrx/store';
//import {compose} from "@ngrx/store";

import * as fromAuth from './reducers/auth.reducers';
import * as fromUI from './reducers/ui.reducers';

export interface State {
  auth: fromAuth.State;
  ui: fromUI.State;
}

export const reducers = {
  auth: fromAuth.reducer,
  ui: fromUI.reducer,
};

/*export function store(state: any, action: any) {
  const store: ActionReducer<State> = compose(combineReducers)(reducers);
  return store(state, action);
}*/

export const getAuthState = (state: State) => state.auth;
export const getAuthLoaded = createSelector(getAuthState, fromAuth.getLoaded);
export const getAuthLoading = createSelector(getAuthState, fromAuth.getLoading);
export const getAuthFailed = createSelector(getAuthState, fromAuth.getFailed);
export const getLoggedUser = createSelector(
  getAuthState,
  fromAuth.getLoggedUser
);
export const getToken = createSelector(getAuthState, fromAuth.getToken);
export const getRoles = createSelector(getAuthState, fromAuth.getRoles);

export const getUIState = (state: State) => state.ui;
export const getUILoading = createSelector(getUIState, fromUI.getLoading);
export const getUIMessage = createSelector(getUIState, fromUI.getMessage);
