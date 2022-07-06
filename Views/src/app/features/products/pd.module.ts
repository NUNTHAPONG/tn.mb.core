import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PdRoutingModule } from './pd-routing.module';
import { ProductsComponent } from './products.component';
import { ProductsService } from './products.service';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { SharedModule } from 'src/app/core/common/shared.module';

@NgModule({
  declarations: [ProductsComponent],
  imports: [
    CommonModule,
    PdRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule,
    ModalModule.forRoot(),
    NgxDatatableModule,
    SharedModule
  ],
  providers: [ProductsService]
})
export class PdModule { }
