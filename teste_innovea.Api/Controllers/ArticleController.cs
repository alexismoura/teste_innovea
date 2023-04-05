using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_innovea.Data.Entity;
using teste_innovea.Service._Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace teste_innovea.Api.Controllers
{
    //[Authorize("Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        IArticleService _ArticleService;

        public ArticleController(IArticleService ArticleService)
        {
            _ArticleService = ArticleService;
        }

        [HttpPost(Name = "Listar")]
        [ActionName("Listar")]
        public async Task<IActionResult> Listar()
        {
            var value = await _ArticleService.GetArticle("startup in civil engineering");
            return Ok(value);
        }

    }
}
