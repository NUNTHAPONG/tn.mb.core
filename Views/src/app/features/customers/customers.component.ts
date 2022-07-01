import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import {
  debounce,
  debounceTime,
  map,
  Observable,
  of,
  Subject,
  switchMap,
  take,
} from 'rxjs';
import { Customer, CustomersService } from './customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})
export class CustomersComponent implements OnInit {
  totalItems: number;
  page: number = 1;
  itemsPerPage: number = 10;
  keyword = new Subject<string>();
  customers: Customer[] = [];
  addCustomer: Customer = {} as Customer;
  searchForm: FormGroup = new FormGroup({});

  constructor(private cs: CustomersService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.addCustomer.rowState = 1;
    this.createForm();
    this.cs.getCustomersAll().subscribe((res) => {
      this.customers = res;
      this.totalItems = this.customers.length;
    });
    this.installEvent();
    this.onSearch();
  }

  pageChanged(event: PageChangedEvent): void {
    this.page = event.page;
  }

  createForm() {
    this.searchForm = this.fb.group({
      keyword: null,
    });
  }

  t;

  drop() : Promise<number> {
    return this.cs.findById(1111).subscribe(res => {
      return res.customerId;
    })
  }
  
  installEvent() {
    Observable.
    console.log(this.t);
    console.log(2);
  }

  search(word?: string) {
    this.keyword.next(word);
  }

  onSearch() {
    this.keyword
      .pipe(
        debounceTime(400),
        switchMap((searchText) => {
          return this.cs.getCustomersAll(searchText);
        })
      )
      .subscribe((res) => {
        this.customers = res;
        this.totalItems = this.customers.length;
      });
  }

  clear() {
    if (this.searchForm.dirty) {
      this.searchForm.patchValue({
        keyword: null,
      });
      this.searchForm.markAsPristine();
      this.search();
    }
  }
}
