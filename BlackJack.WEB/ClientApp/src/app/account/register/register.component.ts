import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { RegisterAccountView } from 'src/app/shared/entities/account.views/register.account.view';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: RegisterAccountView = new RegisterAccountView();
  constructor(private accountService: AccountService, private router: Router)
  {

  }
  register() {
    this.accountService.register(this.model).subscribe(data => this.router.navigateByUrl("/"));
  }
  ngOnInit() {
  }

}
