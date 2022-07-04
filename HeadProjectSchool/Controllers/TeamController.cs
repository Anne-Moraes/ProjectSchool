﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeadProjectSchool.Context;
using HeadProjectSchool.Model;

namespace HeadProjectSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly SchoolContext _context;

        public TeamController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetTeam()
        {
            if (_context.Team == null)
            {
                return new JsonResult("Ainda não há turmas cadastrados.");
            }
            List<Team> team = await _context.Team.ToListAsync();

            return new JsonResult(new
            {
                TeamtActives = team.FindAll(e => e.Active == true),
            });

        }


        // GET: api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
          if (_context.Team == null)
          {
              return NotFound();
          }
            var team = await _context.Team.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Team/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Team
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
          if (_context.Team == null)
          {
              return Problem("Entity set 'SchoolContext.Team'  is null.");
          }
            _context.Team.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.Team == null)
            {
                return NotFound();
            }
            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Team.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return (_context.Team?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
