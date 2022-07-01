import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersDetailComponent } from './customers-detail.component';
import { CustomersComponent } from './customers.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: 'customer', component: CustomersComponent },
      {
        path: 'customer/detail',
        component: CustomersDetailComponent
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class CsRoutingModule {}
