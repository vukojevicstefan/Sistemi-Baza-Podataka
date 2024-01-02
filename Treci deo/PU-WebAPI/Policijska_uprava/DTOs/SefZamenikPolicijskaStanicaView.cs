namespace Policijska_uprava.DTOs;

public class SefZamenikPolicijskaStanicaView{
    public int? ID { get; set; }
    public Policijska_stanica? Policijska_stanica;

    public SefView? Sef;
    public ZamenikSefaView? Zamenik;
    public SefZamenikPolicijskaStanicaView(){

    }
    public SefZamenikPolicijskaStanicaView(SefZamenikPolicijskaStanica szp){
        ID=szp.ID;
    }
    
    public SefZamenikPolicijskaStanicaView(SefZamenikPolicijskaStanica szp, Sef s, ZamenikSefa zs){
        Sef= new SefView(s);
        Zamenik=new ZamenikSefaView(zs);
    }
}