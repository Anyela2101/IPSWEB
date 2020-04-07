using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IPS.Models;
using static IPS.Models.PacienteModel;

namespace IPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteservice;
        public IConfiguration Configuration {get;}

        public PacienteController(IConfiguration configuration){
            Configuration=configuration;
            string ConnectionStrings = Configuration["ConnectionStrings:DefaultConnection"];
            _pacienteservice =new PacienteService(ConnectionStrings);
        }

        [HttpPost]
        public ActionResult<PacienteViewModel> Post(PacienteInputModel pacienteInput){
            Paciente paciente = Mapear(pacienteInput);
            var response = _pacienteservice.Guardar(paciente);
            if(response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Paciente);
        }

        private Paciente Mapear(PacienteInputModel pacienteInput){
            var paciente=new Paciente{
                identificacion=pacienteInput.identificacion,
                nombres = pacienteInput.nombres,
                valorservicio =pacienteInput.valorservicio,
                salariotrabajador=pacienteInput.salariotrabajador
            };
            return paciente;
        }

        [HttpGet]
        public IEnumerable <PacienteViewModel> Gets(){
            var personas = _pacienteservice.ConsultarTodos().Select(p=>new PacienteViewModel(p));
            return personas;
        }
    }

    
}