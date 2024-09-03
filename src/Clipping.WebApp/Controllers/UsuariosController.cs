using Microsoft.AspNetCore.Mvc;
using Clipping.WebApp.Models;
using Clipping.Business.Interfaces;
using AutoMapper;
using Clipping.Domain.Entities;

namespace Clipping.WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioAppService usuarioAppService, 
            IMapper mapper)
        {
            _usuarioAppService = usuarioAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var usuariosViewModel = await MapEntityToViewModel<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(
                _usuarioAppService.ObterTodos());

            return View(usuariosViewModel);
        }

        public async Task<IActionResult> Detalhes(int id)
        {
            if (id <= 0) return NotFound();

            var usuarioViewModel = await MapEntityToViewModel<Usuario, UsuarioViewModel>(
                _usuarioAppService.ObterPorId(id));

            if (usuarioViewModel == null) return NotFound();

            return View("Details", usuarioViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Senha,SenhaConfirmacao,Email")] UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarioViewModel);
            }

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioAppService.CriarUsuario(usuario);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id <= 0) return NotFound();

            var usuarioViewModel = await MapEntityToViewModel<Usuario, UsuarioViewModel>(
                _usuarioAppService.ObterPorId(id));

            if (usuarioViewModel == null) return NotFound();

            return View("Edit", usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nome,Senha,SenhaConfirmacao,Email")] UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return View(usuarioViewModel);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioAppService.EditarUsuario(usuario);
            
            return RedirectToAction(nameof(Index));                       
        }

        public async Task<IActionResult> Deletar(int id)
        {
            if (id <= 0) return NotFound();

            var usuarioViewModel = await MapEntityToViewModel<Usuario, UsuarioViewModel>(
                _usuarioAppService.ObterPorId(id));

            if (usuarioViewModel == null) return NotFound();

            return View("Delete", usuarioViewModel);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0) return NotFound();

            await _usuarioAppService.DeletarUsuario(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<TViewModel> MapEntityToViewModel<TEntity, TViewModel>(Task<TEntity> entityTask)
        {
            var entity = await entityTask;
            return _mapper.Map<TViewModel>(entity);
        }
    }
}
