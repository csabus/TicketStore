import {EventEmitter, Injectable} from '@angular/core';
import {UIMessage} from "../models";


@Injectable({
  providedIn: 'root'
})
export class UiMessagesService {

  showMessageEvent = new EventEmitter<UIMessage>();

  constructor() {
  }

  showMessage(message: string, action: string, duration?: number) {
    this.showMessageEvent.emit({message, action, duration});
  }
}
