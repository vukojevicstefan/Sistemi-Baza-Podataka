namespace Policijska_uprava.DTOs;

public class PolicajacView
{
    public string? JMBG { get; set; }
    public string? Ime { get; set; }
    public string? ImeRoditelja { get; set; }
    public string? Prezime { get; set; }
    public DateTime? DatumRodjenja { get; set; }
    public DateTime? DatumPrijema { get; set; }
    public string? Adresa { get; set; }
    public char? Pol { get; set; }
    public string? NazivSkoleKursa { get; set; }
    public DateTime? DatumSticanjaDiplome { get; set; }
    public string? Cin { get; set; }
    public DateTime? DatumSticanjaCina { get; set; }
    public PolicijskaStanicaView? PolicijskaStanica;
    public PolicajacView()
    {

    }
    internal PolicajacView(Policajac? p)
    {
        if (p != null)
        {
            JMBG = p.Jmbg;
            Ime = p.Ime;
            ImeRoditelja = p.Ime_Roditelja;
            Prezime = p.Prezime;
            DatumRodjenja = p.Datum_Rodjenja;
            DatumPrijema = p.Datum_Prijema;
            Adresa = p.Adresa;
            Pol = p.Pol;
            NazivSkoleKursa = p.Naziv_Skole_Kursa;
            DatumSticanjaDiplome = p.Datum_Sticanja_Diplome;
            Cin = p.Cin;
            DatumSticanjaCina = p.Datum_Sticanja_Cina;
        }
    }
    internal PolicajacView(Policajac? p, Policijska_stanica s) : this(p)
    {
        PolicijskaStanica = new PolicijskaStanicaView(s);
    }
}