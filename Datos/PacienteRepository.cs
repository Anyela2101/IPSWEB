using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
using System;

namespace Datos
{
    public class PacienteRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Paciente> pacientes = new List<Paciente>();
        public PacienteRepository(connectionManager connection){
            _connection = connection._conexion;
        }

        public void Guardar(Paciente paciente){
            using (var command = _connection.CreateCommand()){
                command.CommandText = @"Insert Into Copagopaciente (identificacion,nombres,valorservicio,salariotrabajador,Copago,porcentaje)
                                       values (@Identificacion,@Nombres,@Valorservicio,@Salariotrabajador,@Copago,@Porcentaje)";
                 command.Parameters.AddWithValue("@identificacion", paciente.identificacion);
                 command.Parameters.AddWithValue("@Nombres", paciente.nombres);
                 command.Parameters.AddWithValue("@Valorservicio", paciente.valorservicio);
                 command.Parameters.AddWithValue("@Salariotrabajador", paciente.salariotrabajador);
                 command.Parameters.AddWithValue("@Copago", paciente.Copago);
                 command.Parameters.AddWithValue("@Porcentaje", paciente.porcentaje);
                 var filas = command.ExecuteNonQuery();
            }
        }

        public List<Paciente> ConsultarTodos(){
            SqlDataReader dataReader;
            List<Paciente> pacientes = new List<Paciente>();
            using ( var command = _connection.CreateCommand()){
                command.CommandText ="select *from Copagopaciente";
                dataReader = command.ExecuteReader();
                if(dataReader.HasRows){
                    while(dataReader.Read()){
                        Paciente paciente = DatareaderMap(dataReader);
                        pacientes.Add(paciente);
                    }
                }
            }
            return pacientes;

        }

        private Paciente DatareaderMap(SqlDataReader dataReader){
            if(!dataReader.HasRows) return null;
            Paciente paciente = new Paciente();
            paciente.identificacion = (string)dataReader["identificacion"];
            paciente.nombres=(string)dataReader["nombres"];
            paciente.valorservicio=(decimal)dataReader["valorservicio"];
            paciente.salariotrabajador=(decimal)dataReader["salariotrabajador"];
            decimal valorcopago = paciente.Copago;
            return paciente;
        }
    }
}