import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Client } from '../model/client';
import { LoginModel } from '../model/login-model';
import { Router } from '@angular/router';
import { ClientAggregate } from '../model/client-aggregate';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<Client>;
    public currentUser: Observable<Client>;
    registerUrl = 'https://localhost:55555/api/Auth/register';

    constructor(private http: HttpClient,
        private router: Router) {
        this.currentUserSubject = new BehaviorSubject<Client>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): Client {
        return this.currentUserSubject.value;
    }

    login(loginModel: LoginModel) {
        return this.http.post<any>(`https://aroundtest.azurewebsites.net/api/Auth/authenticate`, loginModel)
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    this.currentUserSubject.next(user);
                    console.log('works');
                }

                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }

    register(client: ClientAggregate) {
        return this.http.post(this.registerUrl, client,
        {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
            responseType: 'text'
        }).subscribe(data => console.log('Works!'));
    }
}
