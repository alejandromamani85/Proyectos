import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Client } from '../models/client';
import { tap, map, catchError } from 'rxjs/operators';


@Injectable()
export class ClientService {
  private _clientsUrl = 'http://localhost:50757/api/client';
  constructor(private _httpClient: HttpClient) { }

  GetAllCustom(): Observable<Client[]> {
    const url = `${this._clientsUrl}/getAllCustom`;
    return this._httpClient
      .get<any>(url)
      .pipe(
        tap(x => console.log(x)),
        map(clientsArray =>
          clientsArray.Result.map(c =>
            new Client(
              c.Index,
              c.Name,
              c.Target,
              c.Comment,
              c.Host,
              c.Blocked
            )
          )
        ),
        tap(x => console.log(x))
      );
  }

  GetAllCustomFull(): Observable<Client[]> {
    const url = `${this._clientsUrl}/getAllCustomFull`;
    return this._httpClient
      .get<any>(url)
      .pipe(
        tap(x => console.log(x)),
        map(clientsArray =>
          clientsArray.Result.map(c =>
            new Client(
              c.Index,
              c.Name,
              c.Target,
              c.Comment,
              c.Host,
              c.Blocked
            )
          )
        ),
        tap(x => console.log(x))
      );
  }

  GetClientAllStatus(): Observable<Client[]> {
    const url = `${this._clientsUrl}/getClientAllStatus`;
    return this._httpClient
      .get<any>(url)
      .pipe(
        tap(x => console.log(x)),
        map(clientsArray =>
          clientsArray.Result.map(c =>
            new Client(
              c.Index,
              c.Name,
              c.Target,
              c.Comment,
              c.Host,
              c.Blocked
            )
          )
        ),
        tap(x => console.log(x))
      );
  }

}
