import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { Paciente } from '../copago/models/paciente';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseurl:string,
    private handleErrorService:HandleHttpErrorService) 
    {
      this.baseUrl= baseurl;
     }

     get(): Observable<Paciente[]> {
       return this.http.get<Paciente[]>(this.baseUrl + 'api/persona')
       .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Paciente[]>('Consultar Paciente', null))
       );
     }

     post(paciente:Paciente): Observable<Paciente>{
       return this.http.post<Paciente>(this.baseUrl + 'api/Paciente', paciente)
       .pipe(
         tap(_ => this.handleErrorService.log('datos enviados')),
         catchError(this.handleErrorService.handleError<Paciente>('Registrar Paciente', null))
       );
     }
}
