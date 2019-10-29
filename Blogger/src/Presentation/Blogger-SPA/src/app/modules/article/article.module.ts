import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ArticleRoutingModule } from './article-routing.module';
import { ArticleListComponent } from './article-list/article-list.component';
import { CreateArticleComponent } from './create-article/create-article.component';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ArticleComponent } from './article-form/article.component';
import { AngularEditorModule, AngularEditorService } from '@kolkov/angular-editor';
import { ArticleApi } from 'src/app/core/article.api.service';

@NgModule({
  declarations: [
    ArticleListComponent,
    CreateArticleComponent,
    ArticleComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ArticleRoutingModule,
    NgbModule,
    AngularEditorModule
  ],
  providers: [
    ArticleApi
  ],
})
export class ArticleModule { }
