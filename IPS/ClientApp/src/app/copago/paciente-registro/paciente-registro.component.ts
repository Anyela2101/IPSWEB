import { Component, OnInit } from '@angular/core';
import { Paciente } from '../models/paciente';
import { PacienteService } from '../../services/paciente.service';

@Component({
  selector: 'app-paciente-registro',
  templateUrl: './paciente-registro.component.html',
  styleUrls: ['./paciente-registro.component.css']
})
export class PacienteRegistroComponent implements OnInit {
    
  paciente: Paciente;
  constructor(private pacienteService: PacienteService) { }

  ngOnInit() {
    this.paciente = new Paciente();
  }
   add(){
     this.pacienteService.post(this.paciente).subscribe(p=>{
       if(p!=null){
         alert('Paciente Creado!');
         this.paciente=p;
       }
     });
   }
}
