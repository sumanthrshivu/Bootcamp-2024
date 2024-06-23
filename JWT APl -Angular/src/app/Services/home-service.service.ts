import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import{usermodel,userrequest} from 'src/app/Models/Usermodel'

@Injectable({
  providedIn: 'root'
})
export class HomeServiceService {
private readonly apiurl:string=environment.apiUrl;
private controllername:string="user";

  constructor(private http:HttpClient) { }
  getuserlits(endpoint: string,userrequest:userrequest):Observable<usermodel[]>{
    return this.http.post<usermodel[]>(`${this.apiurl}/${this.controllername}/${endpoint}`,userrequest);

  }
}
