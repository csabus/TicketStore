import {Component} from '@angular/core';
import {Store} from "@ngrx/store";
import * as store from "../../shared/store";
import * as authActions from '../../shared/store/actions/auth.actions';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  isLoggedIn$ = this.store$.select(store.getAuthLoaded);

  constructor(private store$: Store<store.State>) {
  }

}
