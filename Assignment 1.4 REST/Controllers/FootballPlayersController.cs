using Mandatory_assignment_1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1._4_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: IPAsController
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult <IEnumerable<FootballPlayer>> GetAll()
        {
            if (_manager.GetAll() == null)
            {
                return NotFound();
            }
            return Ok(_manager.GetAll());
        }

        // GET api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> GetById(int id)
        {
            FootballPlayer footballPlayer = _manager.GetById(id);

            if (footballPlayer == null)
            {
                return NotFound("No such item, Id: " + id);
            }
            return Ok(footballPlayer);
        }

        // POST api/<BooksController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult <FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            FootballPlayer footballPlayer = _manager.Add(value);
            if (value == null || value.Id == null || value.Name == null || value.Age == null || value.ShirtNumber == null)
            {
                return BadRequest(footballPlayer);
            }

            return Ok(footballPlayer);
        }

        // PUT api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            FootballPlayer footballPlayer = _manager.Update(id, value);

            if (value.Id != footballPlayer.Id)
            {
                return NotFound("No such item, Id: " + id);
            }

            return Ok(footballPlayer);

            //return _manager.Update(id, value);
        }

        // DELETE api/<BooksController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer footballPlayer = _manager.Delete(id);

            if (id != footballPlayer.Id)
            {
                return NotFound("No such item, Id: " + id);
            }
            return Ok(footballPlayer);

            //return _manager.Delete(id);
        }
    }
}
