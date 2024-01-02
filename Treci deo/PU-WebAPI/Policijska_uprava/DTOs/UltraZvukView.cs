namespace Policijska_uprava.DTOs;

public class UltraZvukView : AlarmniSistemView
{
    public int? Gornja_Frekvencija { get; set; }
    public int? Donja_Frekvencija { get; set; }
    public UltraZvukView()
    {

    }
    public UltraZvukView(Ultrazvuk a) : base(a)
    {
        Gornja_Frekvencija = a.Gornja_Frekvencija;
        Donja_Frekvencija = a.Donja_Frekvencija;
    }

}