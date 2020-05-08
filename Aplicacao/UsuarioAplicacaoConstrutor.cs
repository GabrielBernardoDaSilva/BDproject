using RepositorioADO;
using RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class UsuarioAplicacaoConstrutor
    {

        public static UsuarioAplicacao UsuarioAppADO()
        {
            return new UsuarioAplicacao(new UsuarioAplicacaoADO());
        }

        public static UsuarioAplicacao UsuarioAppEF()
        {
            return new UsuarioAplicacao(new UsuarioRepositorioEF());
        }

    }
}
