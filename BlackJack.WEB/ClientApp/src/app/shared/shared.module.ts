import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForLoggedPlayersMenuComponent } from './components/for-logged-players-menu/for-logged-players-menu.component';
import { ForNonLoggedPlayersMenuComponent } from './components/for-non-logged-players-menu/for-non-logged-players-menu.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    ForLoggedPlayersMenuComponent,
    ForNonLoggedPlayersMenuComponent
  ],
  imports: [
    CommonModule, RouterModule
  ],
  providers: [
    
  ],
  exports: [
    ForLoggedPlayersMenuComponent,
    ForNonLoggedPlayersMenuComponent,
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule
  ]
})
export class SharedModule { }
