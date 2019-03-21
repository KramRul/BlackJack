import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/shared/services/game.service';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/shared/services/account.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  public playerName: string;

  public startForm = this.formBuilder.group({
    countOfBots: [1, Validators.required]
  });

  constructor(
    private gameService: GameService,
    private accountService: AccountService,
    private notifyService: NotificationService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  start(): void {
    this.gameService.start(this.startForm.get('countOfBots').value).subscribe(
      data => {
        this.router.navigate(["/game/start"]);
      }
      , error => this.notifyService.showError(error)
    );
  }

  ngOnInit(): void {
    this.playerName = this.accountService.getLoggedPlayerName();
  }
}
