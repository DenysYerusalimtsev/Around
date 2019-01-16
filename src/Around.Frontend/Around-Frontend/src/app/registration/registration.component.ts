import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DiscountService } from '../service/discount.service';
import { DiscountDto } from '../interface/discount-dto';
import { ClientAggregate } from '../model/client-aggregate';
import { AuthenticationService } from '../service/authentication.service';
import { NotificationService } from '../service/notification.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registrationForm!: FormGroup;
  discounts: DiscountDto[];
  constructor(private discountService: DiscountService,
    private authService: AuthenticationService,
    private notificationService: NotificationService) { }

  ngOnInit() {
      this.registrationForm = new FormGroup({
        id : new FormControl(null),
        firstName: new FormControl('', {
            validators: [Validators.required]
        }),
        lastName: new FormControl('', {
          validators: [Validators.required]
        }),
        email: new FormControl('', {
          validators: [Validators.required]
        }),
        password: new FormControl('', {
          validators: [Validators.required]
        }),
        discount: new FormControl('', {
          validators: [Validators.required]
        }),
        phoneNumber: new FormControl('', {
          validators: [Validators.required]
        }),
        passportNumber: new FormControl('', {
          validators: [Validators.required]
        })
    });

    this.discountService.getDiscounts()
    .subscribe(data => {
      this.discounts = data;
      console.log(this.discounts);
    });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      const client = new ClientAggregate(
        this.registrationForm.value.firstName,
        this.registrationForm.value.lastName,
        this.registrationForm.value.email,
        this.registrationForm.value.password,
        this.registrationForm.value.discount,
        this.registrationForm.value.phoneNumber,
        this.registrationForm.value.passportNumber);
      this.authService.register(client);
      console.log(client);
      this.notificationService.success(':: Submitted successfully');
    }
  }
}
