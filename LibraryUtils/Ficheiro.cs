using System;
using System.Diagnostics;
using System.IO;

namespace LibraryUtils
{
    public abstract class Ficheiro//abstract coloca para o programa avisar que não precisa instanciar os objetos
    {
        //static: é um método que eu não preciso instanciar a minha classe para utilizar meu método
        public static string LerFicheiro(string caminho)
        {
            try
            {
                StreamReader sr = new StreamReader(caminho);
                string conteudo = sr.ReadToEnd();
                sr.Close();

                return conteudo;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw new FileNotFoundException(string.Format("Ficheiro {0} não existe.", caminho), ex);
            }
        }

        public static bool EscreverFicheiro(string caminho, string conteudo)
        {
            try
            {
                TextWriter txt = new StreamWriter(caminho);
                txt.WriteLine(conteudo);
                txt.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Não foi possível escrever no Ficheiro {0}", caminho), ex);
            }
        }
    }
}
