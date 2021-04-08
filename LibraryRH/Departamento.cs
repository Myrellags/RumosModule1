using System;

namespace LibraryRH
{
    public enum TipoDepartamento
    {
        Interno,
        Externo
    }

    public class Departamento
    {
        private string _codigo;
        private string _nome;
        private TipoDepartamento _tipo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public TipoDepartamento Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}
