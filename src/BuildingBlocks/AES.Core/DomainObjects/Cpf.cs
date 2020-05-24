namespace AES.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLenght = 11;
        public string Number { get; private set; }

        // CTOR ofr entity
        public Cpf() { }

        public Cpf(string number)
        {
            Number = number;
        }
    }
}
