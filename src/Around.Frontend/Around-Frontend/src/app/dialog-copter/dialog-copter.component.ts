import { Component, OnInit } from '@angular/core';
import { CopterService } from '../service/copter.service';
import { NotificationService } from '../service/notification.service';
import { MatDialogRef } from '@angular/material';
import { CopterAggregate } from '../model/copter-aggregate';

@Component({
  selector: 'app-dialog-copter',
  templateUrl: './dialog-copter.component.html',
  styleUrls: ['./dialog-copter.component.css']
})
export class DialogCopterComponent implements OnInit {

  constructor(private service: CopterService,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<DialogCopterComponent>) { }

  ngOnInit() {
    this.service.getCopters();
  }

  onClear() {
    this.service.form.reset();
    this.service.initializeFormGroup();
  }

  onSubmit() {
    if (this.service.form.valid) {
      const copter = new CopterAggregate(
        this.service.form.controls['name'].value,
        this.service.form.controls['status'].value,
        this.service.form.controls['latitude'].value,
        this.service.form.controls['longitude'].value,
        this.service.form.controls['costPerMinute'].value,
        this.service.form.controls['brandName'].value,
        this.service.form.controls['costPerMinute'].value,
        this.service.form.controls['maxSpeed'].value,
        this.service.form.controls['maxFlightHeight'].value,
        this.service.form.controls['control'].value,
        this.service.form.controls['droneType'].value);
      this.service.createCopter(copter);
    } else {
      const copter = new CopterAggregate(
        this.service.form.controls['name'].value,
        this.service.form.controls['status'].value,
        this.service.form.controls['latitude'].value,
        this.service.form.controls['longitude'].value,
        this.service.form.controls['costPerMinute'].value,
        this.service.form.controls['brandName'].value,
        this.service.form.controls['costPerMinute'].value,
        this.service.form.controls['maxSpeed'].value,
        this.service.form.controls['maxFlightHeight'].value,
        this.service.form.controls['control'].value,
        this.service.form.controls['droneType'].value);
      this.service.updateCopter(copter);
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
