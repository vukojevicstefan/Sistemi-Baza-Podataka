namespace Policijska_uprava.DTOs;
public class NacelnikZamenikView
{
    public int? Id { get; set; }
    public NacelnikView? Nacelnik;
    public ZamenikZaVanredneSituacijeView? ZamenikZaVanredneSituacije;
    public ZamenikZaKrvneDelikteView? ZamenikZaKrvneDelikte;
    public ZamenikZaSaobracajView? ZamenikZaSaobracaj;
    public NacelnikZamenikView()
    {

    }

    public NacelnikZamenikView(NacelnikZamenik nz)
    {
        Id = nz.Id;
    }
    public NacelnikZamenikView(NacelnikZamenik nz, Nacelnik n, ZamenikZaKrvneDelikte zkd, ZamenikZaSaobracaj zs, ZamenikZaVanredneSituacije zvs)
    {
        this.ZamenikZaKrvneDelikte=new ZamenikZaKrvneDelikteView(zkd);
        this.ZamenikZaSaobracaj=new ZamenikZaSaobracajView(zs);
        this.ZamenikZaVanredneSituacije=new ZamenikZaVanredneSituacijeView(zvs);
    }
}