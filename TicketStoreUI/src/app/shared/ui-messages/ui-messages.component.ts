import {Component, OnInit} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {Store} from "@ngrx/store";
import * as store from '../store';

@Component({
  selector: 'app-ui-messages',
  templateUrl: './ui-messages.component.html',
  styleUrls: ['./ui-messages.component.css']
})
export class UiMessagesComponent implements OnInit {

  uiMessage$ = this.store$.select(store.getUIMessage);

  constructor(private readonly _snackBar: MatSnackBar,
              private readonly store$: Store<store.State>) {
  }

  ngOnInit(): void {
    this.uiMessage$.subscribe((uiMessage) => {
      if (uiMessage != null) {
        if (uiMessage.duration && uiMessage.duration > 0) {
          this._snackBar.open(uiMessage.message, uiMessage.action, {duration: uiMessage.duration});
        } else {
          this._snackBar.open(uiMessage.message, uiMessage.action);
        }
      }
    })
  }

}
