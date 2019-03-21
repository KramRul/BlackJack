import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})

export class NotificationService {
  private options =
    {
      disableTimeOut: false,
      tapToDismiss: true,
      closeButton: true,
      timeOut: 5000,
      extendedTimeOut: 1000,
      positionClass: 'toast-top-right'
    }
  constructor(private toastr: ToastrService) { }

  showSuccess(message: string, title?: string): void {
    var newOptions = this.options;
    newOptions.positionClass = 'toast-top-center';
    this.toastr.success(message, title, newOptions)
  }

  show(message: string, title?: string): void {
    this.toastr.show(message, title, this.options)
  }

  showError(message: string, title?: string): void {
    this.toastr.error(message, title, this.options)
  }

  showWarning(message: string, title?: string): void {
    this.toastr.warning(message, title, this.options)
  }

  showInfo(message: string, title?: string): void {
    this.toastr.info(message, title, this.options)
  }
}
