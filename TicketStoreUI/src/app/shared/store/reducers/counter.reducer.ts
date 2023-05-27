import {createReducer, on} from "@ngrx/store";
import * as actions from '../actions/counter.action';

export interface State {
  value: number
};

const INITIAL_STATE: State = {
  value: 0
};

export const reducer = createReducer(
  INITIAL_STATE,
  on(actions.DoIncrementAction, (state) => ({...state, value: state.value + 1})),
  on(actions.DoDecrementAction, (state) => ({...state, value: state.value - 1})),
  on(actions.DoResetAction, (state) => ({...state, value: 0}))
);

export const getValue = (state: State) => state.value;


/*import {increment, decrement, reset} from "../actions/counter.action";

export const initialState = 0;

export const counterReducer = createReducer(
  initialState,
  on(increment, (state) => state + 1),
  on(decrement, (state) => state - 1),
  on(reset, (state) => 0)
);
*/
