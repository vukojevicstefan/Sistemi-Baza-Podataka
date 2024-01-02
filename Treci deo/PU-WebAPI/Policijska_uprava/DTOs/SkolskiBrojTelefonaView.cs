namespace Policijska_uprava.DTOs;

public class SkolskiBrojTelefonaView
{
    public string? Broj { get; set; }
    public SkolskiPolicajacView? SkolskiPolicajac { get; set; }
    public SkolskiBrojTelefonaView()
    {
    }
    
    public SkolskiBrojTelefonaView(Skolski_Broj_Telefona br){
        Broj=br.Broj;
    }

    public SkolskiBrojTelefonaView(Skolski_Broj_Telefona br, SkolskiPolicajac s)
    {
        Broj = br.Broj;
        SkolskiPolicajac = new SkolskiPolicajacView(s);
    }
}