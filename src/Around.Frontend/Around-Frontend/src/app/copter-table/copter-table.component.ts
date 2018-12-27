import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { Copter } from '../model/copter';
import { CopterDto } from '../interface/copter-dto';
import { CopterService } from '../service/copter.service';
import { StateService } from '../core/services';
import { RentAggregate } from '../model/rent-aggregate';
import { RentService } from '../service/rent.service';
import { Rent } from '../model/rent';
import { RentDto } from '../interface/rent-dto';

@Component({
  selector: 'app-copter-table',
  templateUrl: './copter-table.component.html',
  styleUrls: ['./copter-table.component.css']
})
export class CopterTableComponent implements OnInit {

  constructor(private copterService: CopterService,
    private rentService: RentService,
    private stateService: StateService) {
      this.dataSource = new MatTableDataSource();
  }

    googleMap = 'https://www.google.com/maps/dir/?api=1&destination=';
    dataSource: MatTableDataSource<CopterDto>;
    displayedColumns: string[] =
    ['name', 'status', 'brandName',
    'costPerMinute', 'actions'];
    copters: Copter[] = [];
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    searchKey: string;

    ngOnInit() {
      this.rentService.getRents()
        .subscribe((data: RentDto[]) => {
        console.log(data.map(dto => Rent.Create(dto)));
        });

      this.copterService.getCopters()
        .subscribe((data: CopterDto[]) => {
            this.copters = data.map(dto => Copter.Create(dto));

          console.log(this.copters);
          this.dataSource.data = this.copters;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        });
      }
    onSearchClear() {
      this.searchKey = '';
      this.applyFilter();
    }

    applyFilter() {
      this.dataSource.filter = this.searchKey.trim().toLowerCase();
    }

    markOnMap(copter: Copter) {
      this.stateService.currentPlaceGeometry$.next(copter);
    }

    book(copter: Copter) {
      console.log(copter);

      if (copter.status !== 'Ordered') {

        console.log('Start booking...');

        const rent = new RentAggregate(1, copter.id);

        console.log('Rent on frontend', JSON.stringify(rent));

        this.rentService.createRent(rent);

        console.log('Rent created...');
      }
    }
  }
