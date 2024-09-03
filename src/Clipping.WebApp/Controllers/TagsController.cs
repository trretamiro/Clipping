using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clipping.WebApp.Models;
using Clipping.Business.Interfaces;
using AutoMapper;
using Clipping.Domain.Entities;

namespace Clipping.WebApp.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagAppService _tagAppService;
        private readonly IMapper _mapper;

        public TagsController(ITagAppService tagAppService, 
            IMapper mapper)
        {
            _tagAppService = tagAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var tagsViewModel = _mapper.Map<IEnumerable<TagViewModel>>(await _tagAppService.ObterTodos());

            return View(tagsViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return NotFound();

            var tag = _mapper.Map<TagViewModel>(await _tagAppService.ObterPorId(id));

            if (tag == null) return NotFound();           

            return View(tag);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<Tag>(tagViewModel);
                await _tagAppService.CriarTag(tag);

                return RedirectToAction(nameof(Index));
            }

            return View(tagViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();            

            var tagViewModel = _mapper.Map<TagViewModel>(await _tagAppService.ObterPorId(id));
            if (tagViewModel == null) return NotFound();

            return View(tagViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TagViewModel tagViewModel)
        {
            if (id != tagViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(tagViewModel);

            await _tagAppService.EditarTag(_mapper.Map<Tag>(tagViewModel));
            
           return RedirectToAction(nameof(Index));           
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            var tagViewModel = _mapper.Map<TagViewModel>(await _tagAppService.ObterPorId(id));
            if (tagViewModel == null) return NotFound();

            return View(tagViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0) return NotFound();

            await _tagAppService.DeletarTag(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
