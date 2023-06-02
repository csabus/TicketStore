import {Component, OnDestroy, OnInit} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {UiMessagesService} from "./ui-messages.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-ui-messages',
  templateUrl: './ui-messages.component.html',
  styleUrls: ['./ui-messages.component.css']
})

export class UiMessagesComponent implements OnInit, OnDestroy {

  private uiMessageServiceSubscription: Subscription | undefined;

  constructor(private readonly snackBar: MatSnackBar,
              private readonly uiMessagesService: UiMessagesService) {
  }

  ngOnInit(): void {
    this.uiMessageServiceSubscription = this.uiMessagesService.showMessageEvent.subscribe((uiMessage) => {
      if (uiMessage.duration && uiMessage.duration > 0) {
        this.snackBar.open(uiMessage.message, uiMessage.action, {duration: uiMessage.duration});
      } else {
        this.snackBar.open(uiMessage.message, uiMessage.action);
      }
    });
  }

  ngOnDestroy(): void {
    this.uiMessageServiceSubscription?.unsubscribe();
  }

}
