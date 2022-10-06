import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{


  productName: string = "";
  productPrice: number = 0;
  products: any[] = [];


  constructor(private http: HttpService) {

  }


  async ngOnInit() {
    const products = await this.http.getProducts();
    this.products = products;
  }

  async createProduct() {
    let dto = {
      price: this.productPrice,
      name: this.productName
    }
    const result = await this.http.createProduct(dto);
    this.products.push(result)
  }

  async deleteProduct(id: any) {
    const product = await this.http.deleteProduct(id);
    this.products = this.products.filter(p => p.id != product.id)
  }
}
