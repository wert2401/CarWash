using CarWash.Database.Models.Intefaces;
using CarWash.Database.Repositories.Interfaces;
using CarWash.MVC.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public abstract class BaseController<T> : Controller where T : IModel
    {
        /// <summary>
        /// In realization of this method it needed to set fields of oldEntity to values of newEntity exlusive its id.
        /// It is used in UpdateAndRedirectToAction.
        /// </summary>
        protected abstract void UpdateFieldsOfEntity(T newEntity, ref T oldEntity);
        public delegate IActionResult RedirectUsingNewEntity(T enttity);

        protected IRepository<T> baseRepository;

        public BaseController(IRepository<T> repository)
        {
            baseRepository = repository;
        }

        protected IActionResult GetAndOpen(int id)
        {
            T? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        protected IActionResult FindAndOpen(ISearchViewModel<T> searchViewModel)
        {
            ICollection<T> entities = baseRepository.FindAll(searchViewModel.SearchParameters);

            searchViewModel.Entities = entities;

            return View(searchViewModel);
        }

        protected IActionResult GetAndOpen(int id, IViewModel<T> viewModel)
        {
            T? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            viewModel.Entity = entity;

            return View(viewModel);
        }

        protected IActionResult UpdateAndRedirectToAction(int id, T newEntity, IActionResult redirect)
        {
            T? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            UpdateFieldsOfEntity(newEntity, ref entity);

            baseRepository.Update(entity);

            return redirect;
        }

        protected IActionResult UpdateAndRedirectToAction(int id, T newEntity, RedirectUsingNewEntity redirect)
        {
            T? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            UpdateFieldsOfEntity(newEntity, ref entity);

            baseRepository.Update(entity);

            return redirect(entity);
        }

        protected IActionResult RemoveAndRedirectToAction(int id, IActionResult redirect)
        {
            T? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            baseRepository.Remove(entity);

            return redirect;
        }

        protected IActionResult RemoveAndRedirectToAction(int id, RedirectUsingNewEntity redirect)
        {
            T? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            baseRepository.Remove(entity);

            return redirect(entity);
        }

        protected IActionResult AddAndRedirectToAction(T entity, IActionResult redirect)
        {
            baseRepository.Add(entity);
            return redirect;
        }

        protected IActionResult AddAndRedirectToAction(T entity, RedirectUsingNewEntity redirect)
        {
            baseRepository.Add(entity);
            return redirect(entity);
        }
    }
}
