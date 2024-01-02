using Microsoft.AspNetCore.Mvc;
using Policijska_uprava.DTOs;

namespace Policijska_uprava.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class AlarmniSistemController : ControllerBase
{
    public AlarmniSistemController(){
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("VratiSveSisteme")]
    public async Task<ActionResult> VratiSveSisteme()
    {
        var (isError, sistemi, error) = await DataProvider.VratiSveSistemeAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(sistemi);
    }
   
    [HttpPost]
    [Route("DodajSistem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DodajSistem([FromBody] AlarmniSistemView alarmniSistem)
    {
        var data = await DataProvider.DodajSistemAsync(alarmniSistem);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspešno dodata stanica. Naziv: {alarmniSistem.Model}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("IzmeniSistem")]
    public async Task<ActionResult> IzmeniSistem([FromBody]AlarmniSistemView alarmniSistem)
    {
        var data = await DataProvider.IzmeniSistemAsync(alarmniSistem);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspesno izmenjen sistem sa serijskim brojem: {alarmniSistem.Serijski_Broj}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("IzbrisiSistem/{Serijski_Broj}")]
    public async Task<ActionResult> IzbrisiSistem(int Serijski_Broj)
    {
        var data = await DataProvider.IzbrisiSistemAsync(Serijski_Broj);
        
        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Izbrisi alarmni sistem, serijskog broja: {Serijski_Broj}");
    }
}