import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { PlacesTableDataSource } from './places-table-datasource';
import * as models from '../core/models';
import { OriginConnectionPosition } from '@angular/cdk/overlay';
import { StateService } from '../core/services';
import { MatDialog } from '@angular/material';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-places-table',
  templateUrl: './places-table.component.html',
  styleUrls: ['./places-table.component.scss']
})
export class PlacesTableComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: PlacesTableDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['link', 'name', 'mark', 'X'];

  constructor(private stateService: StateService, public dialog: MatDialog) { }

  ngOnInit() {
    this.dataSource = new PlacesTableDataSource(this.paginator, this.sort, this.stateService);
  }

  markOnMap(place: models.Place) {
    this.stateService.currentPlaceGeometry$.next(place.geometry);
  }
}
