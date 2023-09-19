import { Component, OnInit } from '@angular/core';

import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {

  constructor(private http:HttpClient) { }

  customers:any=[];

  modalTitle=""
  Id=0
  Nombre=""
  Apellidos=""
  Identificacion=""  
  Email=""
  Telefono=""


  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.http.get<any>(environment.API_URL+'Customer')
    .subscribe(data=>{
      this.customers=data;
    });
  }

  addClick(){
    this.modalTitle="Add Customers";
    this.Id=0
    this.Nombre=""
    this.Apellidos=""
    this.Identificacion=""    
    this.Email=""
    this.Telefono=""
  }

  editClick(dep:any){
    this.modalTitle="Edit Customers";
    this.Id=dep.Id;
    this.Nombre=dep.Nombre
    this.Apellidos=dep.Apellidos
    this.Identificacion=dep.Identificacion   
    this.Email=dep.Email
    this.Telefono=dep.Telefono
  }

  createClick(){
    var val={Nombre:this.Nombre,
      Apellidos:this.Apellidos,
      Identificacion:this.Identificacion,      
      Email:this.Email,
      Telefono:this.Telefono};
    

    this.http.post(environment.API_URL+"customer",val).subscribe(res=>{
      alert(res.toString());
      this.refreshList();
    });
  }


  updateClick(){
    var val={Id:this.Id,
      Nombre:this.Nombre,
      Apellidos:this.Apellidos,
      Identificacion:this.Identificacion,      
      Email:this.Email,
      Telefono:this.Telefono    
    };

    this.http.put(environment.API_URL+"customer/"+this.Id,val).subscribe(res=>{
      alert(res.toString());
      this.refreshList();
    });
  }

  deleteClick(id:any){
    if(confirm("Are You sure to Delete? ")){      
      this.http.delete(environment.API_URL+'customer/'+id).subscribe(res=>{
        alert(res.toString());
        this.refreshList();
      });
    };
    
      
      
  }

}
