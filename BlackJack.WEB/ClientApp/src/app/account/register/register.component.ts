import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  player: Player = new Player(); 
  constructor() { }

  ngOnInit() {
  }

}

class Player {
  userName?: string;
  password?: string;
  passwordConfirm?: string;
}
