using Microsoft.AspNetCore.Mvc;
using Policijska_uprava.DTOs;

namespace Policijska_uprava.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class IntervencijaController : ControllerBase
{
        public IntervencijaController(){
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("VratiSveIntervencije")]
    public async Task<ActionResult> VratiSveIntervencije()
    {
        var (isError, intervencije, error) = await DataProvider.VratiSveIntervencijeAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(intervencije);
    }
   
    [HttpPost]
    [Route("DodajIntervenciju")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DodajIntervenciju([FromBody]PolicijskaIntervencijaView intervencija)
    {
        var data = await DataProvider.DodajIntervencijuAsync(intervencija);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata intervencija. Id: {intervencija.ID}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("IzmeniIntervenciju")]
    public async Task<ActionResult> IzmeniIntervenciju([FromBody]PolicijskaIntervencijaView i)
    {
        var data = await DataProvider.IzmeniIntervencijuAsync(i);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspesno izmenjena intervencija. Id: {i.ID}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("IzbrisiIntervenciju/{Id}")]
    public async Task<ActionResult> IzbrisiIntervenciju(int Id)
    {
        var data = await DataProvider.IzbrisiIntervencijuAsync(Id);
        
        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Izbrisi intervenciju ID-a: {Id}");
    }
}