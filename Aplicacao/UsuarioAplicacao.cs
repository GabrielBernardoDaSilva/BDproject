﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioADO;
using Dominio;
using Dominio.Contrato;

namespace Aplicacao
{
   public class UsuarioAplicacao
    {
        private readonly IRepositorio<Usuario> repositorio;


        public UsuarioAplicacao(IRepositorio<Usuario> repo)
        {
            repositorio =repo;
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.id > 0)
            {
                repositorio.Salvar(usuario);
                
            }
            else
            {
                repositorio.Salvar(usuario);
            }
        }

        public void Excluir(Usuario usuario)
        {

            repositorio.Excluir(usuario);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Usuario ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);

        }

               
    }
}
