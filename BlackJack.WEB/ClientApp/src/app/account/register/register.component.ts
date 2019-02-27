import { Component, OnInit, Input } from '@angular/core';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  player: RegisterAccountView = new RegisterAccountView();
  constructor(private accountService: AccountService, private router: Router)
  {

  }
  save() {
    this.accountService.register(this.player).subscribe(data => this.router.navigateByUrl("/"));
  }
  ngOnInit() {
  }

}
