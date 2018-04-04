import { Component, OnInit } from '@angular/core';
import { ClientService } from './services/client.service';
import { Client } from './models/client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  clientsFullList: Client[] = null;
  clients: Client[] = null;
  constructor(public clientSrv: ClientService) {}

  ngOnInit() {
    this.clientSrv.GetClientAllStatus()
    .subscribe( clients => {
      this.clientsFullList = clients;
      this.clients = this.clientsFullList;
    });
  }
  FilterClients(filter: string) {
    this.clients = this.clientsFullList.filter(c => c.name.toLowerCase().indexOf(filter.toLowerCase()) >= 0);
  }
}
