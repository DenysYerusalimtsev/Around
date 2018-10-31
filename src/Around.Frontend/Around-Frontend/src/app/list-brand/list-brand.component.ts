import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { NotificationService } from '../service/notification.service';
import { BrandService } from '../service/brand.service';
import { Brand } from '../model/brand';
import { DialogBrandComponent } from '../dialog-brand/dialog-brand.component';
import { Observable, from } from 'rxjs';
import 'rxjs/add/observable/from';


@Component({
  selector: 'app-list-brand',
  templateUrl: './list-brand.component.html',
  styleUrls: ['./list-brand.component.css']
})
export class ListBrandComponent implements OnInit {

  constructor(private service: BrandService,
    private dialog: MatDialog,
    private notificationService: NotificationService) { }

    dataSource: MatTableDataSource<Brand>;
    displayedColumns: string[] = ['id', 'name', 'country'];
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    searchKey: string;

    ngOnInit() {
      this.service.getBrands()
        .subscribe((data: Brand[]) => {
          console.log(data);
          console.log(data[0]);

        this.dataSource = new MatTableDataSource(data);
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

  onCreate() {
    this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    this.dialog.open(DialogBrandComponent, dialogConfig);
  }

  onEdit(row) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    this.dialog.open(DialogBrandComponent, dialogConfig);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?')) {
    this.service.deleteBrand(id);
    this.notificationService.warn('! Deleted successfully');
    }
  }
}
