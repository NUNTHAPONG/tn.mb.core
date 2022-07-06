import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/home/home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: 'cs',
        loadChildren: () =>
          import('./features/customers/cs.module').then((m) => m.CsModule),
      },
      {
        path: 'pd',
        loadChildren: () =>
          import('./features/products/pd.module').then((m) => m.PdModule),
      },
    ],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
