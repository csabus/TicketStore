import {Component} from '@angular/core';
import {Store} from "@ngrx/store";
import * as store from '../../app/shared/store/';
import * as counterActions from '../../app/shared/store/actions/counter.action';

@Component({
  selector: 'app-my-counter',
  templateUrl: './my-counter.component.html',
  styleUrls: ['./my-counter.component.css']
})
export class MyCounterComponent{
  count$ = this.store$.select(store.getCounterValue);

  constructor(private store$: Store<store.State>) {
  }

  increment() {
    this.store$.dispatch(counterActions.DoIncrementAction());
  }

  decrement() {
    this.store$.dispatch(counterActions.DoDecrementAction());
  }

  reset() {
    this.store$.dispatch(counterActions.DoResetAction());
  }

}
