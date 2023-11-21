using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenB.Context;
using ExamenB.Model;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        [HttpPost]
        public JsonResult createConsulta([FromBody] Consulta args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())  //Conectar con la BD virtual
            {
                sistemaContext.consultas.Add(args);
                sistemaContext.SaveChanges();
                resp = true;
            }
            return new JsonResult(resp);
        }

        [HttpGet]
        public JsonResult readConsultas()
        {
            List<Consulta> consultas = new List<Consulta>();
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var auxC = sistemaContext.consultas;
                foreach (var i in auxC)
                {
                    consultas.Add(new Consulta { IdConsulta = i.IdConsulta, NSSPaciente = i.NSSPaciente, IdExpediente = i.IdExpediente, IdMedico = i.IdMedico, FechaConsulta= i.FechaConsulta, Sintomas = i.Sintomas, Diagnostico = i.Diagnostico, Tratamiento = i.Tratamiento });
                }
            }
            return new JsonResult(consultas);
        }

        [HttpPatch]
        public JsonResult updateConsulta([FromBody] Consulta args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var existConsulta = sistemaContext.consultas.SingleOrDefault(e => e.IdConsulta == args.IdConsulta);
                if (existConsulta != null)
                {
                    sistemaContext.consultas.Attach(args); //Hacer update
                    sistemaContext.Entry(args).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar estado
                    sistemaContext.SaveChanges();
                    resp = true;
                }
            }
            return new JsonResult(resp);
        }
    }
}
