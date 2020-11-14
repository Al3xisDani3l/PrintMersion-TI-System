using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrintMersion.Core.Interfaces;
using PrintMersion.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrintMersion.Infrastructure.Data;

namespace PrintMersion.Web.Controllers
{
    public class GenericController<TEntity> : Controller where TEntity : class, IEntity, new()
    {
        

        IRepository<TEntity> _repository;
        IGlobal _global;

        IRepository<Picture> _rePicture;

        internal PrintMersionDBContext _context;

        public GenericController(IRepository<TEntity> repository,IRepository<Picture> repositoryPicture ,IGlobal global, PrintMersionDBContext dBContext)
        {
            _repository = repository;
            _rePicture = repositoryPicture;
            _context = dBContext;
            _global = global;
        }
        // GET: Generic
        public virtual async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                return View(await _repository.Get());
            }
            else
            {
               return  NotFound();
            }

          
        }

        // GET: Generic/Details/5
        public virtual async Task<IActionResult> Details(int? id)
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _repository.Get(id.Value);

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Generic/Create
        public virtual async Task<IActionResult> Create()
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                return await Task.FromResult(View());
            }
            else
            {
                return NotFound();
            }

           

        }

        // POST: Generic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create([FromForm] TEntity entity)
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        await _repository.Post(entity);

                        return RedirectToAction(nameof(Index));
                    }

                    return View(entity);


                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return NotFound();
            }
           
        }

        // GET: Generic/Edit/5
        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _repository.Get(id.Value);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Generic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(int? id,[FromForm] TEntity entity)
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                if (id.Value != entity.Id || id == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        await _repository.Put(entity);

                    }
                    catch (Exception ex)
                    {
                        return NotFound();
                    }
                    return RedirectToAction(nameof(Index));
                }
               
                return View(entity);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (!string.IsNullOrEmpty(_global.CurrentToken))
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (!await _repository.Delete(id.Value))
                {
                    return RedirectToAction(nameof(Index));
                }

                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }



        }

     
    }

    // GET: Generic/Delete/5
  

   
}