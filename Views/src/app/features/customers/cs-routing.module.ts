import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersDetailComponent } from './customers-detail.component';
import { CustomersComponent } from './customers.component';
import { CustomersResolver } from './customers.resolver';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: 'customer', component: CustomersComponent },
      {
        path: 'customer/detail',
        component: CustomersDetailComponent,
        resolve: {
          data : CustomersResolver
        }
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [CustomersResolver]
})
export class CsRoutingModule {}
