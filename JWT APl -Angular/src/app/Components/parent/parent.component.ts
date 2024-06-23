import { Component, OnInit, Output } from '@angular/core';
import { EventEmitter } from 'stream';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent {
sendvaluetochild:string="data from parent"
gg:string='';

  recivedata(data:any){
    this.gg=data;

  }
  
}
