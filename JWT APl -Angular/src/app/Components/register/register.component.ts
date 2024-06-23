import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpServiceService } from 'src/app/Services/CommonService/http-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registrationform:FormGroup;
  reg_responsedata: any="";
  constructor(private fb:FormBuilder, private httpservice:HttpServiceService,private router: Router) { 
    this.registrationform=this.fb.group({
      username:['',Validators.required],
      password:['',Validators.required]
    })
  }

    ngOnInit(): void {}
    OnSubmit(formdata:any){
    this.httpservice.Post('Register',formdata).subscribe(res=>{
        setTimeout(() => {
          this.reg_responsedata=res.message;
        }, 2000);
        this.router.navigateByUrl('./login')
      });
    }
  Login(){
    this.router.navigateByUrl('./login')
  }
}
