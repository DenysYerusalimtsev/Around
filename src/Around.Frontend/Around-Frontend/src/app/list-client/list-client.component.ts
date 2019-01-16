import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator, MatDialog, MatDialogConfig } from '@angular/material';
import { Client } from '../model/client';
import { ClientService } from '../service/client.service';
import { ClientDto } from '../interface/client-dto';

@Component({
  selector: 'app-list-client',
  templateUrl: './list-client.component.html',
  styleUrls: ['./list-client.component.css']
})
export class ListClientComponent implements OnInit {
  dataSource: MatTableDataSource<Client>;
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'discount'];
  clients: Client[] = [];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;

  constructor(private service: ClientService,
    private changeDetectorRefs: ChangeDetectorRef) {
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

  refresh() {
    this.service.getClients()
    .subscribe((data: ClientDto[]) => {
        this.clients = data.map(dto => Client.Create(dto));

      console.log(this.clients);
      this.dataSource.data = this.clients;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
    this.changeDetectorRefs.detectChanges();
  }
}
