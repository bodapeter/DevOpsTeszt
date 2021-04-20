import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GreetingsComponent } from './greetings/greetings.component';


const routes: Routes = [
  { path: '', component: GreetingsComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
