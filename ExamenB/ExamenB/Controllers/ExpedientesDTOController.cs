using ExamenB.Context;
using ExamenB.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpedientesDTOController : ControllerBase
    {
        [HttpGet]
        public JsonResult readExpedientesDTO()
        {
            List<ExpedienteDTO> expedientesDTO = new List<ExpedienteDTO>();
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var auxP = sistemaContext.expedientes;
                foreach (var i in auxP)
                {
                    expedientesDTO.Add(new ExpedienteDTO { IdExpediente = i.IdExpediente, FechaApertura = i.FechaApertura, Antecedentes = i.Antecedentes, Estudios = i.Estudios });
                }
            }
            return new JsonResult(expedientesDTO);
        }
    }
}
