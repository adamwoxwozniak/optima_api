using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optimo2021.Models.Filters;
using Optimo2021.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optimo2021.Controllers
{
    [Route("api/optima/[action]")]
    [ApiController]
    public class OptimaController : ControllerBase
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IQueryGenerator _queryGenerator;

        public OptimaController(IDbConnectionFactory dbConnectionFactory, IQueryGenerator queryGenerator)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryGenerator = queryGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> SelectData([FromBody] GetFilter filter)
        {
            using(var db = _dbConnectionFactory.CreateCompanyConnection())
            {
                var result = await db.QueryAsync(_queryGenerator.SelectQuery(filter));

                return Ok(result);
            }
        }
    }
}
