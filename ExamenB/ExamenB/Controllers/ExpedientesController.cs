using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenB.Context;
using ExamenB.Model;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpedientesController : ControllerBase
    {
        [HttpPost]
        public JsonResult createExpediente([FromBody] Expediente args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())  //Conectar con la BD virtual
            {
                sistemaContext.expedientes.Add(args);
                sistemaContext.SaveChanges();
                resp = true;
            }
            return new JsonResult(resp);
        }

        [HttpGet]
        public JsonResult readExpedientes()
        {
            List<Expediente> expedientes = new List<Expediente>();
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var auxE = sistemaContext.expedientes;
                foreach (var i in auxE)
                {
                    expedientes.Add(new Expediente { IdExpediente = i.IdExpediente, NSSPaciente = i.NSSPaciente, FechaApertura = i.FechaApertura, Antecedentes = i.Antecedentes, Estudios = i.Estudios });
                }
            }
            return new JsonResult(expedientes);
        }

        [HttpPatch]
        public JsonResult updateExpediente([FromBody] Expediente args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var existExpediente = sistemaContext.expedientes.SingleOrDefault(e => e.IdExpediente == args.IdExpediente);
                if (existExpediente != null)
                {
                    sistemaContext.expedientes.Attach(args); //Hacer update
                    sistemaContext.Entry(args).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar estado
                    sistemaContext.SaveChanges();
                    resp = true;
                }
            }
            return new JsonResult(resp);
        }

        [HttpDelete]
        public JsonResult deleteExpediente([FromBody] Expediente args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var existExpediente = sistemaContext.expedientes.SingleOrDefault(e => e.IdExpediente == args.IdExpediente);
                if (existExpediente != null)
                {
                    sistemaContext.expedientes.Remove(existExpediente); //Hacer delete
                    sistemaContext.SaveChanges();
                    resp = true;
                }
            }
            return new JsonResult(resp);
        }
    }
}
