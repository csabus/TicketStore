import {Component} from '@angular/core';
import * as store from "../../shared/store";
import {Store} from "@ngrx/store";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  user$ = this.store$.select(store.getLoggedUser);

  constructor(private readonly store$: Store<store.State>) {
  }

}
