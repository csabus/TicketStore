import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';

import {StoreModule} from '@ngrx/store';

import {reducers} from './shared/store';

import {MyCounterComponent} from '../counter/my-counter/my-counter.component';
import {AuthModule} from "./auth/auth.module";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NavigationModule} from "./navigation/navigation.module";
import {SharedModule} from "./shared/shared.module";
import {HomeModule} from "./home/home.module";

@NgModule({
  declarations: [
    AppComponent,
    MyCounterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NavigationModule,
    AuthModule,
    StoreModule.forRoot(reducers),
    BrowserAnimationsModule,
    SharedModule,
    HomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
