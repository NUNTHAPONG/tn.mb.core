import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import {
  debounceTime,
  Subject,
  switchMap,
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
      this.setPageLength()
    });
    this.installEvent();
  }

  pageChanged(event: PageChangedEvent) {
    return this.page = event.page;
  }

  setPageLength(){
    return this.totalItems = this.customers.length;
  }

  createForm() {
    return this.searchForm = this.fb.group({
      keyword: null,
    });
  }
  
  installEvent() {
    this.onSearch();
  }

  isFormDirty() {
    return this.searchForm.dirty;
  }

  search(word?: string) {
    return this.keyword.next(word);
  }

  onSearch() {
    this.keyword
      .pipe(
        debounceTime(800),
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
    if (this.isFormDirty()) {
      this.searchForm.patchValue({
        keyword: null,
      });
      this.searchForm.markAsPristine();
      this.search();
    }
  }
}
