import {NgModule} from '@angular/core';
import {LoginComponent} from './login/login.component';
import {SharedModule} from "../shared/shared.module";
import {MatInputModule} from "@angular/material/input";


@NgModule({
  declarations: [
    LoginComponent
  ],
  exports: [
    LoginComponent
  ],
  imports: [
    SharedModule,
    MatInputModule,
  ]
})
export class AuthModule {
}
