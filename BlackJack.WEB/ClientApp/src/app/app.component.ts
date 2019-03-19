import { Component, OnInit, AfterContentInit, AfterViewInit } from '@angular/core';
import { AccountService } from './shared/services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent{
  title = 'Black Jack';
}
