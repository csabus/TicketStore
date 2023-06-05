import {NgModule} from "@angular/core";
import {CommonModule} from '@angular/common';
import {ReactiveFormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {LoadingScreenComponent} from './loading-screen/loading-screen.component';
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {UiMessagesComponent} from './ui-messages/ui-messages.component';
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';

@NgModule({
  declarations: [
    LoadingScreenComponent,
    UiMessagesComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    MatCardModule,
    MatFormFieldModule,
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    LoadingScreenComponent,
    UiMessagesComponent,
    MatCardModule,
    MatFormFieldModule,
  ]
})
export class SharedModule {
}
