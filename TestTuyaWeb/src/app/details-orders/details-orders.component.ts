import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-details-orders',
  templateUrl: './details-orders.component.html',
  styleUrls: ['./details-orders.component.css']
})
export class DetailsOrdersComponent implements OnInit {

  constructor(private http:HttpClient) { }
  
  @Input() idOrden: number | undefined;
  
  detail:any=[];

  modalTitle="";

  ngOnInit(): void {
  }

}
