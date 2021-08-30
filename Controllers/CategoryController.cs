using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using atividade5.models;
using atividade5.Data;
using Microsoft.EntityFrameworkCore;

namespace atividade5.Controllers
{

    [ApiController]
    [Route("v1/categories")]

    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody]Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Category>> Put(
            [ FromServices] DataContext context,
            [FromBody] Category model)

        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else

            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Category>> Delete(
            [FromServices] DataContext context,
            [FromBody] Category model)

        {
            if (ModelState.IsValid)
            {
                context.Categories.Remove(model);
                await context.SaveChangesAsync();
                return model;
            }
            else


            {
                return BadRequest();
        }
    }

    }
}