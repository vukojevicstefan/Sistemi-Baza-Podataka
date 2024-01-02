using Microsoft.AspNetCore.Mvc;
using Policijska_uprava.DTOs;

namespace Policijska_uprava.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PolicijskaStanicaController : ControllerBase
{
    public PolicijskaStanicaController(){

    }
    [HttpGet]
    [Route("VratiSveStanice")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult VratiSveStanice()
    {
        (bool isError, var stanice, string? error) = DataProvider.VratiSveStanice();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(stanice);
    }
    [HttpPost]
    [Route("DodajStanicu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DodajStanicu([FromBody] PolicijskaStanicaView s)
    {
        var data = await DataProvider.DodajStanicuAsync(s);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata stanica. Naziv: {s.Naziv}");
    }
    [HttpPut]
    [Route("IzmeniStanicu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> IzmeniStanicu([FromBody] PolicijskaStanicaView p)
    {
        (bool isError, var stanica, string? error) = await DataProvider.IzmeniStanicuAsync(p);

        if (isError)
        {
            return BadRequest(error);
        }

        if (stanica == null)
        {
            return BadRequest("Stanica nije validna.");
        }

        return Ok($"Uspešno ažurirana stanica. Naziv: {stanica.Naziv}");
    }
     [HttpDelete]
    [Route("IzbrisiStanicu/{stanicaID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> IzbrisiStanicu(int stanicaID)
    {
        var data = await DataProvider.IzbrisiStanicuAsync(stanicaID);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno obrisana stanica. ID: {stanicaID}");
    }
}