import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../service/notification.service';
import { BrandService } from '../service/brand.service';
import { MatDialogRef } from '@angular/material';
import { BrandAggregate } from '../model/brand-aggregate';

@Component({
  selector: 'app-dialog-brand',
  templateUrl: './dialog-brand.component.html',
  styleUrls: ['./dialog-brand.component.css']
})
export class DialogBrandComponent implements OnInit {

    constructor(private service: BrandService,
      private notificationService: NotificationService,
      public dialogRef: MatDialogRef<DialogBrandComponent>) { }

    ngOnInit() {
      this.service.getBrands();
    }

    onClear() {
      this.service.form.reset();
      this.service.initializeFormGroup();
    }

    onSubmit() {
      if (this.service.form.valid) {
        const brand = new BrandAggregate(
          this.service.form.controls['name'].value,
          this.service.form.controls['country'].value);
        this.service.createBrand(brand);
      } else {
          const brand = new BrandAggregate(
          this.service.form.controls['name'].value,
          this.service.form.controls['country'].value);
          this.service.updateBrand(brand);
        }
        this.service.form.reset();
        this.service.initializeFormGroup();
        this.notificationService.success(':: Submitted successfully');
        this.onClose();
      }

    onClose() {
      this.service.form.reset();
      this.service.initializeFormGroup();
      this.dialogRef.close();
    }
}
