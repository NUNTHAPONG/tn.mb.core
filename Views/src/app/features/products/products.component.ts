import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { Subject, debounceTime, switchMap } from 'rxjs';
import { Product, ProductsService } from './products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  totalItems: number;
  page: number = 1;
  itemsPerPage: number = 10;
  keyword = new Subject<string>();
  products: Product[] = []
  searchForm: FormGroup = new FormGroup({});


  constructor(private pd: ProductsService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm()
    this.pd.getAllProducts().subscribe(res => {
      this.createForm();
      this.products = res
      this.setPageLength()
    })
    this.installEvent();
  }

  pageChanged(event: PageChangedEvent) {
    return this.page = event.page;
  }

  setPageLength() {
    return this.totalItems = this.products.length;
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
          return this.pd.getAllProducts(searchText);
        })
      )
      .subscribe((res) => {
        this.products = res;
        this.totalItems = this.products.length;
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
