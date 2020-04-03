using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManager.Data.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LeaveManager.Data.Entities;
using LeaveManager.Models;

namespace LeaveManager.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILeaveTypeRepository repo;
        private IMapper mapper;
        public LeaveTypeController(ILeaveTypeRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var entities = await repo.GetAllAsync();
            var viewModel = mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(entities.ToList());

            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            if (!await repo.IsExistAsync(id))
                return RedirectToAction(nameof(Index));

            var entity = await repo.GetAsync(id).ConfigureAwait(false);
            var model = mapper.Map<LeaveTypeViewModel>(entity);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Model State is not Valid!");

                var entity = mapper.Map<LeaveType>(model);
                if (!await repo.CreateAsync(entity).ConfigureAwait(false))
                    throw new Exception("Creation has failed!");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.TryAddModelException(nameof(ex.Message), ex);
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (!await repo.IsExistAsync(id))
                return RedirectToAction(nameof(Index));

            var entity = await repo.GetAsync(id).ConfigureAwait(false);
            var model = mapper.Map<LeaveTypeViewModel>(entity);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeaveTypeViewModel model)
        {
            try
            {
                model.DateCreated = DateTime.Now;
                if (!ModelState.IsValid)
                    throw new Exception("Model State is not Valid!");

                var entity = mapper.Map<LeaveType>(model);
                if (!await repo.UpdateAsync(entity).ConfigureAwait(false))
                    throw new Exception("Updating has failed!");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.TryAddModelError(ex.Message, ex.Message);
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!await repo.DeleteAsync(id).ConfigureAwait(false))
                    throw new Exception("Entity wasn't delete! Error occurred!");
            }
            catch (Exception ex)
            {
                // log
            }

            return RedirectToAction(nameof(Index));
        }
    }
}