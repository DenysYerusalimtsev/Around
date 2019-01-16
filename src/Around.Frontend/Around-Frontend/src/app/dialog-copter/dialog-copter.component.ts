import { Component, OnInit } from '@angular/core';
import { CopterService } from '../service/copter.service';
import { NotificationService } from '../service/notification.service';
import { MatDialogRef } from '@angular/material';
import { CopterAggregate } from '../model/copter-aggregate';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { BrandService } from '../service/brand.service';
import { BrandDto } from '../interface/brand-dto';

@Component({
  selector: 'app-dialog-copter',
  templateUrl: './dialog-copter.component.html',
  styleUrls: ['./dialog-copter.component.css']
})
export class DialogCopterComponent implements OnInit {

  coptersForm!: FormGroup;
  brands: BrandDto[];
  constructor(private copterService: CopterService,
    private brandService: BrandService,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<DialogCopterComponent>) { }

    ngOnInit() {
      this.coptersForm = new FormGroup({
        id : new FormControl(null),
        name: new FormControl('', {
            validators: [Validators.required]
        }),
        status: new FormControl('', {
          validators: [Validators.required]
        }),
        latitude: new FormControl('', {
          validators: [Validators.required]
        }),
        longitude: new FormControl('', {
          validators: [Validators.required]
        }),
        brandName: new FormControl('', {
          validators: [Validators.required]
        }),
        costPerMinute: new FormControl('', {
          validators: [Validators.required]
        }),
        maxSpeed: new FormControl('', {
          validators: [Validators.required]
        }),
        maxFlightHeight: new FormControl('', {
          validators: [Validators.required]
        }),
        control: new FormControl('', {
          validators: [Validators.required]
        }),
        droneType: new FormControl('', {
          validators: [Validators.required]
        })
    });

    this.brandService.getBrands()
    .subscribe(data => {
      this.brands = data;
      console.log(this.brands);
    });

    this.copterService.getCopters();
  }

  onClear() {
    this.coptersForm.reset();
  }

  onSubmit() {
    if (this.coptersForm.valid) {
      const copter = new CopterAggregate(
        this.coptersForm.value.name,
        this.coptersForm.value.status,
        this.coptersForm.value.latitude,
        this.coptersForm.value.longitude,
        this.coptersForm.value.costPerMinute,
        this.coptersForm.value.brandName,
        this.coptersForm.value.maxSpeed,
        this.coptersForm.value.maxFlightHeight,
        this.coptersForm.value.control,
        this.coptersForm.value.droneType);
      this.copterService.createCopter(copter);
      console.log(copter);
      this.onClose();
      this.notificationService.success(':: Submitted successfully');
    }
  }

  onClose() {
    this.coptersForm.reset();
    this.dialogRef.close();
  }
}
