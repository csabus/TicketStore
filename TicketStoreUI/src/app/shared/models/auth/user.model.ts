import {Role} from "./role.enum";

export interface UserModel {
  username: string,
  email?: string,
  fullName?: string,
  token?: string,
  roles: string[]
}
