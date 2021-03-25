using Dapper;
using Microsoft.AspNetCore.Mvc;
using Optimo2021.Models.Filters;
using Optimo2021.Services;
using System;
using System.Threading.Tasks;

namespace Optimo2021.Controllers
{
    [Route("api/optima/[action]")]
    [ApiController]
    public class OptimaController : ControllerBase
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IQueryGenerator _queryGenerator;
        private readonly IKeyValidator _keyValidator;

        public OptimaController(IDbConnectionFactory dbConnectionFactory, IQueryGenerator queryGenerator, IKeyValidator keyValidator)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryGenerator = queryGenerator;
            _keyValidator = keyValidator;
        }

        [HttpPost("{key}")]
        public async Task<IActionResult> SelectData([FromRoute] string key, [FromBody] GetFilter filter)
        {
            try
            {
                if (_keyValidator.Validate(key))
                {
                    using (var db = _dbConnectionFactory.CreateCompanyConnection())
                    {
                        var result = await db.QueryAsync(_queryGenerator.SelectQuery(filter));

                        return Ok(result);
                    }
                }
                return Unauthorized();
            }
            catch(Exception ex)
            {
                return StatusCode(400, new { ex.Message, ex.StackTrace });
            }
        }
    }
}
