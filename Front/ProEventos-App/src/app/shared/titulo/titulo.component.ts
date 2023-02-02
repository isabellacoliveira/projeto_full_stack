import { Router } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css']
})
export class TituloComponent implements OnInit {
  @Input() titulo: string = '';
  @Input() iconClass = 'fa fa-user';
  @Input() subtitulo = 'Desde 2021';
  @Input() botaoListar = false;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  list(): void {
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`]);
  }
}
