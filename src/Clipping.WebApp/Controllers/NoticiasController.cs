﻿using Microsoft.AspNetCore.Mvc;
using Clipping.WebApp.Models;
using Clipping.Business.Interfaces;
using Clipping.Domain.Entities;
using AutoMapper;

namespace Clipping.WebApp.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly INoticiaAppService _noticiaService;
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly ITagAppService _tagAppService;
        private readonly IMapper _mapper;

        public NoticiasController(INoticiaAppService noticiaRepository,
            IUsuarioAppService usuarioAppService,
            ITagAppService tagAppService,
            IMapper mapper)
        {
            _noticiaService = noticiaRepository;
            _usuarioAppService = usuarioAppService;
            _tagAppService = tagAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var noticias = await _noticiaService.ObterNoticiasComTags();
            var noticiasViewModel = _mapper.Map<List<NoticiaViewModel>>(noticias);

            return View(noticiasViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return NotFound();

            var noticia = await _noticiaService.ObterDetalhesNoticia(id);
            if (noticia == null) return NotFound();

            var noticiaViewModel = _mapper.Map<NoticiaViewModel>(noticia);

            return PartialView(noticiaViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = await PopularParaNoticias(new CriarNoticiaViewModel());

            return PartialView("Create", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CriarNoticia(CriarNoticiaViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var noticia = _mapper.Map<Noticia>(model);
            noticia.NoticiaTags = CriarListaNoticiaTag(model.Tags);

            await _noticiaService.CriarNoticia(noticia);

            return Json("Noticia criada com sucesso!");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();

            var noticia = await _noticiaService.ObterDetalhesNoticia(id);
            if (noticia == null) return NotFound();

            var noticiaViewModel = _mapper.Map<CriarNoticiaViewModel>(noticia);

            var tags = await _tagAppService.ObterTodos();
            noticiaViewModel.Tags = _mapper.Map<List<TagViewModel>>(tags);

            var usuarios = await _usuarioAppService.ObterTodos();
            noticiaViewModel.Usuarios = _mapper.Map<List<UsuarioViewModel>>(usuarios);

            return PartialView("Edit", noticiaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarNoticia(CriarNoticiaViewModel model)
        {
            if (model.Id <= 0) return NotFound();

            if (!ModelState.IsValid) return View("Edit", model);

            var noticia = _mapper.Map<Noticia>(model);

            noticia.NoticiaTags = CriarListaNoticiaTag(model.Tags);
            await _noticiaService.EditarNoticia(noticia);

            return Json("Noticia editada com sucesso!");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            var noticia = await _noticiaService.ObterDetalhesNoticia(id);
            if (noticia == null) return NotFound();

            var noticiaViewModel = _mapper.Map<NoticiaViewModel>(noticia);

            return PartialView(noticiaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0) return NotFound();

            await _noticiaService.DeletarNoticia(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CriarNoticiaViewModel> PopularParaNoticias(CriarNoticiaViewModel model)
        {
            model.Tags = _mapper.Map<IEnumerable<TagViewModel>>(await _tagAppService.ObterTodos());
            ViewBag.TagsBag = model.Tags;

            model.Usuarios = _mapper.Map<List<UsuarioViewModel>>(await _usuarioAppService.ObterTodos());
            ViewBag.UsuariosBag = model.Usuarios;

            return model;
        }

        private List<NoticiaTag> CriarListaNoticiaTag(IEnumerable<TagViewModel> tags)
        {
            return tags.Select(tag => new NoticiaTag
            {
                NoticiaId = 0,
                TagId = tag.Id
            }).ToList();
        }

        private List<UsuarioViewModel> CriarListaNoticiaComUsuario(List<Usuario> usuarios)
        {
            return usuarios.Select(usr => new UsuarioViewModel
            {
                Id = usr.Id,
                Nome = usr.Nome
            }).ToList();
        }
    }
}
