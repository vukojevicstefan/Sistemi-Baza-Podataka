using Microsoft.AspNetCore.Mvc;
using Policijska_uprava.DTOs;

namespace Policijska_uprava.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PolicajacController : ControllerBase
{
    public PolicajacController(){
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("VratiSvePolicajce")]
    public async Task<ActionResult> VratiSvePolicajce()
    {
        var (isError, policajci, error) = await DataProvider.VratiSvePolicajceAsync();

        if (isError)
        {
            return BadRequest(error);
        }

        return Ok(policajci);
    }
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("KreirajVanrednogPolicajca/{stanicaID}")]
    public async Task<ActionResult> KreirajVanrednogPolicajca([FromBody] VanredniPolicajacView vanredni, int stanicaID)
    {
        if(vanredni.JMBG!=null){
            var (isError, s, error) = await DataProvider.SacuvajVanrednogPolicajcaBezStaniceAsync(vanredni);

            if (isError)
            {
                return BadRequest(error);
            }
                var data = await DataProvider.PoveziVanrednogPolicajcaIStanicuAsync(vanredni.JMBG, stanicaID);

            if (data.IsError)
            {
                return BadRequest(data.Error);
            }

            return StatusCode(201, $"Upisan vanredni policajac, sa jmbg: {vanredni.JMBG}");
        }
        return BadRequest("JMBG ne sme biti null");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("IzmeniVanrednogPolicajca")]
    public async Task<ActionResult> IzmeniPolicajca([FromBody]VanredniPolicajacView vanredni)
    {
        var data = await DataProvider.IzmeniVanrednogPolicajcaAsync(vanredni);

        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Uspesno izmenjen vanredni policajac, sa jmbg: {vanredni.JMBG}");
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("IzbrisiPolicajca/{policajacJMBG}")]
    public async Task<ActionResult> IzbrisiPolicajca(string policajacJMBG)
    {
        var data = await DataProvider.IzbrisiPolicajcaAsync(policajacJMBG);
        
        if (data.IsError)
        {
            return BadRequest(data.Error);
        }

        return Ok($"Izbrisan policajac, sa jmbg: {policajacJMBG}");
    }
}