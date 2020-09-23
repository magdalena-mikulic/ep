using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EP.Magdalena_Sima.Models;
using EP.Magdalena_Sima.Models.Termin;
using EP.Magdalena_Sima.Services;
using Microsoft.AspNetCore.Mvc;

namespace EP.Magdalena_Sima.Controllers
{
    public class TerminiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenesisHttpService _service;

        public TerminiController(IGenesisHttpService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Vacation
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAsync();

            return View(response.Select(x => x.Fields));
        }

        // GET: Vacation/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var response = await _service.GetByIdAsync(id);

            if (response == null) return NotFound();

            return View(response);
        }

        // GET: Vacation/Create
        public IActionResult Create()
        {
            var model = new TerminFields {START_DT = DateTime.Now, END_DT = DateTime.Now.AddDays(1)};


            return View(model);
        }

        // POST: Vacation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("END_DT,GWDURATIONMANUAL,START_DT,KEYWORD")]
            TerminFields vacationFields)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(vacationFields);
                return RedirectToAction(nameof(Index));
            }

            return View(vacationFields);
        }

        // GET: Vacation/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var response = await _service.GetByIdAsync(id);

            if (response == null) return NotFound();

            TempData["Etag"] = response.Etag;

            return View(response);
        }

        // POST: Vacation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GGUID,END_DT,GWDURATIONMANUAL,START_DT,KEYWORD")]
            TerminFields vacationFields)
        {
            if (ModelState.IsValid)
            {
                vacationFields.GGUID = id;
                var model = _mapper.Map<TerminFields, ExtendedModel>(vacationFields);
                model.Etag = TempData["Etag"].ToString();

                await _service.UpdateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            return View(vacationFields);
        }

        // GET: Vacation/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var response = await _service.GetByIdAsync(id);

            if (response == null) return NotFound();

            return View(response);
        }

        // POST: Vacation/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}