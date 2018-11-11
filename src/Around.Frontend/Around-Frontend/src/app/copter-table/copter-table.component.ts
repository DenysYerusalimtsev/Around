import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { Copter } from '../model/copter';
import { CopterDto } from '../interface/copter-dto';
import { CopterService } from '../service/copter.service';

@Component({
  selector: 'app-copter-table',
  templateUrl: './copter-table.component.html',
  styleUrls: ['./copter-table.component.css']
})
export class CopterTableComponent implements OnInit {

  constructor(private service: CopterService) {
      this.dataSource = new MatTableDataSource();
     }

    dataSource: MatTableDataSource<CopterDto>;
    displayedColumns: string[] =
    ['name', 'status',
    'brandName', 'costPerMinute', 'actions'];
    copters: Copter[] = [];
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    searchKey: string;

    ngOnInit() {
      this.service.getCopters()
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
   }
