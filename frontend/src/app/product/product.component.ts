import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import axios from 'axios';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  productName: string = "";
  productPrice: number = 0;
  products: any[] = [];

  postnr: string = "6700";
  by: string="esbjerg";

  adresser: RootObject[] = [];


  constructor(private http: HttpService) {

  }


  async ngOnInit() {
    //const products = await this.http.getProducts();
    //this.products = products;
    const rees = await axios.get<RootObject[]>(
    'https://api.dataforsyningen.dk/adresser/autocomplete?q='+this.by+'&postnr='+this.postnr);
    this.adresser = rees.data;
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


   async find() {
    const rees = await axios.get(
      'https://api.dataforsyningen.dk/adresser/autocomplete?q='+this.by+'&postnr='+this.postnr); this.adresser = rees.data;
  }
}


export interface Adresse {
  id: string;
  status: number;
  darstatus: number;
  vejkode: string;
  vejnavn: string;
  adresseringsvejnavn: string;
  husnr: string;
  etage?: any;
  dør?: any;
  supplerendebynavn: string;
  postnr: string;
  postnrnavn: string;
  stormodtagerpostnr?: any;
  stormodtagerpostnrnavn?: any;
  kommunekode: string;
  adgangsadresseid: string;
  x: number;
  y: number;
  href: string;
}

export interface RootObject {
  tekst: string;
  adresse: Adresse;
}
