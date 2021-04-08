using System;
using System.Collections.Generic;
using System.Text;

namespace CmdPoly

{
    //aqui só definimos as assinaturas dos métodos, obrigando assim as catarcterísticas básicas 
    //da interface, não impelmentamos os métodos

    //A Interface é muito importante para garantir que classes implementem determinados métodos
    interface IAnimal
    {
        void som();
        void andar();
        void dormem();
    }
}
