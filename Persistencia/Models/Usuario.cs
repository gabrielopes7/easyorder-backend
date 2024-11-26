using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get;  set; }
        public required DateTime DataNascimento { get; set; }
        public required string Senha { get; set; }
    }
}
