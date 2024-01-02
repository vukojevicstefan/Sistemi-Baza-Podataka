namespace Policijska_uprava.DTOs;

public class PokretView : AlarmniSistemView
{
    public int? Osetljivost { get; set; }
    public PokretView()
    {

    }
    public PokretView(Pokret a) : base(a)
    {
        Osetljivost=a.Osetljivost;
    }
}