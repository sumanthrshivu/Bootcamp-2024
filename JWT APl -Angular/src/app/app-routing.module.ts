import { NgModule } from '@angular/core';
import { ChildActivationStart, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/Login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { HomeComponent } from './Components/Home/home.component';
import { ParentComponent } from './Components/parent/parent.component';
import { ChildComponent } from './Components/child/child.component';

const routes:Routes=[
  {path:'login', component: LoginComponent},
  {path:'Register', component: RegisterComponent},
  {path:'Home', component: HomeComponent},
  {path:'Parent', component: ParentComponent},
  {path:'Child', component: ChildComponent},
  { path: '', redirectTo: '/login', pathMatch: 'full' }, // Default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
