using System;

namespace CmdPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Animal
    {
        public virtual void Som()
        {
            Console.WriteLine("Exemplo Polimorfismo!");
            Animal objAnimal = new Animal();
            Animal objGato = new Gato();
            Animal objCao = new Cao();

            objAnimal.Som();
            objGato.Som();
            objCao.Som();

            Cao objCao1 = new Cao();
            objCao1.Som();
        }
    }

    class Gato : Animal
    {
        public override void Som()//Virtual diz que pode herdar
        {
            Console.WriteLine("Gato mia!");
        }
    }

    class Cao : Animal
    {
        public override void Som()// Override Diz que está utilizando
        {
            Console.WriteLine("O cão ladra!");
        }
    }

    class Periquito : Animal
    {
        public override void Som()//Diz que está utilizando
        {
            Console.WriteLine("O cão ladra!");
        }
    }

    class Girafa : IAnimal
    {
        public void andar()
        {
            throw new NotImplementedException();
        }

        public void dormem()
        {
            throw new NotImplementedException();
        }

        public void som()
        {
            throw new NotImplementedException();
        }
    }
}//não podemos instanciar uma interface
