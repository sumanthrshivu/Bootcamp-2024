import { Component, Input, OnInit, Output,EventEmitter } from '@angular/core';


@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent {
@Input()datafromparent :string="";
@Output()parentgg= new EventEmitter<string>();
  
submit(){

  this.parentgg.emit("data sent from parent");
}
  
}
