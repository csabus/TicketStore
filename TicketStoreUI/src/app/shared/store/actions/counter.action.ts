import {createAction} from "@ngrx/store";

export const ActionTypes = {
  DO_INCREMENT: '[Counter Component] Increment',
  DO_DECREMENT: '[Counter Component] Decrement',
  DO_RESET: '[Counter Component] Reset'
};

export const DoIncrementAction = createAction(ActionTypes.DO_INCREMENT);
export const DoDecrementAction = createAction(ActionTypes.DO_DECREMENT);
export const DoResetAction = createAction(ActionTypes.DO_RESET);

