import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Client } from '../models/client';


@Component({
  selector: 'app-clients-list',
  templateUrl: './clients-list.component.html',
  styleUrls: ['./clients-list.component.css']
})
export class ClientsListComponent implements OnInit {

  @Output() FilterClients =  new EventEmitter<string>();
  @Input() clients: Client[] = null;
  constructor() { }

  ngOnInit() {
  }

  Filter(filter: string) {
    this.FilterClients.emit(filter);
  }

  IsBlocked(blocked: string) {
    if (blocked === 'True') {
      return true;
    }
    return false;
  }
}
