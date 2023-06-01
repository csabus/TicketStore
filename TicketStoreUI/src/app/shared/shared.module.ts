import {NgModule} from "@angular/core";
import {CommonModule} from '@angular/common';
import {FormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {LoadingScreenComponent} from './loading-screen/loading-screen.component';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {UiMessagesComponent} from './ui-messages/ui-messages.component';
import {MatSnackBarModule} from "@angular/material/snack-bar";

@NgModule({
  declarations: [
    LoadingScreenComponent,
    UiMessagesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatSnackBarModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    LoadingScreenComponent,
    UiMessagesComponent
  ]
})
export class SharedModule {
}
