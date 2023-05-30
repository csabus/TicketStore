import {NgModule} from "@angular/core";
import {CommonModule} from '@angular/common';
import {FormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
  ]
})
export class SharedModule {
}