import { Injectable } from '@angular/core';
import axios from 'axios';
import {MatSnackBar} from "@angular/material/snack-bar";
import {MatButton} from "@angular/material/button";
import {catchError} from "rxjs";

export const customAxios = axios.create({
  baseURL: 'https://localhost:5001'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private matSnackbar: MatSnackBar) {
    customAxios.interceptors.response.use(
      response => {
        if(response.status==201) {
          this.matSnackbar.open("Great success")
        }
        return response;
      }, rejected => {
        if(rejected.response.status>=400 && rejected.response.status <500) {
          matSnackbar.open(rejected.response.data);
        } else if (rejected.response.status>499) {
          this.matSnackbar.open("Something went wrong")
        }
        catchError(rejected);
      }
    )
  }


    async getProducts() {
    const httpResponse = await customAxios.get<any>('product');
    return httpResponse.data;
  }

  async createProduct(dto: { price: number; name: string }) {
    const httpResult = await customAxios.post('product', dto);
    return httpResult.data;
  }

  async deleteProduct(id: any) {
    const httpsResult = await customAxios.delete('product/'+id);
    return httpsResult.data;

  }
}
