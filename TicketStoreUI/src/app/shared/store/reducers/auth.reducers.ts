import {createReducer, on} from "@ngrx/store";
import * as actions from '../actions/auth.actions';
import {User} from '../../models';

export interface State {
  loading: boolean;
  loaded: boolean;
  failed: boolean;
  user: User | null;
};

const INITIAL_STATE: State = {
  loading: false,
  loaded: false,
  failed: false,
  user: null
};

export const reducer = createReducer(
  INITIAL_STATE,
  on(actions.DoLogin, (state) => ({...state, loading: true, loaded: false, failed: false})),
  on(actions.DoLogout, (state) => ({...state, loading: true, loaded: false, failed: false})),
  on(actions.DoLoginSuccess, (state, action) => {
      console.log(action);
      return {
        loading: false, loaded: true, failed: false, user: {
          id: '1',
          userName: 'username'
        }
      }
    }
  ),
  on(actions.DoLoginFail, (state) => ({...INITIAL_STATE, failed: true})),
  on(actions.DoLogoutSuccess, (state) => ({...INITIAL_STATE, failed: true})),
  on(actions.DoLogoutFail, (state) => ({...INITIAL_STATE})),
);

export const getLoaded = (state: State) => state.loaded;
export const getLoading = (state: State) => state.loading;
export const getFailed = (state: State) => state.failed;
export const getLoggedUser = (state: State) => state.user;

