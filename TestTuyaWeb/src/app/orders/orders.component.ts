import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  constructor(private http:HttpClient) { }

  order:any=[];

  modalTitle=""
  Id=0
  FechaOrden=""
  CustomerId=""
  ValorOrden=""
  
  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.http.get<any>(environment.API_URL+'order')
    .subscribe(data=>{
      this.order=data;
    });
  }

  addClick(){
    this.modalTitle="Add orders";
    this.Id=0
    this.FechaOrden=""
    this.CustomerId=""
    this.ValorOrden=""
    }

  editClick(dep:any){
    this.modalTitle="Edit orders";
    this.Id=dep.Id;
    this.FechaOrden=dep.FechaOrden
    this.CustomerId=dep.CustomerId
    this.ValorOrden=dep.ValorOrden
  }

  createClick(){
    var val={FechaOrden:this.FechaOrden,
      CustomerId:this.CustomerId,
      ValorOrden:this.ValorOrden
      
};
    

    this.http.post(environment.API_URL+"order",val).subscribe(res=>{
      alert(res.toString());
      this.refreshList();
    });
  }


  upDateClick(){
    var val={Id:this.Id,
      FechaOrden:this.FechaOrden,
      CustomerId:this.CustomerId,
      ValorOrden:this.ValorOrden
  };

    this.http.put(environment.API_URL+"order/"+this.Id,val).subscribe(res=>{
      alert(res.toString());
      this.refreshList();
    });
  }

  deleteClick(id:any){
    if(confirm("Are You sure to Delete? ")){      
      this.http.delete(environment.API_URL+'order/'+id).subscribe(res=>{
        alert(res.toString());
        this.refreshList();
      });
    }; 
  }

  verDetalle(id:any){}

}
