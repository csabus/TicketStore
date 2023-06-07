import {createAction, props} from "@ngrx/store";
import {UserModel} from "../../models";

export const ActionTypes = {
  DO_LOGIN: '[Auth] Do Login',
  DO_LOGIN_SUCCESS: '[Auth] Do Login Success',
  DO_LOGIN_FAIL: '[Auth] Do Login Fail',
  DO_LOGOUT: '[Auth] Do Logout',
  DO_LOGOUT_SUCCESS: '[Auth] Do Logout Success',
  DO_LOGOUT_FAIL: '[Auth] Do Logout Fail',
};

export const DoLogin = createAction(ActionTypes.DO_LOGIN);
export const DoLoginSuccess = createAction(ActionTypes.DO_LOGIN_SUCCESS, props<UserModel>());
export const DoLoginFail = createAction(ActionTypes.DO_LOGIN_FAIL);
export const DoLogout = createAction(ActionTypes.DO_LOGOUT);
export const DoLogoutSuccess = createAction(ActionTypes.DO_LOGOUT_SUCCESS);
export const DoLogoutFail = createAction(ActionTypes.DO_LOGOUT_FAIL);

