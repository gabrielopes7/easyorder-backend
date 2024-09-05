using System;
using System.Text;
using System.Security.Cryptography;


namespace Persistencia.Service
{

    public class PasswordHash
    {
        private HashAlgorithm _algorithm;

        public PasswordHash(HashAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }


        public string CriptografarSenha(string senhaString)
        {
            byte[] encodedValue = Encoding.UTF8.GetBytes(senhaString);
            byte[] encryptedPassword = _algorithm.ComputeHash(encodedValue);

            StringBuilder sb = new StringBuilder();
            
            foreach(byte byteCarac in encryptedPassword)
            {
                sb.Append(byteCarac.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool VerificarSenha(string senhaDigitada, string senhCadastrada)
        {
            if(String.IsNullOrEmpty(senhaDigitada))
                throw new NullReferenceException();

            string senhaDigitadaHash = CriptografarSenha(senhaDigitada);

            return senhaDigitadaHash.Equals(senhCadastrada);
        }
    }
}
