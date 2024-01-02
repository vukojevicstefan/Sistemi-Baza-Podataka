namespace Policijska_uprava.DTOs;

public class VanredniPolicajacView : PolicajacView
{
    public virtual string? Naziv_Vestine { get; set; }
    public virtual string? Poseduje_Sertifikat { get; set; }
    public virtual string? Pohadjao_Kurs { get; set; }
    public virtual DateTime? Datum_Zavrsetka_Kursa { get; set; }
    public virtual DateTime? Datum_Sticanja_Sertifikata { get; set; }
    public VanredniPolicajacView()
    {

    }
    internal VanredniPolicajacView(PolicajacVanredneSituacije p) : base(p)
    {
        Naziv_Vestine = p.Naziv_Vestine;
        Poseduje_Sertifikat = p.Poseduje_Sertifikat;
        Pohadjao_Kurs = p.Pohadjao_Kurs;
        Datum_Zavrsetka_Kursa = p.Datum_Zavrsetka_Kursa;
        Datum_Sticanja_Sertifikata = p.Datum_Sticanja_Sertifikata;
    }
    internal VanredniPolicajacView(PolicajacVanredneSituacije p, Policijska_stanica s) : base(p, s)
    {
        Naziv_Vestine = p.Naziv_Vestine;
        Poseduje_Sertifikat = p.Poseduje_Sertifikat;
        Pohadjao_Kurs = p.Pohadjao_Kurs;
        Datum_Zavrsetka_Kursa = p.Datum_Zavrsetka_Kursa;
        Datum_Sticanja_Sertifikata = p.Datum_Sticanja_Sertifikata;
    }

}