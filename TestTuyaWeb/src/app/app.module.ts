import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CustomersComponent } from './customers/customers.component';

import {HttpClientModule} from '@angular/common/http'
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { OrdersComponent } from './orders/orders.component';
import { DetailsOrdersComponent } from './details-orders/details-orders.component'

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CustomersComponent,    
    OrdersComponent, DetailsOrdersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
