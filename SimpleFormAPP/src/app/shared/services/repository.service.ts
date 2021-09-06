import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {
  private url: string = environment.urlBase;

  constructor(private client: HttpClient) { }

  public get(route: string): Observable<any> {
    return this.client.get<any>(this.completeRoute(route));
  }

  public add(route: string, body: any): Observable<any> {
    return this.client.post<any>(this.completeRoute(route), body, { headers: { "Content-Type": "application/json" }});
  }

  public update(route: string, body: any): Observable<any> {
    return this.client.put<any>(this.completeRoute(route), body, { headers: { "Content-Type": "application/json" }});
  }

  public delete(route: string): Observable<any> {
    return this.client.delete(this.completeRoute(route));
  }

  private completeRoute(route: string): string {
    console.log(this.url + route);
    return this.url + route;
  }
}
