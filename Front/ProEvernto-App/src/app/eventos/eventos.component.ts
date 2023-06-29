import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {
  public eventos: any = [] ;
  widthImg: number =200;
  marginImg: number = 2;
  showImg: boolean = true;
  private _filtrolista: string = '';

  public get filtrolista(){
    return this._filtrolista;

  }

  public set filtrolista(value: string){
    this._filtrolista =value;
    this.eventos = this.filtrolista ? this.filtrarEventos(this.filtrolista) : this.eventos ;
  }

  filtrarEventos (filtrarPor : string) : any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (      evento: { tema: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor)!== -1
    )
  }




  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();

  }

  alterarImagem() {
    this.showImg = !this.showImg;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
     response =>this.eventos = response,
     error => console.log(error)
   )

    }




}
