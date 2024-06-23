import { Inject, Injectable } from '@angular/core';
import { Observable, catchError, throwError} from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {
  //private readonly apiurl=environment.apiUrl;
  constructor(private http:HttpClient, @Inject('apiurl')private apiurl:string) { }

  Get(endpoint: string):Observable<any>{
    const url=`${this.apiurl}/${endpoint}`;
    return this.http.get(url);
  }

  Post(endpoint: string, data: any): Observable<any> {
    const url = `${this.apiurl}/${endpoint}`;
    return this.http.post(url, data).pipe(
      catchError(error => {
        console.error('HTTP error occurred:', error);
        return throwError('Something went wrong; please try again later.'); // Or handle the error as needed
      })
    );
  }
  Put(endpoint: string, data: any): Observable<any> {
    const url = `${this.apiurl}/${endpoint}`;
    return this.http.put(url, data).pipe(
      catchError(error => {
        console.error('HTTP error occurred:', error);
        return throwError('Something went wrong; please try again later.'); // Or handle the error as needed
      })
    );
  }
  Delete(endpoint: string, data: any): Observable<any> {
    const url = `${this.apiurl}/${endpoint}/${data}`;
    return this.http.delete(url).pipe(
      catchError(error => {
        console.error('HTTP error occurred:', error);
        return error;
        // return throwError('Something went wrong; please try again later.'); // Or handle the error as needed
      })
    );
  }
}
interface LoginResult {
  message: string;
}

