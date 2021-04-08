using LibraryRH;
using LibraryUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AppRH
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo!");
            int x = 0;
            while(x!=9)
            {
                Console.WriteLine("Escolha uma opção!");   
                switch (x)
                {
                    case 1:
                        Console.WriteLine("10-Inserir Funcionario");
                        Console.WriteLine("11-Editar Funcionario");
                        Console.WriteLine("12-Eliminar Funcionario");
                        Console.WriteLine("13-Listar Funcionarios");
                        Console.WriteLine("14-Pesquisar");
                        break;
                    case 2:
                        Console.WriteLine("20-Inserir Departmento");
                        Console.WriteLine("21-Editar Departmento");
                        Console.WriteLine("22-Eliminar Departmento");
                        Console.WriteLine("23-Listar Departmento");
                        Console.WriteLine("24-Pesquisar");
                        break;
                    case 3:
                        Console.WriteLine("30-Inserir Férias");
                        Console.WriteLine("31-Editar Férias");
                        Console.WriteLine("32-Eliminar Férias");
                        Console.WriteLine("33-Listar Férias");
                        break;
                    default:
                        Console.WriteLine("1-Gerir Funcionarios");
                        Console.WriteLine("2-Gerir Departamentos");
                        Console.WriteLine("3-Gerir Férias, Ausências");
                        break;
                }
                Console.WriteLine("9- Exit!");

                string input = Console.ReadLine();
                if(!int.TryParse(input, out x))
                {
                    Console.WriteLine("Não foi possível entender.");
                }
                else
                {
                    Console.WriteLine(string.Format("Você escolheu: {0}", input));
                }

                if (x == 10)
                {
                    Formulario_Funcionario();
                }
                else if (x == 11)
                {
                    Editar_Funcionario();
                }
                else if (x == 12)
                {

                }
                else if (x == 13)
                {

                }
                else if (x == 14)
                {

                }
                else if(x==20)
                {
                    Formulario_Departamento();
                }
                else if(x==21)
                {
                    Editar_Departamento();
                }
                else if (x == 22)
                {
                    Eliminar_Departamento();
                }
                else if (x == 23)
                {
                    Listar_Departamento();
                }
                else if (x == 24)
                {
                    Pesquisar_Departamento();
                }
                else if (x == 30)
                {

                }
                else if (x == 31)
                {

                }
                else if (x == 32)
                {

                }
                else if (x == 33)
                {

                }
            }
            
        }
        public static Departamentos GetDepartamentos()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "departamentos.json";
            string dados = "";
            Departamentos dpts = new Departamentos();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                dpts.FromJson(dados);
            }
            catch
            {

            }
            return dpts;
        }
        public static Funcionarios GetFuncionarios()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "funcionarios.json";
            string dados = "";
            Funcionarios dpts = new Funcionarios();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                dpts.FromJson(dados);
            }
            catch
            {

            }
            return dpts;
        }
        private static void Formulario_Funcionario()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "funcionarios.json";
            string dados = "";
            Funcionarios fncs = new Funcionarios();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                fncs.FromJson(dados);
            }
            catch
            {

            }
            //instanciar o objecto
            Funcionario fnc = new Funcionario();
            //perguntar o codigo
            fnc.codigo = Valida_Input("Indique o codigo");
            if (string.IsNullOrEmpty(fnc.codigo))
            {
                return;
            }
            //perguntar o nome
            fnc.nome = Valida_Input("Indique o nome");
            if (string.IsNullOrEmpty(fnc.nome))
            {
                return;
            }
            //perguntar o data nascimento
            string NovoData = Valida_Input("Indique a data de nascimento");
            if (string.IsNullOrEmpty(NovoData))
            {
                return;
            }
            fnc.dataNascimento = DateTime.Parse(NovoData); 
            foreach (Departamento d in GetDepartamentos().Items)
            {
                string frase = "{0} - {1}";
                Console.WriteLine(string.Format(frase, d.Codigo, d.Nome));
            }
            string dep = Valida_Input("Indique o departamento:");
            if (string.IsNullOrEmpty(dep))
            {
                return;
            }
            fnc.departamento = GetDepartamentos().FindByCodigo(dep);
            fncs.Items.Add(fnc);
            Ficheiro.EscreverFicheiro(caminho, fncs.ToJson());
        }

        public static void Editar_Funcionario()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "funcionarios.json";
            foreach (Funcionario f in GetFuncionarios().Items)
            {
                string frase = "{0} - {1}";
                Console.WriteLine(string.Format(frase, f.codigo, f.nome));
            }
            string codigo = Valida_Input("Indique o código do funcionário:");
            if (string.IsNullOrEmpty(codigo))
            {
                return;
            }
            // determinar indice do departamento
            var index = GetDepartamentos().Items.FindIndex(d => d.Codigo.Equals(codigo));
            Funcionarios funcs = GetFuncionarios();
            //perguntar o novo codigo
            string NovoCodigo = Valida_Input("Indique o novo codigo");
            if (string.IsNullOrEmpty(NovoCodigo))
            {
                return;
            }
            //recendo o novo código
            funcs.Items[index].codigo = NovoCodigo;
            //perguntar o novo nome
            string NovoNome = Valida_Input("Indique o novo nome");
            if (string.IsNullOrEmpty(NovoNome))
            {
                return;
            }
            funcs.Items[index].nome = NovoNome;
            //perguntar nova data nascimento
            string NovoData = Valida_Input("Indique a nova data de nascimento");
            if (string.IsNullOrEmpty(NovoData))
            {
                return;
            }
            funcs.Items[index].dataNascimento = DateTime.Parse(NovoData);
            Ficheiro.EscreverFicheiro(caminho, funcs.ToJson());
        }

        private static void Formulario_Departamento()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "departamentos.json";
            string dados = "";
            Departamentos dpts = new Departamentos();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                dpts.FromJson(dados);
            }
            catch
            {

            }
            //instanciar o objecto
            Departamento dpt = new Departamento();
            //perguntar o codigo
            dpt.Codigo = Valida_Input("Indique o codigo");
            if (string.IsNullOrEmpty(dpt.Codigo))
            {
                return;
            }
            //perguntar o nome
            dpt.Nome = Valida_Input("Indique o nome");
            if (string.IsNullOrEmpty(dpt.Nome))
            {
                return;
            }
            //perguntar tipo
            string tipo = Valida_Input("Indique o tipo (0 - Interno, 1 - Externo");
            if (string.IsNullOrEmpty(tipo))
            {
                return;
            }
            dpt.Tipo = (TipoDepartamento)int.Parse(tipo);
            dpts.Items.Add(dpt);
            Ficheiro.EscreverFicheiro(caminho, dpts.ToJson());
        }

        public static void Editar_Departamento()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "departamentos.json";
            foreach (Departamento d in GetDepartamentos().Items)
            {
                string frase = "{0} - {1}";
                Console.WriteLine(string.Format(frase, d.Codigo, d.Nome));
            }
            string codigo = Valida_Input("Indique o departamento:");
            if (string.IsNullOrEmpty(codigo))
            {
                return;
            }
            // determinar indice do departamento
            var index = GetDepartamentos().Items.FindIndex(d => d.Codigo.Equals(codigo));
            Departamentos dpts = GetDepartamentos();
            //perguntar o novo codigo
            string NovoCodigo = Valida_Input("Indique o novo codigo");
            if (string.IsNullOrEmpty(NovoCodigo))
            {
                return;
            }
            //recendo o novo código
            dpts.Items[index].Codigo = NovoCodigo;
            //perguntar o novo nome
            string NovoNome = Valida_Input("Indique o novo nome");
            if (string.IsNullOrEmpty(NovoNome))
            {
                return;
            }
            dpts.Items[index].Nome = NovoNome;

            //perguntar novo tipo
            string Novotipo = Valida_Input("Indique o novo tipo (0 - Interno, 1 - Externo");
            if (string.IsNullOrEmpty(Novotipo))
            {
                return;
            }
            dpts.Items[index].Tipo = (TipoDepartamento)int.Parse(Novotipo);
            Ficheiro.EscreverFicheiro(caminho, dpts.ToJson());
        }

        public static void Eliminar_Departamento()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "departamentos.json";
            string dados = "";
            Departamentos depart = new Departamentos();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                depart.FromJson(dados);
            }
            catch
            {

            }
            string codigo = Valida_Input("Indique o código do departamento a ser eliminado:");
            if (string.IsNullOrEmpty(codigo))
            {
                return;
            }
            // determinar indice do departamento
            var index = GetDepartamentos().Items.FindIndex(d => d.Codigo.Equals(codigo));
            Departamentos dpts = GetDepartamentos();
            //delete 
            dpts.Items.RemoveAt(index);
            Ficheiro.EscreverFicheiro(caminho, dpts.ToJson());
        }

        public static void Listar_Departamento()
        {
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "departamentos.json";
            string dados = "";
            Departamentos dpts = new Departamentos();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                dpts.FromJson(dados);

                //Query sintax
                var resultado = from d in dpts.Items select d;
                foreach (var r in resultado)
                {
                    Console.WriteLine(r.Nome);
                }
            }
            catch
            {

            }
        }

        public static void Pesquisar_Departamento() 
        {
            Console.WriteLine("Indique o nome");
            string pesquisa = Console.ReadLine();

            string pasta = ConfigurationManager.AppSettings["pasta"];
            string caminho = pasta + "departamentos.json";
            string dados = "";
            Departamentos dpts = new Departamentos();
            try
            {
                dados = Ficheiro.LerFicheiro(caminho);
                dpts.FromJson(dados);

                //Query sintax
                // nome exacto
                var resultado = from d in dpts.Items where d.Nome == pesquisa select d;
                foreach (var r in resultado)
                {
                    Console.WriteLine(r.Nome);
                }

                // like nome
                var resultado1 = from d in dpts.Items where d.Nome.Contains(pesquisa) select d;
                //method syntax
                var resultado2 = dpts.Items.Where(d => d.Nome.Contains(pesquisa)).Select(d => d.Codigo);

                var resultado3 = dpts.Items.Where(d => d.Nome.Contains(pesquisa)).Select(d => new { Name = d.Nome, Code = d.Codigo }).ToList();

                foreach (var r in resultado3)
                {
                    Console.WriteLine(r.Code);
                }
                //contagem de departamentos por tipo de departamento
                var resultado4 = dpts.Items.GroupBy(d => d.Tipo).Select(d => new { tipo = d.Key, Contagem = d.Count() });

            }
            catch
            {

            }
        }

        private static string Valida_Input(string pergunta)
        {
            string input = "";
            Boolean bolCodigoOk = false;
            int contador = 0;
            while (!bolCodigoOk)
            {
                if (contador == 3)
                {
                    return "";
                }
                contador++;
                Console.WriteLine(pergunta);
                input = Console.ReadLine();
                if (input.Length > 0)
                {
                    bolCodigoOk = true;
                }
            }
            return input;
        }
    }
}
