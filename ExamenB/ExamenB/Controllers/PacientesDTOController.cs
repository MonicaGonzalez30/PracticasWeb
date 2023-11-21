using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenB.Context;
using ExamenB.DTO;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PacientesDTOController : ControllerBase
    {
        [HttpGet]
        public JsonResult readPacientesDTO()
        {
            List<PacienteDTO> pacientesDTO = new List<PacienteDTO>();
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var auxP = sistemaContext.pacientes;
                foreach (var i in auxP)
                {
                    pacientesDTO.Add(new PacienteDTO { Nombre = i.Nombre, ApPaterno = i.ApPaterno, ApMaterno = i.ApMaterno, Sexo = i.Sexo, FechaNac = i.FechaNac });
                }
            }
            return new JsonResult(pacientesDTO);
        }
    }
}
