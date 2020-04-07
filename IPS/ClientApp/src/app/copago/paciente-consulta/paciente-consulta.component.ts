import { Component, OnInit } from '@angular/core';
import { Paciente } from '../models/paciente';
import {PacienteService} from '../../services/paciente.service';

@Component({
  selector: 'app-paciente-consulta',
  templateUrl: './paciente-consulta.component.html',
  styleUrls: ['./paciente-consulta.component.css']
})
export class PacienteConsultaComponent implements OnInit {

  pacientes:Paciente[];
  constructor(private pacienteService: PacienteService) { }

  ngOnInit() {

    this.get();
  }
     get(){
       this.pacienteService.get().subscribe(result=>{
         this.pacientes=result;
       });
     }
}
