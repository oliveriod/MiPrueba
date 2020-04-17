using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrueba.API.Domain.Models
{
    public class ParámetrosParaAutenticar
    {
        public string MiLlaveParaLogin { get; set; }
        public string MiEditor { get; set; }
        public string MiAudiencia { get; set; }
        public string MiAutoridad { get; set; }
        public int MiTiempoParaExpirar { get; set; }
    }
}
