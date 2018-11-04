import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { NotificationService } from '../service/notification.service';
import { BrandService } from '../service/brand.service';
import { Brand } from '../model/brand';
import { DialogBrandComponent } from '../dialog-brand/dialog-brand.component';
import { Observable, from } from 'rxjs';
import 'rxjs/add/observable/from';
import { BrandDto } from '../interface/brand-dto';


@Component({
  selector: 'app-list-brand',
  templateUrl: './list-brand.component.html',
  styleUrls: ['./list-brand.component.css']
})
export class ListBrandComponent implements OnInit {

  constructor(private service: BrandService,
    private dialog: MatDialog,
    private notificationService: NotificationService) {
      this.dataSource = new MatTableDataSource();
     }

    dataSource: MatTableDataSource<Brand>;
    displayedColumns: string[] = ['id', 'name', 'country', 'actions'];
    brands: Brand[] = [];
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    searchKey: string;

    ngOnInit() {
      this.service.getBrands()
        .subscribe((data: BrandDto[]) => {
            this.brands = data.map(dto => Brand.Create(dto));

          console.log(this.brands);
          this.dataSource.data = this.brands;
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
