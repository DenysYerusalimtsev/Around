import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../service/notification.service';
import { BrandService } from '../service/brand.service';
import { MatDialogRef } from '@angular/material';

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
        this.service.createBrand(this.service.form.value);
      } else {
        this.service.updateBrand(this.service.form.value);
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
