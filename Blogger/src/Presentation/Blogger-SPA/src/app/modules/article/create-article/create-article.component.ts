import { Component, OnInit } from '@angular/core';
import { NgbModalConfig, NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { ArticleApi } from 'src/app/core/article.api.service';
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

//   editorConfig: AngularEditorConfig = {
//     editable: true,
//       spellcheck: true,
//       height: 'auto',
//       minHeight: '0',
//       maxHeight: 'auto',
//       width: 'auto',
//       minWidth: '0',
//       translate: 'yes',
//       enableToolbar: true,
//       showToolbar: true,
//       placeholder: 'Enter text here...',
//       defaultParagraphSeparator: '',
//       defaultFontName: '',
//       defaultFontSize: '',
//       fonts: [
//         {class: 'arial', name: 'Arial'},
//         {class: 'times-new-roman', name: 'Times New Roman'},
//         {class: 'calibri', name: 'Calibri'},
//         {class: 'comic-sans-ms', name: 'Comic Sans MS'}
//       ],
//       customClasses: [
//       {
//         name: 'quote',
//         class: 'quote',
//       },
//       {
//         name: 'redText',
//         class: 'redText'
//       },
//       {
//         name: 'titleText',
//         class: 'titleText',
//         tag: 'h1',
//       },
//     ],
//     uploadUrl: 'v1/image',
//     sanitize: true,
//     toolbarPosition: 'top',
// };

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
      tag: new FormControl()
    });
  }

  createArticle(formGroup: FormGroup) {
    this.newArticle = <any> formGroup.value;
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
