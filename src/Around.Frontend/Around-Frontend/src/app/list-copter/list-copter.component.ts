import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatTableDataSource, MatDialog, MatPaginator, MatSort, MatDialogConfig } from '@angular/material';
import { CopterDto } from '../interface/copter-dto';
import { NotificationService } from '../service/notification.service';
import { CopterService } from '../service/copter.service';
import { Copter } from '../model/copter';
import { DialogCopterComponent } from '../dialog-copter/dialog-copter.component';

@Component({
  selector: 'app-list-copter',
  templateUrl: './list-copter.component.html',
  styleUrls: ['./list-copter.component.css']
})
export class ListCopterComponent implements OnInit {

  constructor(private service: CopterService,
    private changeDetectorRefs: ChangeDetectorRef,
    private dialog: MatDialog,
    private notificationService: NotificationService) {
      this.dataSource = new MatTableDataSource();
    }

    dataSource: MatTableDataSource<CopterDto>;
    displayedColumns: string[] =
    ['id', 'name', 'status',
    'brandName', 'costPerMinute', 'maxSpeed',
    'maxFlightHeight', 'control', 'droneType',
    'actions'];
    copters: Copter[] = [];
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    searchKey: string;

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
      dialogConfig.height = '70%';
      dialogConfig.width = '80%';
      this.dialog.open(DialogCopterComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
    });
    }

    onEdit(row) {
      const dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = false;
      dialogConfig.autoFocus = true;
      dialogConfig.height = '70%';
      dialogConfig.width = '80%';
      this.dialog.open(DialogCopterComponent, dialogConfig)
      .afterClosed().subscribe(result => {
        this.refresh();
      });
    }

    onDelete(id: number) {
      if (confirm('Are you sure to delete this record ?')) {
        this.service.deleteCopter(id);
        this.notificationService.warn('! Deleted successfully');
        this.refresh();
      }
    }

    refresh() {
      this.service.getCopters()
        .subscribe((data: CopterDto[]) => {
            this.copters = data.map(dto => Copter.Create(dto));

          console.log(this.copters);
          this.dataSource.data = this.copters;
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
        });
      this.changeDetectorRefs.detectChanges();
    }
}
