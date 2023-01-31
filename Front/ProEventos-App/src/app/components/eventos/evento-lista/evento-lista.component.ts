import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { EventoService } from './../../../services/Evento.service';
import { Evento } from './../../../models/Evento';
import { Component, OnInit, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {
  public eventos: Evento[] = [];
  public widthImg = 150;
  public marginImg = 2;
  public showImage = true;
  public eventosFiltrados: Evento[] = [];
  public filtroListado: string = '';

  modalRef?: BsModalRef;
  message?: string;


  constructor(private eventoService: EventoService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router) { }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.message = 'Confirmed!';
    this.modalRef?.hide();
    this.toastr.success('O evento foi deletado com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef?.hide();
  }

  public get filtroLista(): string{
    return this.filtroListado;
  }

  public set filtroLista(value: string){
    this.filtroListado = value;
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
    );
  }

  public showOrHideImage(): void {
    this.showImage = !this.showImage;
  }


  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public getEventos(): void {
    const observer = {
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error: (error: any) => {
        this.spinner.hide(),
        this.toastr.error('Erro ao carregar os eventos', 'Deletado!')
      },
      complete: () => this.spinner.hide()
    }
    this.eventoService.getEventos().subscribe(observer);
  }

  detailsRoute(): void {
    this.router.navigate(['/eventos/detalhe']);
  }

  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
