import { Component, OnInit } from '@angular/core';
import { NgbModalConfig, NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { ArticleApi } from 'src/app/core/article.api.service';

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
    private formBuilder: FormBuilder,
    private articleApi: ArticleApi) {

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
      res => console.log(res.status), 
      err => console.log('error', err.status)
    );
  }
}
