import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import * as models from '../models';
import { Copter } from 'src/app/model/copter';


@Injectable()
export class StateService {

  public currentPlaceGeometry$: BehaviorSubject<Copter> = new BehaviorSubject(null);
  constructor() { }
}
