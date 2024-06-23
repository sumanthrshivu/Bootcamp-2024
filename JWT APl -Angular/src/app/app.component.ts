import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'JWTLogin';
  constructor(private router: Router) {
    // Subscribe to route changes to update visibility of header and footer
    this.router.events.pipe(
      filter((event: any) => event instanceof NavigationEnd)
    ).subscribe(() => {
      // Check if current route is login or register page
      this.shouldShowHeaderAndFooter();
    });
  }

  shouldShowHeaderAndFooter() {
    const currentUrl = this.router.url;
    return !currentUrl.includes('/login') && !currentUrl.includes('/Register');
  }
}
