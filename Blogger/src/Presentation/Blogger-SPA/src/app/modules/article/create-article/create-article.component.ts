import { Component, OnInit } from '@angular/core';
import { NgbModalConfig, NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-create-article',
  templateUrl: './create-article.component.html'
})
export class CreateArticleComponent implements OnInit {

  articleForm: FormGroup;

  constructor(public activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,) {
   
  }

  ngOnInit() {
    this.articleForm = this.formBuilder.group({
      name: new FormControl(),
      description: new FormControl()
    }); 
  }

  createArticle(formGroup: FormGroup){
    console.log(formGroup)
  }
}
