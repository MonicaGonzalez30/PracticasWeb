using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamenB.Model;
using ExamenB.Context;

namespace ExamenB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public bool login([FromBody] Paciente paciente)
        {
            bool resp = false;
            if (paciente != null)
            {
                using (SistemaMedicoContext sistemaContext = new SistemaMedicoContext())
                {
                    var existPaciente = sistemaContext.pacientes.SingleOrDefault(p => p.NSS == paciente.NSS && p.Contrasena == paciente.Contrasena);
                    if (existPaciente != null)
                    {
                        //if (paciente.NSS == 12345678910 && paciente.Contrasena == "password123")
                        resp = true;
                    }
                }
            }
            return resp;
        }
    }
}
