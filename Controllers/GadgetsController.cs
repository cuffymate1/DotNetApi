using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GadgetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GadgetsController(ApplicationDbContext context)
        {
            _context = context;
        }
       

        // Get All Gadgets
        [HttpGet]
        public ActionResult Get()
        {
            var allGadgets = _context.Gadgets.ToList();
            return Ok(allGadgets);
        }

        // Get Gadget by Id
        [HttpGet("{id}")]
        public ActionResult<Gadgets> Get(int id)
        {
            var gadget = _context.Gadgets.Find(id);
            if (gadget == null)
            {
                return NotFound();
            }
            return Ok(gadget);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create([FromForm] Gadgets gadget)
        {
            _context.Gadgets.Add(gadget);
            _context.SaveChanges();
            return CreatedAtAction("Create Success!", new { id = gadget.Id }, gadget);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult Update(Gadgets gadget)
        {
           
            _context.Update(gadget);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var gadget = _context.Gadgets.Find(id);
            if (gadget == null)
            {
                return NotFound();
            }
            _context.Gadgets.Remove(gadget);
            _context.SaveChanges();
            return NoContent();
        }

        
        
    }
}