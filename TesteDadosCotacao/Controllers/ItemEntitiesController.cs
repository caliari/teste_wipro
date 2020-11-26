using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Model;
using TesteDadosCotacao.Model;

namespace TesteDadosCotacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemEntitiesController : ControllerBase
    {
        private readonly DadosContext _context;

        public ItemEntitiesController(DadosContext context)
        {
            _context = context;
        }

        // POST: api/ItemEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("/api/ItemEntities/AddItemFila")]
        public async Task<ActionResult> PostItemEntity(List<ItemEntity> itemEntity)
        {
            foreach(ItemEntity item in itemEntity)
                _context.Items.Add(item);

            await _context.SaveChangesAsync();

            return Ok("Itens criados com sucesso!");
        }

        // DELETE: api/ItemEntities/5
        [HttpGet]
        [Route("/api/ItemEntities/GetItemFila")]
        public async Task<ActionResult<ItemEntity>> GetItemEntity()
        {
            var itemEntity = await _context.Items.LastOrDefaultAsync();
            if (itemEntity == null)
            {
                return new ItemEntity { moeda = string.Empty };
            }

            _context.Items.Remove(itemEntity);
            await _context.SaveChangesAsync();

            return itemEntity;
        }
    }
}
