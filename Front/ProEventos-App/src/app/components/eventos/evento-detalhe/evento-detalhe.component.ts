import { Component, NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent {
  form!: FormGroup;
  constructor(private fb: FormBuilder) { }

  get f(): any {
    return this.form.controls;
  }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void {
    this.form  = this.fb.group({
        tema: ['', Validators.required],
        local: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        dataEvento: ['', Validators.required],
        qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
        telefone: ['', [Validators.required, Validators.email]],
        email: ['', Validators.required],
        imagemURL: ['', Validators.required]
    })
  }

  public resetForm(): void {
    this.form.reset();
  }
}
