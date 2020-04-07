using System;

namespace Entity
{
    public class Paciente
    {
         public string identificacion {get;set;}
        public string nombres {get;set;}
        public decimal valorservicio {get;set;}
        public decimal salariotrabajador {get;set;}

        public string porcentaje {get;set;}

        public decimal Copago{
            get{
                decimal valor, porcentaje=0.2m;
                if(salariotrabajador>2500000){
                    valor=this.valorservicio*porcentaje;
                    this.porcentaje="20";
                }else{
                    valor=this.valorservicio*porcentaje;
                    this.porcentaje="10";
                }

                return valor;
            }
        }
    }
}
