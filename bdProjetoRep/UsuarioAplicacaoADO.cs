using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Contrato;

namespace RepositorioADO
{
   public class UsuarioAplicacaoADO : IRepositorio<Usuario>
    {
        private BD bd;

        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "Insert Into Usuario(nome,cargo,data)";
            strQuery += string.Format(" Values('{0}', '{1}', '{2}')",usuario.nome,usuario.cargo,usuario.data);
            using (bd = new BD())
            {
                bd.excutaComando(strQuery);
            }

        }



        private void Alterar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE Usuario SET";
            strQuery += string.Format(" nome = '{0}', cargo = '{1}', data = '{2}'", usuario.nome, usuario.cargo, usuario.data);
            strQuery += string.Format(" Where id='{0}'", usuario.id);
            using (bd = new BD())
            {
                bd.excutaComando(strQuery);
            }
        }


        public void Salvar(Usuario usuario)
        {
            if (usuario.id > 0)
            {
                Alterar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }

        public void Excluir(Usuario usuario)
        {
            
            var strQuery = string.Format("DELETE FROM Usuario Where id='{0}'", usuario.id);
            using (bd = new BD())
            {
                bd.excutaComando(strQuery);
            }
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            using (bd = new BD())
            {
                var strQuery = "SELECT * FROM Usuario";

                var ret =  bd.executaDataReader(strQuery);

                return ReaderEmlista(ret);

            }
            
        }

        public Usuario ListarPorId(string id)
        {
            using (bd = new BD())
            {
                var strQuery = string.Format( "SELECT * FROM Usuario WHERE id = {0}",id);

                var ret = bd.executaDataReader(strQuery);

                return ReaderEmlista(ret).FirstOrDefault();

            }

        }

        private List<Usuario> ReaderEmlista(SqlDataReader reader)
        {

            List<Usuario> Usuarios = new List<Usuario>();
            while (reader.Read())
            {
                var objeto = new Usuario()
                {
                    id = int.Parse(reader["id"].ToString()),
                    nome = reader["nome"].ToString(),
                    cargo = reader["cargo"].ToString(),
                    data = DateTime.Parse(reader["data"].ToString())
                };
                Usuarios.Add(objeto);
                
            }
            reader.Close();
            return Usuarios;

        }
            
    }
}
