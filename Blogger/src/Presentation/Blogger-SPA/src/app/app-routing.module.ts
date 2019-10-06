import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { NgModule } from '@angular/core';

const routes: Routes = [
    {
      path: '',
      children: [
        { path: '', pathMatch: 'full', component: AppComponent},
        { path: 'article', loadChildren: './modules/article/article.module#ArticleModule' }
      ]
    },
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload', scrollPositionRestoration: 'enabled'})],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  