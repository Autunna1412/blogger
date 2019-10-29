import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable()
export class Api {
    constructor(private httpClient: HttpClient) {

    }

    get<T>(action: string, params?: HttpParams): Observable<T> {
        return this.httpClient.get<T>(`${environment.apiBaseUrl}/${action}`, { params: params });
    }

    post(action: string, body: any): Observable<Object> {
        return this.httpClient.post(`${environment.apiBaseUrl}/${action}`, body);
    }

    put(action: string, body: any): Observable<Object> {
        return this.httpClient.put(`${environment.apiBaseUrl}/${action}`, body);
    }
}
