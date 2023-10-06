using InsuranceProject.Service;
using InsuranceProject.DTOs;
using InsuranceProject.Model.Holdings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;

        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("GetAllQueries")]
        public IActionResult GetAllQueries()
        {
            var queries = _queryService.GetAllQueries();
            return Ok(queries);
        }

        [HttpGet("GetQuery/{id}")]
        public IActionResult GetQuery(int id)
        {
            var query = _queryService.GetQueryById(id);
            if (query == null)
            {
                return NotFound();
            }
            var queryDTO = ConvertToQueryDTO(query);
            return Ok(queryDTO);
        }

        [HttpPost("AddQuery")]
        public IActionResult AddQuery([FromBody] QueryDTO queryDTO)
        {
            var newQuery = ConvertToQuery(queryDTO);
            var query = _queryService.AddQuery(newQuery);
            if (query != null)
            {
                return CreatedAtAction(nameof(GetAllQueries), query.QueryId);
            }
            return BadRequest("Query cannot be created");
        }

        [HttpPut("UpdateQuery")]
        public IActionResult UpdateQuery([FromBody] QueryDTO queryDTO)
        {
            var newQuery = ConvertToQuery(queryDTO);
            newQuery.QueryId = queryDTO.QueryId; // Assuming you have a QueryId property in QueryDTO
            var updatedQuery = _queryService.UpdateQuery(newQuery);
            return Ok(updatedQuery.QueryId);
        }
        [HttpDelete("DeleteQuery/{id}")]
        public IActionResult DeleteQueryById(int id)
        {
            var isRemoved = _queryService.DeleteQuery(id);

            if (isRemoved)
            {
                return Ok("Query Removed Successfully");
            }

            return NotFound("Query not found");
        }

        // Add other actions as needed

        private QueryDTO ConvertToQueryDTO(Query query)
        {
            return new QueryDTO
            {
                QueryId = query.QueryId,
                Title = query.Title,
                Message = query.Message,
                ContactDate = query.ContactDate,
                Reply = query.Reply,
                Status = query.Status,
                // Add other property mappings as needed
            };
        }


        private Query ConvertToQuery(QueryDTO queryDTO)
        {
            return new Query
            {
                QueryId = queryDTO.QueryId,
                Title = queryDTO.Title,
                Message = queryDTO.Message,
                ContactDate = queryDTO.ContactDate,
                Reply = queryDTO.Reply,
                Status= queryDTO.Status,
                // Add other property mappings as needed
            };
        }
    }
}
