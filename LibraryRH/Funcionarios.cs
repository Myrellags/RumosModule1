using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LibraryRH
{
    public class Funcionarios : IOperations
    {
        private List<Funcionario> _lista;//atributos - na prática dentro da clase utilizar o atributo fora as propriedades

        public List<Funcionario> Items//propriedade
        {
            get { return _lista; }
            set { _lista = value; }
        }

        public Funcionarios()
        {
            _lista = new List<Funcionario>();//quando um objeto ou propriedade inicializar isnull, criamos
            //um construtor para inicializarmos as propriedades;

        }

        public void FromJson(string json)
        {
            _lista = JsonConvert.DeserializeObject<List<Funcionario>>(json);
        }

        public void FromXML(string xml)
        {
            XmlSerializer x = new XmlSerializer(typeof(Funcionarios));//quando eu quero buscar através da definicao de uma classe o mesmo que this.GetType
            StringReader sr = new StringReader(xml);
            XmlTextReader xr = new XmlTextReader(sr);
            Funcionarios obj = (Funcionarios)x.Deserialize(xr);
            sr.Close();
            this._lista = obj.Items;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_lista);
        }

        public string ToXML()
        {
            string result = "";
            try
            {
                //Criando um arquivo XML
                XmlSerializer x = new XmlSerializer(this.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                using (StringWriter sw = new StringWriter())
                {
                    x.Serialize(sw, this, ns);
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(sw.ToString());
                    result = xDoc.DocumentElement.OuterXml;
                }
            }
            catch
            {

            }
            return result;
        }
    }
}
