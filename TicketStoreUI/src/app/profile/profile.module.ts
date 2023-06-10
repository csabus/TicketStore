import {NgModule} from '@angular/core';
import {ProfileComponent} from './profile/profile.component';
import {SharedModule} from "../shared/shared.module";
import {CommonModule} from "@angular/common";


@NgModule({
  declarations: [
    ProfileComponent
  ],
  exports: [
    ProfileComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class ProfileModule {
}
