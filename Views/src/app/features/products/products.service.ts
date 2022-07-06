import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface Brand {
  brandId: number;
  brandName: string;
  rowVersion: number;
  rowState: number;
}

export interface Categorie {
  categoryId: number;
  categoryName: string;
  rowVersion: number;
  rowState: number;
}

export interface Product {
  productId: number;
  productName: string;
  brandId: number;
  categoryId: number;
  modelYear: number;
  listPrice: number;
  brands: Brand;
  categories: Categorie;
  rowVersion: number;
  rowState: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  getAllProducts(keyword?: string){
    keyword = keyword ? keyword : '';
    const filter = Object.assign({}, { keyword: keyword });
    return this.http.get<Product[]>("/api/products", { params: filter })
  }
}
