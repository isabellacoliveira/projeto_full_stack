import { Evento } from './../models/Evento';
import { EventoService } from './../services/Evento.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public showImage: boolean = true;
  public eventosFiltrados: Evento[] = [];
  public _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      // evento:
      (evento: {tema: String; local: String;}) => evento.tema
                  .toLocaleLowerCase()
                  .indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  public showOrHideImage(): void {
    this.showImage = !this.showImage;
  }

  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos()
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe(
      (_eventos: Evento[])  => {
        this.eventos = _eventos,
        this.eventosFiltrados = this.eventos
      } ,
      error => console.log(error)
    );
  }
}
