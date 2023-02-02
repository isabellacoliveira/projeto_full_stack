import { AbstractControl, FormGroup } from '@angular/forms';

export class ValidatorField {
  // precisa realizar o match
  static MustMatch(controlName: string, matchingControlName: string): any {
    // dado um controle de abstração, temos um form group
    // esse método receberá uma senha e o confirmaSenha
    return (group: AbstractControl) => {
      // controle abstrato
      const formGroup = group as FormGroup;
      // esse será um controle de abstração
      const control = formGroup.controls[controlName];
      const matchingControl =  formGroup.controls[matchingControlName];

      // se ele não tiver nenhum erro e não for mustMatch
      // if(matchingControl.errors && !matchingControl.errors.mustMatch){
      //   return null;
      // }
      if(matchingControl.errors && !matchingControl.errors['mustMatch']){
        return null;
      }

      if(control.value !== matchingControl.value){
        // se os dois forem diferentes
        // vamos criar um campo novo nos erros dele
        matchingControl.setErrors({mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }

      return null;
    }
  }
}
