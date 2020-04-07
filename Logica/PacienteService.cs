using System;
using Entity;
using Datos;
using System.Collections.Generic;
namespace Logica
{
    public class PacienteService
    {
        private readonly connectionManager _conexion;
        private readonly PacienteRepository _repositorio;

        public PacienteService(string Connectionstrings){
            _conexion = new connectionManager(Connectionstrings);
            _repositorio = new PacienteRepository(_conexion);
        }

        public GuardarPacienteResponse Guardar(Paciente paciente){
            try{
                _conexion.open();
                _repositorio.Guardar(paciente);
                _conexion.close();
                return new GuardarPacienteResponse(paciente);
            }catch(Exception e){
                return new GuardarPacienteResponse($"Error de la aplicacion: {e.Message}");
            }finally{
                _conexion.close();
            }
        }

        public class GuardarPacienteResponse{
            public GuardarPacienteResponse(Paciente paciente){
                Error = false;
                Paciente = paciente;
            }

            public GuardarPacienteResponse(string mensaje){
                Error=true;
                Mensaje= mensaje; 
            }

            public bool Error {get;set;}
            public string Mensaje {get;set;}
            public Paciente Paciente {get;set;}
        }

        public List<Paciente>ConsultarTodos(){
            _conexion.open();
            List<Paciente> pacientes =_repositorio.ConsultarTodos();
            _conexion.close();
            return pacientes;
        }
    }
}
