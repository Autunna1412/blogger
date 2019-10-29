import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { Observable } from 'rxjs';
import { Api } from './api.service';

@Injectable()
export class ArticleApi extends Api {
    private controllerName = 'api/article';

    public create(data: any): Observable<any> {
        return this.post(`${this.controllerName}`, data);
    }
}
