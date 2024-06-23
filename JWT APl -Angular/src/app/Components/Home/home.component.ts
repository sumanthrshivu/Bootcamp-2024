import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { usermodel, userrequest } from 'src/app/Models/Usermodel';
import { HttpServiceService } from 'src/app/Services/CommonService/http-service.service';
import { HomeServiceService } from 'src/app/Services/home-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  dashboardurl:string='welcome to dashboard';
  userrequest:userrequest;
  usermodel:usermodel[]=[];
  edituserid:number|null=null;
  originaluserdata:usermodel|null=null;
  constructor(private rout:Router,private homeservice:HomeServiceService,private httpservice:HttpServiceService) {

    this.userrequest = {
      pagesize: 10,
      pagenumber: 1,
      searchstring: ''
    };
   }

  ngOnInit(): void {
    this.getRegisteredusers();
  }
  getRegisteredusers(){
    
    this.homeservice.getuserlits('GetRegisteredUsers',this.userrequest).subscribe((res:any)=>{
      this.usermodel=res.users;
      console.log(res);
    })

  }
  navigatebtn(){
    this.rout.navigateByUrl('/Parent');
  }
  toggleUpdateUser(user:usermodel){
    if(this.edituserid==user.id){
      this.edituserid=null;
      this.originaluserdata = null; 
      this.httpservice.Put('User/updateuser',user).subscribe((res:any)=>{
        console.log(res);
      })

    }else{
      this.edituserid=user.id;
      this.originaluserdata={...user};
    }

  }
  cancelEdit(user:usermodel): void {
    this.edituserid = null;
    if (this.originaluserdata) {
      Object.assign(user, this.originaluserdata);
      // user.firstname = this.originaluserdata.firstname;
      // user.lastname = this.originaluserdata.lastname;
      // user.email = this.originaluserdata.email;
      this.originaluserdata = null; // Clear original data
    }
  }
  DeleteUser(userid:number){
    if(confirm('Are you sure you want to delete this record?')){
      this.usermodel=this.usermodel.filter(x=>x.id!=userid);
      this.httpservice.Delete('User/DeleteUser',userid).subscribe((res)=>{
        console.log(res);
      });
    }
    
  }
}
