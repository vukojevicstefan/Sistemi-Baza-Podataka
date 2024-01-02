namespace Policijska_uprava.DTOs;

public class ObjekatView
{
    public int? Id { get; set; }
    public string? Adresa { get; set; }
    public string? Tip { get; set; }
    public float? Povrsina { get; set; }
    public string? KontaktIme { get; set; }
    public string? KontaktPrezime { get; set; }
    public PolicijskaStanicaView? PolicijskaStanica;
    public IList<AlarmniSistemView>? AlarmniSistemi { get; set; }
    public IList<ObjekatBrojTelefonaView>? BrojeviTelefonaObjekta { get; set; }
    public IList<PolicijskaIntervencijaView>? PolicijskeIntervencije { get; set; }
    public ObjekatView()
    {
        AlarmniSistemi = new List<AlarmniSistemView>();
        BrojeviTelefonaObjekta = new List<ObjekatBrojTelefonaView>();
        PolicijskeIntervencije = new List<PolicijskaIntervencijaView>();
    }

    public ObjekatView(Objekat o)
    {
        Id = o.Id;
        Adresa = o.Adresa;
        Tip = o.Tip;
        Povrsina = o.Povrsina;
        KontaktIme = o.KontaktIme;
        KontaktPrezime = o.KontaktPrezime;
    }
}