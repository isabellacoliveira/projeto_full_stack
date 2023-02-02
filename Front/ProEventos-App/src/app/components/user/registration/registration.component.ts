import { ValidatorField } from './../../../helpers/ValidatorField';
import { FormGroup, FormBuilder, Validators, AbstractControlOptions } from '@angular/forms';
import { Component } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  form!: FormGroup;
  constructor(private fb: FormBuilder) { }

  get f(): any { return this.form.controls; }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void {
    // atribuimos um validator novo ao nosso grupo
    const formOptions: AbstractControlOptions = {
      // passa na validação dois campos que ja possuimos
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group({
      primeiroNome: ['', [Validators.required]],
      ultimoNome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmeSenha: ['', [Validators.required]]
    }, formOptions);
  }

}
