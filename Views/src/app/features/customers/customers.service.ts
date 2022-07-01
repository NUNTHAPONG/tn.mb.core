import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

export interface Customer {
  data: any;
  customerId: number;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  street: string;
  city: string;
  state: string;
  zipCode: string;
  rowVersion: number;
  rowState: number;
  orders: Order[];
}

export interface Order {
  orderId: number;
  customerId: number;
  orderStatus: number;
  orderDate: Date;
  requiredDate: Date;
  shippedDate?: Date;
  storeId: number;
  staffId: number;
  rowVersion: number;
  rowState: number;
  form?: FormGroup;
}

@Injectable({
  providedIn: 'root',
})
export class CustomersService {
  constructor(private http: HttpClient) {}

  getCustomersAll(keyword?: string) {
    keyword = keyword ? keyword : '';
    const filter = Object.assign({}, { keyword: keyword });
    return this.http.get<Customer[]>('/api/customers', { params: filter });
  }

  findById(id: number) {
    return this.http.get<Customer>('/api/customers/findById/' + id);
  }

  save(row: Customer, form: FormGroup) {
    const body = Object.assign({}, row, form);
    if (row.rowVersion) {
      return this.http.put<any>('/api/customers', body);
    } else {
      body.customerId = 0;
      return this.http.post<any>('/api/customers', body);
    }
  }

  delete(id: number, version: number) {
    return this.http.delete<any>('/api/customers', {
      params: { customerId: id, rowVersion: version },
    });
  }
}
