import {Component} from '@angular/core';
import {Store} from "@ngrx/store";
import * as store from "../store";

@Component({
  selector: 'app-loading-screen',
  templateUrl: './loading-screen.component.html',
  styleUrls: ['./loading-screen.component.css']
})
export class LoadingScreenComponent {
  isLoading$ = this.store$.select(store.getUILoading);

  constructor(private readonly store$: Store<store.State>) {
  }
}
