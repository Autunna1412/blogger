import { Component, OnInit } from '@angular/core';
import { ArticleApi } from 'src/app/core/article.api.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html'
})
export class ArticleListComponent implements OnInit {
  articles: any;

  constructor(private articleApi: ArticleApi) {

  }

  ngOnInit() {
    this.articleApi.getAritcles().subscribe(
      res => {
          this.articles = res;
      }
    );
  }

}
