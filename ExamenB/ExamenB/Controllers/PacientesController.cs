using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenB.Context;
using ExamenB.Model;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        [HttpPost]
        public JsonResult createPaciente([FromBody] Paciente args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())  //Conectar con la BD virtual
            {
                sistemaContext.pacientes.Add(args);
                sistemaContext.SaveChanges();
                resp = true;
            }
            return new JsonResult(resp);
        }

        [HttpGet]
        public JsonResult readPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var auxP = sistemaContext.pacientes;
                foreach (var i in auxP)
                {
                    pacientes.Add(new Paciente { NSS = i.NSS, Nombre = i.Nombre, ApPaterno = i.ApPaterno, ApMaterno = i.ApMaterno, Sexo = i.Sexo, FechaNac = i.FechaNac, Domicilio = i.Domicilio, Telefono = i.Telefono, Contrasena = i.Contrasena });
                }
            }
            return new JsonResult(pacientes);
        }

        [HttpPatch]
        public JsonResult updatePaciente([FromBody] Paciente args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var existPaciente = sistemaContext.pacientes.SingleOrDefault(p => p.NSS == args.NSS);
                if (existPaciente != null)
                {
                    sistemaContext.pacientes.Attach(args); //Hacer update
                    sistemaContext.Entry(args).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar estado
                    sistemaContext.SaveChanges();
                    resp = true;
                }
            }
            return new JsonResult(resp);
        }

        [HttpDelete]
        public JsonResult deletePaciente([FromBody] Paciente args)
        {
            bool resp = false;
            using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
            {
                var existPaciente = sistemaContext.pacientes.SingleOrDefault(p => p.NSS == args.NSS);
                if (existPaciente != null)
                {
                    sistemaContext.pacientes.Remove(existPaciente); //Hacer delete
                    sistemaContext.SaveChanges();
                    resp = true;
                }
            }
            return new JsonResult(resp);
        }
    }
}
