import {createSelector} from "@ngrx/store";
//import { ActionReducer, combineReducers } from '@ngrx/store';
//import {compose} from "@ngrx/store";

import * as fromCounter from './reducers/counter.reducer';

export interface State {
  counter: fromCounter.State
};

export const reducers = {
  counter: fromCounter.reducer
}

/*export function store(state: any, action: any) {
  const store: ActionReducer<State> = compose(combineReducers)(reducers);
  return store(state, action);
}*/

export const getCounterState = (state: State) => state.counter;
export const getCounterValue = createSelector(getCounterState, fromCounter.getValue);



