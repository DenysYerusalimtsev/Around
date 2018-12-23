import { Component, OnInit , Input } from '@angular/core';
import { Observable ,  Observer } from 'rxjs';
@Component({
    // tslint:disable-next-line:component-selector
    selector: 'dashcard',
    templateUrl: './dashcard.component.html',
    styleUrls: ['./dashcard.component.scss']
})
export class DashcardComponent implements OnInit {
    @Input() dashData: any;
    constructor() {
    }

    ngOnInit() {
    }
}
