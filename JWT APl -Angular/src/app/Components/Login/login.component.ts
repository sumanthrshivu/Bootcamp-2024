import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServiceService } from 'src/app/Services/CommonService/http-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
loginform:FormGroup;
displaymsg:string="";
model:loginmodel = new loginmodel("","");
  constructor(private fb:FormBuilder,private httpservice:HttpServiceService,private router: Router) { 
    this.loginform=this.fb.group({
      username:['',Validators.required],
      password:['',Validators.required]
    })
   
  }

  ngOnInit(): void {
    
  }
  OnSubmit(){
    if(this.loginform.valid){
      this.httpservice.Post('Login',this.model).subscribe(res=>{
        console.log(res);
        this.displaymsg=res.message;
        this.router.navigateByUrl('/Home')
      }
    )}
  }
}




export class loginmodel{
  email:string;
  password:string;
  static email: any;
  
  constructor(_email:string, _password:string) {
    this.email=_email;
    this.password=_password
  }
}  