import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../service/notification.service';
import { BrandService } from '../service/brand.service';
import { MatDialogRef } from '@angular/material';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Country } from '../model/country';
import { CountryService } from '../service/country.service';
import { BrandAggregate } from '../model/brand-aggregate';

@Component({
  selector: 'app-dialog-brand',
  templateUrl: './dialog-brand.component.html',
  styleUrls: ['./dialog-brand.component.css']
})
export class DialogBrandComponent implements OnInit {

  brandFormGroup!: FormGroup;
  countries: Country[];

    constructor(private brandService: BrandService,
      private countryService: CountryService,
      private notificationService: NotificationService,
      public dialogRef: MatDialogRef<DialogBrandComponent>) { }

    ngOnInit() {
        this.brandFormGroup = new FormGroup({
          id : new FormControl(null),
          name: new FormControl('', {
              validators: [Validators.required]
          }),
          country: new FormControl('', {
              validators: [Validators.required]
          })
      });

      this.countryService.getCountries()
        .subscribe( data => {
          this.countries = data;
          console.log(this.countries);
        });

    }

    onSubmit() {
      const brand = new BrandAggregate(
        this.brandFormGroup.value.name,
        this.brandFormGroup.value.country
      );

      this.brandService.createBrand(brand);
      this.notificationService.success(':: Submitted successfully');
      this.onClose();


      /*
      if (this.brandService.form.valid) {
        const brand = new BrandAggregate(
          this.brandService.form.controls['name'].value,
          this.brandService.form.controls['country'].value);
        this.brandService.createBrand(brand);
      } else {
          const brand = new BrandAggregate(
          this.brandService.form.controls['name'].value,
          this.brandService.form.controls['country'].value);
          this.brandService.updateBrand(brand);
        }
        this.notificationService.success(':: Submitted successfully');
        this.onClose();*/
      }

    onClose() {
      this.brandFormGroup.reset();
      this.dialogRef.close();
    }
}
