namespace Policijska_uprava.DTOs;

public class AlarmniSistemView
{
    public int? Serijski_Broj { get; set; }
    public int? Godina_Proizvodnje { get; set; }
    public string? Model { get; set; }
    public DateTime? Datum_Instalacije { get; set; }
    public DateTime? Datum_Poslednjeg_Atesta { get; set; }
    public DateTime? Datum_Poslednjeg_Servisa { get; set; }
    public string? Opis_Poslednjeg_Kvara { get; set; }
    public string? Tehnicko_Lice { get; set; }
    public DateTime? Pocetni_Datum { get; set; }
    public DateTime? Poslednji_Datum { get; set; }//Krajnji
    public ObjekatView? Objekat;


    public AlarmniSistemView()
    {

    }

    public AlarmniSistemView(Alarmni_sistem a)
    {
        Serijski_Broj = a.Serijski_Broj;
        Godina_Proizvodnje = a.Godina_Proizvodnje;
        Model = a.Model;
        Datum_Instalacije = a.Datum_Instalacije;
        Datum_Poslednjeg_Atesta = a.Datum_Poslednjeg_Atesta;
        Datum_Poslednjeg_Servisa = a.Datum_Poslednjeg_Servisa;
        Opis_Poslednjeg_Kvara = a.Opis_Poslednjeg_Kvara;
        Tehnicko_Lice = a.Tehnicko_Lice;
        Pocetni_Datum = a.Pocetni_Datum;
        Poslednji_Datum = a.Poslednji_Datum;
    }
    public AlarmniSistemView(Alarmni_sistem a, Objekat o) : this(a)
    {
        Objekat = new ObjekatView(o);
    }
}