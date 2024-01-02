namespace Policijska_uprava.DTOs;

public class PolicijskaStanicaView
{
    public int? ID { get; set; }
    public string? Naziv { get; set; }
    public string? Adresa { get; set; }
    public int? BrojVozila { get; set; }
    public string? Opstina { get; set; }
    public DateTime? DatumOsnivanja { get; set; }
    public virtual IList<PolicajacView>? Policajci { get; set; }
    public virtual IList<ObjekatView>? Objekti { get; set; }
    internal PolicijskaStanicaView()
    {

    }
    internal PolicijskaStanicaView(Policijska_stanica? p)
    {
        if (p != null)
        {
            ID = p.ID;
            Naziv = p.Naziv;
            Adresa = p.Adresa;
            BrojVozila = p.Broj_sluzbenih_vozila;
            Opstina = p.Opstina;
            DatumOsnivanja = p.Datum_osnivanja;
        }
    }
}