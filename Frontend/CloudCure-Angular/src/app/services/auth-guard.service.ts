import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{
  routeURL: string = "";
  constructor(private auth0: AuthService, private router: Router ) 
  {
    this.routeURL = this.router.url;
  }

  //This method gets called in the router section in the App.Module section
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> 
  {
    return new Promise((resolve, reject) => 
    {
      //Here we check if a user is logged in with Auth0
      this.auth0.user$.subscribe(
        (user) =>
        {
          // If they are not logged in, and they are not in the home page, 
          // this will send them to the home page
          if (!user && this.routeURL !== "/home")
          {
            this.routeURL = "/home"
            this.router.navigate(["/home"], 
            {
              queryParams: 
              {
                return: 'home'
              }    
            });            
            return resolve(false);
          }
          else 
          {
            this.routeURL = this.router.url; 
            return resolve(true);
          }
        }
      )
    }
    )
  }
}
