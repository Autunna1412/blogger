import { Component, OnInit } from '@angular/core';
import { NgbModalConfig, NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, FormControl, FormArray } from '@angular/forms';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { ArticleApi } from '../../../core/article.api.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRouteSnapshot, NavigationEnd } from '@angular/router';
import { Pipe, PipeTransform } from '@angular/core';


@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html'
})

export class CreateArticleComponent implements OnInit {

  articleForm: FormGroup;
  newArticle: any;

  constructor(public activeModal: NgbActiveModal,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private articleApi: ArticleApi,
    private router: Router) {
      this.router.routeReuseStrategy.shouldReuseRoute = function() {
        return false;
      };
  }

  ngOnInit() {
    this.articleForm = this.formBuilder.group({
      title: new FormControl(),
      content: new FormControl(),
      hashtags: new FormControl([])
    });
  }

  createArticle(formGroup: FormGroup) {
    this.newArticle = <any> formGroup.value;
    this.newArticle.hashtags = this.newArticle.hashtags.map(hashtag => hashtag.value);
    this.articleApi.create(this.newArticle).subscribe(
      res => {
        this.toastr.success('Save Successfully!', 'Toastr fun!');
        this.activeModal.close('Close click');
        this.redirectTo(this.router.url);
      },
      err => {
        this.toastr.error('Error!', 'Toastr fun!');
        console.log('oops', err);
      }
    );
  }

  redirectTo(uri) {
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() =>
    this.router.navigate([uri]));
  }
}
