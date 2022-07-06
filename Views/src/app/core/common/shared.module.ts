import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent } from './component/table/table.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [TableComponent],
  imports: [
    CommonModule,
    NgxDatatableModule
  ],
  exports: [
    TableComponent
  ]
})
export class SharedModule { }
