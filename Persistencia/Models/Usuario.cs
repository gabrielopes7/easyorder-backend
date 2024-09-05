using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string SenhaHash { get; private set; }

        public Usuario(string Nome, string Email, DateTime DataNascimento, string SenhaHash)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.DataNascimento = DataNascimento;
            this.SenhaHash = SenhaHash;
        }
    }
}
