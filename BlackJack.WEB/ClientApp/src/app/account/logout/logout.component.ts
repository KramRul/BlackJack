import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  validationErrors: string;

  constructor(private accountService: AccountService, private router: Router) {
  }

  ngOnInit() {
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
  }
}
