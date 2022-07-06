import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { switchMap, finalize } from 'rxjs/operators';
import { Customer, CustomersService } from './customers.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-customers-detail',
  templateUrl: './customers-detail.component.html',
  styleUrls: ['./customers-detail.component.css'],
})
export class CustomersDetailComponent implements OnInit {
  customer: Customer = {} as Customer;
  customerForm: FormGroup = new FormGroup({});
  canDelete = false;
  saving = false;
  modalRef: BsModalRef;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private cs: CustomersService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.route.data.subscribe(res => {
      this.customer = res.data.detail;
      this.rebuildForm();
    })
    this.installEvent();
  }

  createForm() {
    this.customerForm = this.fb.group({
      customerId: "AUTO",
      firstName: [null, [Validators.required, Validators.maxLength(200)]],
      lastName: [null, [Validators.required, Validators.maxLength(200)]],
      phone: [null, [Validators.maxLength(25)]],
      email: [
        null,
        [Validators.required, Validators.maxLength(200), Validators.email],
      ],
      street: [null, [Validators.maxLength(200)]],
      city: [null, [Validators.maxLength(50)]],
      state: [null, [Validators.maxLength(25)]],
      zipCode: [null, [Validators.maxLength(5), Validators.pattern('\\d*')]],
    });
  }

  rebuildForm() {
    this.customerForm.controls.customerId.disable({ emitEvent: false });
    if (this.customer && this.customer.customerId && this.customer.rowVersion) {
      this.customerForm.patchValue(this.customer);
      this.canDelete = true;
    } else {
      this.customerForm.markAsPristine();
      this.customer.orders = [];
    }
  }

  installEvent() { }

  isFormDirty() {
    return this.customerForm.dirty;
  }

  isFormValid() {
    return this.customerForm.valid;
  }

  openModal(template: TemplateRef<any>) {
    if (this.isFormValid()) {
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

  clear() {
    if (this.isFormDirty()) {
      this.customerForm.reset({ customerId: "AUTO" });
      this.customerForm.markAsPristine();
    }
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
