namespace Policijska_uprava.DTOs;

public class ObjekatBrojTelefonaView{
    public string? Broj { get; set; }
    public ObjekatView? Objekat;
    public ObjekatBrojTelefonaView(){

    }
    public ObjekatBrojTelefonaView(Objekat_Broj_Telefona br){
        Broj=br.Broj;
    }

    public ObjekatBrojTelefonaView(Objekat_Broj_Telefona br, Objekat objekat)
    {
        Broj = br.Broj;
        Objekat = new ObjekatView(objekat);
    }
}