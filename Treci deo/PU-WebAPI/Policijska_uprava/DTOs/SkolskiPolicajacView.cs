namespace Policijska_uprava.DTOs;

public class SkolskiPolicajacView : PolicajacView
{
    public string? Naziv_Skole { get; set; }
    public string? Skola_adresa { get; set; }
    public string? Tip_Skole { get; set; }
    public string? Osoba_Za_Kontakt { get; set; }
    public SkolskiPolicajacView()
    {

    }
    public SkolskiPolicajacView(SkolskiPolicajac p) : base(p)
    {
        Naziv_Skole = p.Naziv_Skole;
        Skola_adresa = p.Skola_adresa;
        Tip_Skole = p.Tip_Skole;
        Osoba_Za_Kontakt = p.Osoba_Za_Kontakt;
    }
}