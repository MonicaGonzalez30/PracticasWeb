namespace ExamenB.Model
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public long NSSPaciente { get; set; }
        public int IdExpediente { get; set; }
        public int IdMedico { get; set; }
        public string FechaConsulta { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
    }
}
