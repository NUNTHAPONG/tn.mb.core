import { Injectable } from '@angular/core';
import {
  Router,
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { forkJoin, map, Observable, of } from 'rxjs';
import { Customer, CustomersService } from './customers.service';

@Injectable({
  providedIn: 'root',
})
export class CustomersResolver implements Resolve<boolean> {
  constructor(private router: Router, private cs: CustomersService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> {
    const param = this.router.getCurrentNavigation()?.extras.state;
    const detailResult =
      param && param.id
        ? this.cs.findCustomerById(param.id)
        : of({} as Customer);

    return forkJoin([detailResult]).pipe(
      map((result) => {
        const detail = result[0];
        return {
          detail,
        };
      })
    );
  }
}
