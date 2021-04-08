using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using LibraryUtils;
using System.IO;
using Library1;
using Newtonsoft.Json;
using System.Linq;

//Este projeto está vinculado ao projeto Library1, então primeiro clicamos em dependência e fazemos o link em 
//Add project references
//Também definimos este projeto como o principal clicando em cima do projeto com o botão direito 
//Set as startup project

namespace LibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Individuos individuos = new Individuos();
            string pasta = ConfigurationManager.AppSettings["pasta"];
            string fileindividuos = pasta + "individuos1.txt";
            //caso o ficheiro não exista o bloco try-catch captura o erro
            try
            {
                string conteudo = Ficheiro.LerFicheiro(fileindividuos);
                if (!String.IsNullOrEmpty(conteudo))
                {
                    individuos.FromJson(conteudo);
                }
            }
            catch (Exception ex)
            {
                //informação de debug
                Debug.Print(ex.Message);
                //informação para o utilizador
                Console.WriteLine(ex.Message);
            }
            string xml = individuos.ToXML();
            string fileindividuos1 = pasta + "individuos1.xml";
            Ficheiro.EscreverFicheiro(fileindividuos1, xml);

            try
            {
                string conteudo = Ficheiro.LerFicheiro(fileindividuos1);
                if (!String.IsNullOrEmpty(conteudo))
                {
                    individuos.FromXML(conteudo);
                    Console.WriteLine(individuos.Items.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                //informação de debug
                Debug.Print(ex.Message);
                //informação para o utilizador
                Console.WriteLine(ex.Message);
            }



        }

        public static void TrataIndividuos()
        {
            //como estamos colocando em uma outra classe, e utilizando
            //uma interface não precisamos mais da linha abaixo, nós escondemos a complexidade
            //List<Individuo1> lst = new List<Individuo1>();
            Individuos individuos = new Individuos();
            string pasta = ConfigurationManager.AppSettings["pasta"]; // C:\Users\JEMA\OneDrive\Documentos\Nova pasta\\individuos.txt";
            string fileIndividuos = pasta + "individuo.txt";

            try
            {
                string conteudo = Ficheiro.LerFicheiro(fileIndividuos); //não precisa instanciar o ojeto Ficheiro porque o método é static
                if (!String.IsNullOrEmpty(conteudo))
                {
                    individuos.FromJson(conteudo);//como estamos colocando em uma outra classe, e utilizando
                    //uma interface não precisamos mais da linha abaixo, nós escondemos a complexidade
                    //lst = JsonConvert.DeserializeObject<List<Individuo1>>(conteudo);
                }
            }
            catch (Exception ex)
            {
                //informação no output do debug
                Debug.Print(ex.Message);
                //informação do utilizador
                Console.WriteLine(ex.Message);

            }

            Console.WriteLine("Seja bem vindo");
            Boolean continuar = false;
            int contador = 0;
            do
            {
                Individuo1 obj = Gravar();
                //como estamos colocando em uma outra classe, e utilizando
                //uma interface não precisamos mais da linha abaixo, nós escondemos a complexidade
                //lst.Add(obj);
                individuos.Items.Add(obj);//Items é uma lista
                //Console.WriteLine(obj.NomeCompleto());

                Console.WriteLine("Deseja introduzir outro individuo? 1 - sim, 0 - não");
                string op = Console.ReadLine();
                continuar = (op == "1");
                contador++;

            } while (continuar);

            Console.WriteLine("Foram introduzidos " + contador + " indivíduos");

            //como estamos colocando em uma outra classe, e utilizando
            //uma interface não precisamos mais da linha abaixo, nós escondemos a complexidade
            //string json = JsonConvert.SerializeObject(lst);
            string json = individuos.ToJson();
            
            //Console.WriteLine(json);

            try
            {
                if (Ficheiro.EscreverFicheiro(fileIndividuos, json))
                {
                    Console.WriteLine("O registro foi criado!");
                }
                else
                {
                    Console.WriteLine("O registro não foi criado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Militar objM = new Militar();
            //objM.CC = "123456789";
            //objM.nif = "9999999";
            //objM.nome = "Sergio";
            //objM.apelido = "Fontes";
            //objM.datanascimento = new DateTime(1976, 8, 25);
            //objM.CM = "342342";
            //objM.Patente = "Mancebo";
            //Console.WriteLine(objM.NomeCompleto());

            //Console.ReadLine();




            /* _______________________________________________________________________
             *                               AULA 16/03/2020       
             * _______________________________________________________________________                              
            Console.WriteLine("Hello World!");

            //instanciar uma classe
            //Individuo obj = new Individuo();
            //obj.Nome = "Myrella";
            //obj.Apelido = "Gomes";
            //obj.DataNascimento = new DateTime(1985, 01, 03);

            //a partir do momento que temos cosntrutores podemos instanciar desta maneira abaixo ao invés da anterior
            Individuo obj = new Individuo("Myrella", "Gomes", new DateTime(1985, 01, 03)); //passando argumento por valor
            Individuo obj1 = new Individuo(apelido: "Gomes", nome: "Myrella", dataNasc: new DateTime(1985, 01, 03));//passando agumento por nome do parametro

            obj.Empresa.Nome = "Rumos";
            obj.Empresa.Area = "Formação";

            obj.MyDebug();
            string tmp = obj.Imprimir();

            Console.WriteLine(tmp);
            Console.ReadLine();//coloca para a aplicação ficar a espera*/
        }

        public static void ConsulasLink()
        {

            // The Three Parts of a LINQ Query:
            // 1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

            /*
            //Outros exemplos
            //Filtragem
            var queryLondonCustomers = from cust in customers
                                       where cust.City == "London"
                                       select cust;
            //Ordenando
            var queryLondonCustomers3 = from cust in customers
                                        where cust.City == "London"
                                        orderby cust.Name ascending
                                        select cust;
            //Agrupamento
            // queryCustomersByCity is an IEnumerable<IGrouping<string, Customer>>
            var queryCustomersByCity =
                from cust in customers
                group cust by cust.City;

            // customerGroup is an IGrouping<string, Customer>
            foreach (var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (Customer customer in customerGroup)
                {
                    Console.WriteLine("    {0}", customer.Name);
                }
            }

            //Adição
            var innerJoinQuery = from cust in customers
                join dist in distributors on cust.City equals dist.City
                select new { CustomerName = cust.Name, DistributorName = dist.Name };
            */
        }

        public static Individuo1 Gravar()
        {
            Individuo1 obj = new Individuo1();

            Console.WriteLine("Indique o seu nome");
            obj.nome = Console.ReadLine();

            Console.WriteLine("Indique o seu apelido");
            obj.apelido = Console.ReadLine();

            Console.WriteLine("Indique o seu CC");
            obj.CC = Console.ReadLine();

            Console.WriteLine("Indique o seu nif");
            obj.nif = Console.ReadLine();

            Console.WriteLine("Indique o sua data de nascimento - yyyy-mm-dd");
            DateTime dn = new DateTime(1900, 1, 1);
            DateTime.TryParse(Console.ReadLine(), out dn);

            return obj;
        }
    }
}

//tools - nugget package manager - adicionar dependências ao projeto
//newtonsoft.jason

