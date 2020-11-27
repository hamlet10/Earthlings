using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasHamlet.Data;
using PersonasHamlet.Dtos;
using PersonasHamlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonasHamlet.Controllers
{
    public class PersonasController : Controller
    {
        private readonly PersonasDbContext _context;
        private readonly IMapper _mapper;

        public PersonasController(PersonasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            
            List<PersonaDto> personasListDto = _mapper.Map<List<PersonaDto>>(await _context.Personas.ToListAsync());
            return View(personasListDto);
        }

        [HttpGet]
        public ViewResult PersonaForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> PersonaForm(PersonaDto personaDto)
        {
            if (ModelState.IsValid)
            {
                var persona = _mapper.Map<Persona>(personaDto);
                await _context.Personas.AddAsync(persona);
                await _context.SaveChangesAsync();
            }
            var personList = _mapper.Map<List<PersonaDto>>(await _context.Personas.ToListAsync());


            return View("Index", personList);

        }
    }
}
