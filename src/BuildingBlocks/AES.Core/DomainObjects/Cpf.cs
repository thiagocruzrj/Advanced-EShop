using AES.Core.Tools;
using System.Text.RegularExpressions;

namespace AES.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLenght = 11;
        public string Number { get; private set; }

        // CTOR for entity
        public Cpf() { }

        public Cpf(string number)
        {
            if (!Validate(number)) throw new DomainException("Invalid CPF");
            Number = number;
        }

        public static bool Validate(string cpf)
        {
            cpf = cpf.OnlyNumbers(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }

    public class Email
    {
        public const int AddressMaxLength = 254;
        public const int AddressMinLength = 5;
        public string Address { get; private set; }

        // CTOR of EF
        protected Email() { }

        public Email(string address)
        {
            if (!Validate(address)) throw new DomainException("Invalid Email");
            Address = address;
        }

        public static bool Validate(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
