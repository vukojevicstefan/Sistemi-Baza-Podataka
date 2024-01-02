namespace Policijska_uprava.DTOs;

public class SluzbenoVoziloView
{
    public string? Registarska_Oznaka { get; set; }
    public string? Boja{ get; set; }
    public string? Tip{ get; set; }
    public string? Model{ get; set; }
    public string? Proizvodjac{ get; set; }
    public SluzbenoVoziloView()
    {
    }
    public SluzbenoVoziloView(Sluzbeno_vozilo s){
        Registarska_Oznaka=s.Registarska_Oznaka;
        Boja=s.Boja;
        Tip=s.Tip;
        Model=s.Model;
        Proizvodjac=s.Proizvodjac;
    }
}