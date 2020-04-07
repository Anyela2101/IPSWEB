import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PacienteRegistroComponent} from './copago/paciente-registro/paciente-registro.component';
import {PacienteConsultaComponent} from './copago/paciente-consulta/paciente-consulta.component';
import {Routes, RouterModule} from '@angular/router';

const routes: Routes=[
  {
    path: 'pacienteConsulta',
    component: PacienteConsultaComponent
  },
  {
    path: 'pacienteRegistro',
    component: PacienteRegistroComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
