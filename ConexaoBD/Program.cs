using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bdProjetoRep;
using Dominio;
using Aplicacao;

namespace Dominio
{
    class Program
    {
        static void Main(string[] args)
        {
            var bd = new BD();
            var ua = new UsuarioAplicacao();
            /*
            string nome = Console.ReadLine();
            string cargo = Console.ReadLine();
            string data = Console.ReadLine();
            
            var user = new Usuario
            {
                nome = nome,
                cargo = cargo,
                data = DateTime.Parse(data)
            };


            string strQueryUpdate = "UPDATE Usuario set nome='Fabio' Where usuarioid=1";
            SqlCommand cmdUpdate = new SqlCommand(strQueryUpdate, conexao);
            cmdUpdate.ExecuteNonQuery();


            string strQueryDelete = "Delete From Usuario Where usuarioid=2";
            SqlCommand cmdDelete = new SqlCommand(strQueryDelete, conexao);
            cmdDelete.ExecuteNonQuery();


            ua.Insert(user);
            
            
            string strQuerySelect = "SELECT * FROM Usuario";
            var dados = bd.executaDataReader(strQuerySelect);
            

            while (dados.Read())
            {
                Console.WriteLine("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", dados["usuarioid"], dados["nome"], dados["cargo"], dados["data" +
                    ""]);
            }
            
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();


            string nome = Console.ReadLine();
            string cargo = Console.ReadLine();
            string data = Console.ReadLine();


            var user = new Usuario
            {
                id= int.Parse(id),
                nome = nome,
                cargo = cargo,
                data = DateTime.Parse(data)
            };

            ua.Salvar
                (user);
            

            string id = Console.ReadLine();
            ua.Excluir(int.Parse(id));

            var strQuerySelect = "SELECT * FROM Usuario";
            var dados = bd.executaDataReader(strQuerySelect);
            */


            var dados = ua.ListarTodos();
            
            foreach(var dado in dados)
            {
              
                Console.WriteLine(string.Format("Id:{0}, Nome:{1}, Cargo:{2}, Data:{3}", dado.id, dado.nome, dado.cargo, dado.data));
            }


            Console.ReadLine();

        }
    }
}
