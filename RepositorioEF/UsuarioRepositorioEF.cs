using Dominio;
using Dominio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
    public class UsuarioRepositorioEF : IRepositorio<Usuario>
    {

        private readonly BD bd;

        public UsuarioRepositorioEF()
        {
            bd = new BD();
        }

        public void Excluir(Usuario entidade)
        {
            var usuarioExcluir = bd.usuarios.First(x => x.id == entidade.id);
            bd.Set<Usuario>().Remove(usuarioExcluir);
            bd.SaveChanges();

        }

        public Usuario ListarPorId(string id)
        {
            int intId;
            Int32.TryParse(id, out intId);
            return bd.usuarios.First(x => x.id == intId);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return bd.usuarios;
        }

        public void Salvar(Usuario entidade)
        {
            if (entidade.id > 0)
            {
                var usuarioAlterar = bd.usuarios.First(x => x.id == entidade.id);
                usuarioAlterar.nome = entidade.nome;
                usuarioAlterar.cargo = entidade.cargo;
                usuarioAlterar.data = entidade.data;
            }
            else
            {
                bd.usuarios.Add(entidade);
            }
            bd.SaveChanges();
        }
    }
}
