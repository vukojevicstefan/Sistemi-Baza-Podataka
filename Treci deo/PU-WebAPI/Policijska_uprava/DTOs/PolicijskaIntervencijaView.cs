namespace Policijska_uprava.DTOs;

public class PolicijskaIntervencijaView{
    public int? ID { get; protected set; }
    public string? Opis_Intervencije { get; set; }
    public DateTime? Datum_Intervencije { get; set; }
    public string? Vreme_Intervencije { get; set; }
    public ObjekatView? Objekat;
    public PatrolaView? PatrolaIntervenise;
    public PolicijskaIntervencijaView(){

    }
    public PolicijskaIntervencijaView(Policijska_intervencija p)
    {
        ID = p.ID;
        Opis_Intervencije = p.Opis_Intervencije;
        Datum_Intervencije = p.Datum_Intervencije;
        Vreme_Intervencije = p.Vreme_Intervencije;
    }
    public PolicijskaIntervencijaView(Policijska_intervencija ps, Objekat o, Patrola p) : this(ps)
    {
        Objekat= new ObjekatView(o);
        PatrolaIntervenise=new PatrolaView(p);
    }
}