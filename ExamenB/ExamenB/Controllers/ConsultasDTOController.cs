using ExamenB.Context;
using ExamenB.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultasDTOController : ControllerBase
    {
        [HttpGet]
        public JsonResult readConsultasDTO()
        {
            List<ConsultaDTO> consultasDTO = new List<ConsultaDTO>();
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var auxC = sistemaContext.consultas;
                foreach (var i in auxC)
                {
                    consultasDTO.Add(new ConsultaDTO { IdConsulta = i.IdConsulta, IdMedico = i.IdMedico, FechaConsulta = i.FechaConsulta, Sintomas = i.Sintomas, Diagnostico = i.Diagnostico, Tratamiento = i.Tratamiento });
                }
            }
            return new JsonResult(consultasDTO);
        }
    }
}
