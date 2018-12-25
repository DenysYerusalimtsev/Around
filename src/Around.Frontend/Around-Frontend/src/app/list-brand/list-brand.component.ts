import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { NotificationService } from '../service/notification.service';
import { BrandService } from '../service/brand.service';
import { Brand } from '../model/brand';
import { DialogBrandComponent } from '../dialog-brand/dialog-brand.component';
import { BrandDto } from '../interface/brand-dto';
import { Country } from '../interface/country-dto';
import { CountryService } from '../service/country.service';


@Component({
  selector: 'app-list-brand',
  templateUrl: './list-brand.component.html',
  styleUrls: ['./list-brand.component.css']
})
export class ListBrandComponent implements OnInit {

  countries: Country[];
  dataSource: MatTableDataSource<Brand>;
  displayedColumns: string[] = ['id', 'name', 'country', 'actions'];
  brands: Brand[] = [];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;

  constructor(private service: BrandService,
    private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog,
    private notificationService: NotificationService) {
      this.dataSource = new MatTableDataSource();
     }

    ngOnInit() {
      this.refresh();
    }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {
    this.dataSource.filter = this.searchKey.trim().toLowerCase();
  }

  onCreate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = false;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '40%';
    this.dialog.open(DialogBrandComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
    });
  }

  onEdit(row) {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = false;
      dialogConfig.autoFocus = true;
      dialogConfig.width = '60%';
      this.dialog.open(DialogBrandComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
    });
  }

  onDelete(id: number) {
      if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteBrand(id);
      this.notificationService.warn('! Deleted successfully');
      this.refresh();
    }
  }

  refresh() {
    this.service.getBrands()
    .subscribe((data: BrandDto[]) => {
        this.brands = data.map(dto => Brand.Create(dto));

      console.log(this.brands);
      this.dataSource.data = this.brands;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
    this.changeDetectorRefs.detectChanges();
  }
}
