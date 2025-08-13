using Dominio.Interface.Base;
using Dominio.Modelo;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Utils
{
    public class BaseRelatorio : IBaseRelatorio
    {
        /// <summary>
        /// Metodo utilizado para receber a classe e retornar uma lista de dicionario, utilizado para preencher os valores e tipos da classe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listaRelatorio"></param>
        /// <returns></returns>
        public List<Dictionary<CabecalhoRelatorio, TipoObjetoRelatorio>> PreencherInfoClasse<T>(List<T> listaRelatorio)
        {
            var retornoDictionaryObjeto = new List<Dictionary<CabecalhoRelatorio, TipoObjetoRelatorio>>();

            foreach (var itemRelatorio in listaRelatorio)
            {
                var posicao = 0;
                var dictionary = new Dictionary<CabecalhoRelatorio, TipoObjetoRelatorio>();
                foreach (var propriedade in typeof(T).GetProperties())
                {
                    var cabecalho = new CabecalhoRelatorio
                    {
                        Nome = propriedade.Name,    //pegar o nome
                        PosicaoColuna = posicao     //pegar a posição da coluna

                    };

                    var valorComTipo = new TipoObjetoRelatorio
                    {
                        Valor = propriedade.GetValue(itemRelatorio)!,   //ler um valor
                        Tipo = propriedade.PropertyType,                //pegar o tipo
                    };
                    posicao++;
                    dictionary.Add(cabecalho, valorComTipo);
                }
                retornoDictionaryObjeto.Add(dictionary);
            }
            return retornoDictionaryObjeto;
        }

        public DataTable ConverterListParaDataTable<T>(List<T> listaDados)
        {
            DataTable data = new();
            var type = typeof(T);

            for (int i = 0; i < listaDados.Count; i++)
            {
                data.Rows.Add(data.NewRow());
            }

            foreach (var prop in type.GetProperties())
            {
                DataColumn coluna = new(prop.Name)
                {
                    DataType = prop.PropertyType
                };
                data.Columns.Add(coluna);

                int indexLinha = 0;
                foreach (var item in listaDados)
                {
                    DataRow linha = data.Rows[indexLinha++];
                    linha[prop.Name] = prop.GetValue(item);

                }
            }
            return data;
        }
    }
}
