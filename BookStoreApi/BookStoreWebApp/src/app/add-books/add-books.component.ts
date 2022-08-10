import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from '../book.service';

@Component({
  selector: 'app-add-books',
  templateUrl: './add-books.component.html',
  styleUrls: ['./add-books.component.scss']
})
export class AddBooksComponent implements OnInit {

  public bookForm!: FormGroup;

  constructor(private formBuilder: FormBuilder,private service:BookService) { }

  ngOnInit(): void {
    this.init();
  }

  public addBook(): void {
    this.service.addBooks(this.bookForm.value).subscribe(data => {
      alert(`Book added successfully Id : ${data}`);
    });
  }

  private init() : void{
    this.bookForm = this.formBuilder.group({
      title: [''],
      description: [''],
    });
  }

}
