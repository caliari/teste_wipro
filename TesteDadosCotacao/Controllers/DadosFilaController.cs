using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TesteDadosCotacao.Model;
using TesteDadosCotacao.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteDadosCotacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosFilaController : ControllerBase
    {
        // GET api/<DadosFilaController>/5
        [HttpGet]
        [Route("/api/GetItemFila")]
        public ActionResult GetItemFila()
        {
            List<ItemEntity> data = HttpContext.Session.Get<IEnumerable<ItemEntity>>("ListaItens")?.ToList();
            if (data != null && data.Count > 0)
            {
                ItemEntity LastitemEntity = data[data.Count - 1];
                data.Remove(LastitemEntity);
                HttpContext.Session.Clear();
                HttpContext.Session.Set("ListaItens", data);
                return Ok(LastitemEntity);

            }
            else
                return Ok("Não existem mais itens a serem removidos da fila");
        }

        // POST api/<DadosFilaController>
        [HttpPost]
        [Route("/api/AddItemFila")]
        public ActionResult AddItemFila(IEnumerable<ItemEntity> itemEntity)
        {
            if (ModelState.IsValid)
            {
                List<ItemEntity> data = HttpContext.Session.Get<IEnumerable<ItemEntity>>("ListaItens")?.ToList();
                if (data == null) { data = new List<ItemEntity>(); }
                if (itemEntity?.ToList().Count > 0)
                {
                    foreach(ItemEntity item in itemEntity)
                    {
                        if (!data.Exists(x => x.moeda == item.moeda &&
                                        x.data_fim == item.data_fim &&
                                        x.data_inicio == item.data_inicio))
                        {
                            data.Add(item);
                        }
                    }
                }

                HttpContext.Session.Clear();
                HttpContext.Session.Set("ListaItens", data);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
