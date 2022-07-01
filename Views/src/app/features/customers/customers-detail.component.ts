import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { switchMap, finalize } from 'rxjs/operators';
import { Customer, CustomersService } from './customers.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-customers-detail',
  templateUrl: './customers-detail.component.html',
  styleUrls: ['./customers-detail.component.css'],
})
export class CustomersDetailComponent implements OnInit {
  params;
  customer: Customer = {} as Customer;
  customerForm: FormGroup = new FormGroup({});
  canDelete = false;
  saving = false;
  modalRef: BsModalRef;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private cs: CustomersService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.params = this.router.getCurrentNavigation()?.extras.state;
    this.createForm();
    this.cs.findById(this.params.id).subscribe((res) => {
      this.customer = res;
      this.rebuildForm();
    });
    this.installEvent();
  }

  createForm() {
    this.customerForm = this.fb.group({
      customerId: null,
      firstName: [null, [Validators.required, Validators.maxLength(200)]],
      lastName: [null, [Validators.required, Validators.maxLength(200)]],
      phone: [
        null,
        [
          Validators.maxLength(25),
          Validators.pattern('[(][0-9]{3}[)] [0-9]{3}[-][0-9]{4}'),
        ],
      ],
      email: [
        null,
        [Validators.required, Validators.maxLength(200), Validators.email],
      ],
      street: [null, [Validators.maxLength(200)]],
      city: [null, [Validators.maxLength(50)]],
      state: [null, [Validators.maxLength(25)]],
      zipCode: [null, [Validators.maxLength(5), Validators.pattern('[0-9]*')]],
    });
  }

  rebuildForm() {
    this.customerForm.controls.customerId.disable({ emitEvent: false });
    if (this.customer && this.customer.customerId && this.customer.rowVersion) {
      this.customerForm.patchValue(this.customer);
      this.canDelete = true;
    } else {
      this.customerForm.controls.customerId.setValue('AUTO');
      this.customerForm.markAsPristine();
      this.customer.orders = [];
    }
  }

  installEvent() {}

  openModal(template: TemplateRef<any>) {
    if (this.customerForm.valid) {
      this.modalRef = this.modalService.show(template);
    }
  }

  closeModal() {
    return this.modalService.hide();
  }

  save() {
    this.saving = true;
    this.cs
      .save(this.customer, this.customerForm.getRawValue())
      .pipe(
        switchMap((result) => this.cs.findById(result.customerId)),
        finalize(() => (this.saving = false))
      )
      .subscribe((result) => {
        this.customer = result;
        this.rebuildForm();
      });
    this.closeModal();
  }

  delete() {
    this.cs
      .delete(this.customer.customerId, this.customer.rowVersion)
      .subscribe((result) => {
        this.customer = result;
        this.rebuildForm();
      });
    this.closeModal();
  }
}
