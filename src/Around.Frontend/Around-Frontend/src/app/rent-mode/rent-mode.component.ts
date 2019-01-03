import { Component, OnInit, Inject } from '@angular/core';
import { ChequeService } from '../service/cheque.service';
import { ChequeAggregate } from '../model/cheque-aggregate';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { RentDto } from '../interface/rent-dto';

@Component({
  selector: 'app-rent-mode',
  templateUrl: './rent-mode.component.html',
  styleUrls: ['./rent-mode.component.css']
})
export class RentModeComponent implements OnInit {
  private rent: RentDto;
  constructor(
    private chequeService: ChequeService,
    private dialogRef: MatDialogRef<RentModeComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
      this.rent = data;
    }

  ngOnInit() {
    console.log(this.rent);
  }

  onRentStop() {
    const cheque = new ChequeAggregate(this.rent.id);
    this.chequeService.createCheque(cheque);
    this.dialogRef.close();
  }
}
