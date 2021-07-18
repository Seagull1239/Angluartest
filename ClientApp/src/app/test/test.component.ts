import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit{
  public products: Products[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    
  }
  ngOnInit() {
    this.http.get<Products[]>(this.baseUrl + 'products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

interface Products {
  productId: number;
  name: string;
  price: number;
  stock: number;
}
