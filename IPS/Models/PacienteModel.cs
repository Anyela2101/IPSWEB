using Entity;

namespace IPS.Models
{
    public class PacienteModel
    {
        public class PacienteInputModel{
            public string identificacion {get;set;}
            public string nombres {get;set;}
            public decimal valorservicio {get;set;}
            public decimal salariotrabajador {get;set;}

        }

        public class PacienteViewModel: PacienteInputModel{
            public PacienteViewModel(){

            }

            public PacienteViewModel(Paciente paciente){
                identificacion =paciente.identificacion;
                nombres=paciente.nombres;
                valorservicio=paciente.valorservicio;
                salariotrabajador=paciente.salariotrabajador;
                Copago =paciente.Copago;
                porcentaje = paciente.porcentaje;
            }

            public decimal Copago {get;set;}
            public string porcentaje {get;set;}
        }
    }
}