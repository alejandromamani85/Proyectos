import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ClientsListComponent } from './clients-list/clients-list.component';
import { ClientService } from './services/client.service';

import { MatCardModule, MatCard } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule, MatFormField } from '@angular/material/form-field';


@NgModule({
  declarations: [
    AppComponent,
    ClientsListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatFormFieldModule,

  ],
  providers: [ClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
