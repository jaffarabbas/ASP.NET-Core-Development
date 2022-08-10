import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBooksComponent } from './add-books/add-books.component';
import { AllBooksComponent } from './all-books/all-books.component';

const routes: Routes = [
  { path: 'books', component: AllBooksComponent },
  { path: 'add', component: AddBooksComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
