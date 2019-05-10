import { AbstractControl } from '@angular/forms';

export class PasswordValidation {
    static MatchPassword(AC: AbstractControl) {
        let password = AC.get('password').value; // to get value in input tag
        let confirmPassword = AC.get('passwordConfirm').value; // to get value in input tag
        if (password != confirmPassword) {
            AC.get('passwordConfirm').setErrors({ MatchPassword: true })
        } else {
            return null;
        }
    }

    static MatchChangePassword(AC: AbstractControl) {
        let password = AC.get('newPassword').value; // to get value in input tag
        let confirmPassword = AC.get('confirmNewPassword').value; // to get value in input tag
        if (password != confirmPassword) {
            AC.get('confirmNewPassword').setErrors({ MatchPassword: true })
        } else {
            return null;
        }
    }
}