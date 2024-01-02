namespace Policijska_uprava.DTOs;

public class PatrolaView{
    public int? Redni_Broj { get; set; }
    public PolicajacPatroleView? Vodja;
    public PolicajacPatroleView? Clan;
    public SluzbenoVoziloView? Vozilo;
    public IList<Policijska_intervencija>? Intervencije { get; set; }
    public PatrolaView(){

    }

    public PatrolaView(Patrola p)
    {
        Redni_Broj = p.Redni_Broj;
    }
    public PatrolaView(Patrola p, PolicajacPatrole v, PolicajacPatrole c, Sluzbeno_vozilo sv) : this(p)
    {
        Vodja = new PolicajacPatroleView(v);
        Clan = new PolicajacPatroleView(c);
        Vozilo=new SluzbenoVoziloView(sv);
    }
}