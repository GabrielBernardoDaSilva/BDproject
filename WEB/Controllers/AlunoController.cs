using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace WEB.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno


        private UsuarioAplicacao appUser;

        public AlunoController()
        {
            appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
        }
        public ActionResult Index()
        {
           // var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
            var lstUser = appUser.ListarTodos();
            return View(lstUser);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
                appUser.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }


        public ActionResult Edit(string id)
        {
           // var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
            var user = appUser.ListarPorId(id);
            if (user == null)
                return HttpNotFound();
            return View(user);

        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
              //  var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
                appUser.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Details(string id)
        {
            //var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
            var user = appUser.ListarPorId(id);
            if (user == null)
                return HttpNotFound();
            return View(user);

        }

        public ActionResult Delete(string id)
        {
           // var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
            var user = appUser.ListarPorId(id);
            if (user == null)
                return HttpNotFound();
            return View(user);

        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirm(string id)
        {
            //var appUser = UsuarioAplicacaoConstrutor.UsuarioAppADO();
            var usuario = appUser.ListarPorId(id);
            appUser.Excluir(usuario);
            return RedirectToAction("Index");

        }
    }
}