import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';

import { CsRoutingModule } from './cs-routing.module';
import { CustomersService } from './customers.service';
import { CustomersComponent } from './customers.component';
import { CustomersDetailComponent } from './customers-detail.component';

@NgModule({
  declarations: [CustomersComponent, CustomersDetailComponent],
  imports: [
    CommonModule,
    CsRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule,
    ModalModule.forRoot(),
  ],
  providers: [CustomersService],
})
export class CsModule {}
