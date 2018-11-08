import { Component, OnInit } from '@angular/core';
import * as models from '../core/models';
import { BehaviorSubject } from 'rxjs';
import { StateService } from '../core/services';

@Component({
  selector: 'app-map-component',
  templateUrl: './map-component.html',
  styleUrls: ['./map-component.css']
})
export class MapComponent implements OnInit {

  places$: BehaviorSubject<models.Place[]> = new BehaviorSubject(null);
  actionName = 'Close';

  constructor(private stateService: StateService) {}

  ngOnInit() {
    this.places$ = this.stateService.places$;
  }

  changeActionName() {
    if (this.actionName === 'Open') {
      this.actionName = 'Close';
    } else {
      this.actionName = 'Open';
    }
  }
}
