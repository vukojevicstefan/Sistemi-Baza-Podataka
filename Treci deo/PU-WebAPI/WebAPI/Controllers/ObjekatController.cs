using Microsoft.AspNetCore.Mvc;
using Policijska_uprava.DTOs;

namespace Policijska_uprava.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ObjekatController : ControllerBase
{
        public ObjekatController(){
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("VratiSveObjekte")]
    public async Task<ActionResult> VratiSveObjekte()
    {
        var (isError, objekti, error) = await DataProvider.VratiSveObjekteAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(objekti);
    }
   
    [HttpPost]
    [Route("DodajObjekat")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DodajObjekat([FromBody]ObjekatView objekat)
    {
        var data = await DataProvider.DodajObjekatAsync(objekat);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodat objekat. Id: {objekat.Id}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("IzmeniObjekat")]
    public async Task<ActionResult> IzmeniObjekat([FromBody]ObjekatView objekat)
    {
        var data = await DataProvider.IzmeniObjekatAsync(objekat);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspesno izmenjen objekat ID: {objekat.Id}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("IzbrisiObjekat/{Id}")]
    public async Task<ActionResult> IzbrisiObjekat(int Id)
    {
        var data = await DataProvider.IzbrisiObjekatAsync(Id);
        
        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Izbrisi objekat ID-a: {Id}");
    }
}