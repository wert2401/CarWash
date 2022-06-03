using CarWash.Database.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.MVC.Controllers
{
    public abstract class BaseController<T, M> : Controller where T : IRepository<M>
    {
        /// <summary>
        /// In realization of this method it needed to set fields of oldEntity to fields of newEntity exlusive its id.
        /// It is used in TryUpdateAndRedirectToAction.
        /// </summary>
        protected abstract void UpdateFieldsOfEntity(M newEntity, ref M oldEntity);
        public delegate IActionResult RedirectUsingNewEntity(M enttity);

        protected T baseRepository;

        public BaseController(T repository)
        {
            baseRepository = repository;
        }

        protected IActionResult GetAndOpen(int id)
        {
            M? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        protected IActionResult UpdateAndRedirectToAction(int id, M newEntity, IActionResult redirect)
        {
            M? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            UpdateFieldsOfEntity(newEntity, ref entity);

            baseRepository.Update(entity);

            return redirect;
        }

        protected IActionResult UpdateAndRedirectToAction(int id, M newEntity, RedirectUsingNewEntity redirect)
        {
            M? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            UpdateFieldsOfEntity(newEntity, ref entity);

            baseRepository.Update(entity);

            return redirect(entity);
        }

        protected IActionResult RemoveAndRedirectToAction(int id, IActionResult redirect)
        {
            M? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            baseRepository.Remove(entity);

            return redirect;
        }

        protected IActionResult RemoveAndRedirectToAction(int id, RedirectUsingNewEntity redirect)
        {
            M? entity = baseRepository.Get(id);

            if (entity == null)
                return NotFound();

            baseRepository.Remove(entity);

            return redirect(entity);
        }

        protected IActionResult AddAndRedirectToAction(M entity, IActionResult redirect)
        {
            baseRepository.Add(entity);
            return redirect;
        }

        protected IActionResult AddAndRedirectToAction(M entity, RedirectUsingNewEntity redirect)
        {
            baseRepository.Add(entity);
            return redirect(entity);
        }
    }
}
