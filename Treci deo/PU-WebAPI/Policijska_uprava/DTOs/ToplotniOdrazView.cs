namespace Policijska_uprava.DTOs;

public class ToplotniOdrazView : AlarmniSistemView
{
    public int? Horizontalna_Rezolucija { get; set; }
    public int? Vertikalna_Rezolucija { get; set; }
    public ToplotniOdrazView()
    {

    }
    public ToplotniOdrazView(Toplotni_Odraz a) : base(a)
    {
        Horizontalna_Rezolucija = a.Horizontalna_Rezolucija;
        Vertikalna_Rezolucija = a.Vertikalna_Rezolucija;
    }

}