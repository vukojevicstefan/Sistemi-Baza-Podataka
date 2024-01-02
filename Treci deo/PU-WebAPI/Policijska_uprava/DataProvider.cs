using NHibernate;
using NHibernate.Event.Default;
using System.Web;

namespace Policijska_uprava;

public static class DataProvider
{
    public static async Task<Result<List<PolicajacView>, string>> VratiSvePolicajceAsync()
    {
        List<PolicajacView> data = new();

        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            data = (await s.QueryOver<Policajac>().ListAsync())
                           .Select(p => new PolicajacView(p)).ToList();
        }
        catch (Exception)
        {
            return "Došlo je do greške prilikom prikupljanja informacija o odeljenjima.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return data;
    }
    public async static Task<Result<bool, string>> SacuvajVanrednogPolicajcaBezStaniceAsync(VanredniPolicajacView vanredni)
    {
        if(vanredni.JMBG!=null){
        ISession? s = null;
        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PolicajacVanredneSituacije v = new()
            {
                Jmbg = vanredni.JMBG,
                Ime = vanredni.Ime,
                Ime_Roditelja = vanredni.ImeRoditelja,
                Prezime = vanredni.Prezime,
                Datum_Rodjenja = vanredni.DatumRodjenja,
                Datum_Prijema = vanredni.DatumPrijema,
                Adresa = vanredni.Adresa,
                Pol = vanredni.Pol,
                Naziv_Skole_Kursa = vanredni.NazivSkoleKursa,
                Datum_Sticanja_Diplome = vanredni.DatumSticanjaDiplome,
                Cin = vanredni.Cin,
                Datum_Sticanja_Cina = vanredni.DatumSticanjaCina,
                Naziv_Vestine = vanredni.Naziv_Vestine,
                Pohadjao_Kurs = vanredni.Pohadjao_Kurs,
                Poseduje_Sertifikat = vanredni.Poseduje_Sertifikat,
                Datum_Zavrsetka_Kursa = vanredni.Datum_Zavrsetka_Kursa,
                Datum_Sticanja_Sertifikata = vanredni.Datum_Sticanja_Sertifikata
            };

            await s.SaveAsync(v);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće sačuvati policajca bez stanice.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
        }
        return "JMBG je NULL";
    }
    public async static Task<Result<bool, string>> PoveziVanrednogPolicajcaIStanicuAsync(string policajacJMBG, int stanicaID)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PolicajacVanredneSituacije vanredni = await s.LoadAsync<PolicajacVanredneSituacije>(policajacJMBG);
            Policijska_stanica stanica = await s.LoadAsync<Policijska_stanica>(stanicaID);

            vanredni.Policijska_stanica = stanica;

            await s.UpdateAsync(vanredni);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće povezati policajca sa stanicom.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public async static Task<Result<bool, string>> IzmeniVanrednogPolicajcaAsync(VanredniPolicajacView vanredni)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            PolicajacVanredneSituacije o = await s.LoadAsync<PolicajacVanredneSituacije>(vanredni.JMBG);

            o.Ime = vanredni.Ime;
            o.Ime_Roditelja = vanredni.ImeRoditelja;
            o.Prezime = vanredni.Prezime;
            o.Datum_Rodjenja = vanredni.DatumRodjenja;
            o.Datum_Prijema = vanredni.DatumPrijema;
            o.Adresa = vanredni.Adresa;
            o.Pol = vanredni.Pol;
            o.Naziv_Skole_Kursa = vanredni.NazivSkoleKursa;
            o.Datum_Sticanja_Diplome = vanredni.DatumSticanjaDiplome;
            o.Cin = vanredni.Cin;
            o.Datum_Sticanja_Cina = vanredni.DatumSticanjaCina;
            o.Naziv_Vestine = vanredni.Naziv_Vestine;
            o.Pohadjao_Kurs = vanredni.Pohadjao_Kurs;
            o.Poseduje_Sertifikat = vanredni.Poseduje_Sertifikat;
            o.Datum_Zavrsetka_Kursa = vanredni.Datum_Zavrsetka_Kursa;
            o.Datum_Sticanja_Sertifikata = vanredni.Datum_Sticanja_Sertifikata;

            await s.SaveOrUpdateAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće izmeniti vanrendog policajca.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public async static Task<Result<bool, string>> IzbrisiPolicajcaAsync(string jmbg)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policajac policajac = await s.LoadAsync<Policajac>(jmbg);
            await s.DeleteAsync(policajac);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Greška prilikom brisanja policajca.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public static Result<List<PolicijskaStanicaView>, string> VratiSveStanice()
    {
        ISession? s = null;

        List<PolicijskaStanicaView> stanice = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            IEnumerable<Policijska_stanica> sveStanice = from o in s.Query<Policijska_stanica>()
                                                    select o;

            foreach (Policijska_stanica st in sveStanice)
            {
                stanice.Add(new PolicijskaStanicaView(st));
            }
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve stanice.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return stanice;
    }
    public async static Task<Result<bool, string>> DodajStanicuAsync(PolicijskaStanicaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policijska_stanica o = new()
            {
                Naziv = p.Naziv,
                Adresa = p.Adresa,
                Broj_sluzbenih_vozila = p.BrojVozila,
                Opstina = p.Opstina,
                Datum_osnivanja = p.DatumOsnivanja
            };

            await s.SaveOrUpdateAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati stanicu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
    public async static Task<Result<PolicijskaStanicaView, string>> IzmeniStanicuAsync(PolicijskaStanicaView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policijska_stanica o = s.Load<Policijska_stanica>(p.ID);
            o.Naziv = p.Naziv;
            o.Adresa = p.Adresa;
            o.Broj_sluzbenih_vozila = p.BrojVozila;
            o.Opstina = p.Opstina;
            o.Datum_osnivanja = p.DatumOsnivanja;

            await s.UpdateAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati stanicu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }
    public async static Task<Result<bool, string>> IzbrisiStanicuAsync(int id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policijska_stanica o = await s.LoadAsync<Policijska_stanica>(id);

            await s.DeleteAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati stanicu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }


 public static async Task<Result<List<AlarmniSistemView>, string>>VratiSveSistemeAsync()
  {
        ISession? s = null;

        List<AlarmniSistemView> data = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

           
               data = (await s.QueryOver<Alarmni_sistem>().ListAsync())
                           .Select(p => new AlarmniSistemView(p)).ToList();
            
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve sisteme.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return data;
    }

    

    public async static Task<Result<bool, string>> DodajSistemAsync(AlarmniSistemView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Alarmni_sistem a = new()
            {
                 Serijski_Broj = p.Serijski_Broj,
                 Godina_Proizvodnje = p.Godina_Proizvodnje,
                 Model = p.Model,
                 Datum_Instalacije = p.Datum_Instalacije,
                 Datum_Poslednjeg_Atesta = p.Datum_Poslednjeg_Atesta,
                Datum_Poslednjeg_Servisa = p.Datum_Poslednjeg_Servisa,
                Opis_Poslednjeg_Kvara = p.Opis_Poslednjeg_Kvara,
                Tehnicko_Lice = p.Tehnicko_Lice,
                Pocetni_Datum = p.Pocetni_Datum,
                Poslednji_Datum = p.Poslednji_Datum
            };

            await s.SaveOrUpdateAsync(a);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati sistem.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    
     public async static Task<Result<AlarmniSistemView, string>> IzmeniSistemAsync(AlarmniSistemView p)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Alarmni_sistem a = s.Load<Alarmni_sistem>(p.Serijski_Broj);
              
                a.Godina_Proizvodnje = p.Godina_Proizvodnje;
                a.Model = p.Model;
                a.Datum_Instalacije = p.Datum_Instalacije;
                a.Datum_Poslednjeg_Atesta = p.Datum_Poslednjeg_Atesta;
                a.Datum_Poslednjeg_Servisa = p.Datum_Poslednjeg_Servisa;
                a.Opis_Poslednjeg_Kvara = p.Opis_Poslednjeg_Kvara;
                a.Tehnicko_Lice = p.Tehnicko_Lice;
                a.Pocetni_Datum = p.Pocetni_Datum;
                a.Poslednji_Datum = p.Poslednji_Datum;

            await s.UpdateAsync(a);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati sistem.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return p;
    }

     public async static Task<Result<bool, string>> IzbrisiSistemAsync(int Serijski_Broj)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Alarmni_sistem o = await s.LoadAsync<Alarmni_sistem>(Serijski_Broj);

            await s.DeleteAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati sistem";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

    
     public static async Task<Result<List<ObjekatView>, string>>VratiSveObjekteAsync()
  {
        ISession? s = null;

        List<ObjekatView> objekti = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            
               objekti = (await s.QueryOver<Objekat>().ListAsync())
                           .Select(p => new ObjekatView(p)).ToList();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve objekte.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return objekti;
    }
   
  public async static Task<Result<bool, string>> DodajObjekatAsync(ObjekatView o)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Objekat i = new()
            {
                    Id = o.Id,
                    Adresa = o.Adresa,
                    Tip = o.Tip,
                    Povrsina = o.Povrsina,
                    KontaktIme = o.KontaktIme,
                    KontaktPrezime = o.KontaktPrezime
            };

            await s.SaveOrUpdateAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati objekat.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

 public async static Task<Result<ObjekatView, string>> IzmeniObjekatAsync(ObjekatView o)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Objekat a = s.Load<Objekat>(o.Id);
              
               
                    a.Adresa = o.Adresa;
                    a.Tip = o.Tip;
                    a.Povrsina = o.Povrsina;
                    a.KontaktIme = o.KontaktIme;
                    a.KontaktPrezime = o.KontaktPrezime;

            await s.UpdateAsync(a);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati objekat.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return o;
    }

 public async static Task<Result<bool, string>> IzbrisiObjekatAsync(int Id)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Objekat o = await s.LoadAsync<Objekat>(Id);

            await s.DeleteAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati objekat";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }
 public static async Task<Result<List<PolicijskaIntervencijaView>, string>>VratiSveIntervencijeAsync()
  {
        ISession? s = null;

        List<PolicijskaIntervencijaView> intervencije = new();

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            
            
               intervencije = (await s.QueryOver<Policijska_intervencija>().ListAsync())
                           .Select(p => new PolicijskaIntervencijaView(p)).ToList();
        }
        catch (Exception)
        {
            return "Nemoguće vratiti sve intervnencije.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return intervencije;
    }

 public async static Task<Result<bool, string>> DodajIntervencijuAsync(PolicijskaIntervencijaView i)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policijska_intervencija c = new()
            {
                    Opis_Intervencije = i.Opis_Intervencije,
                    Datum_Intervencije = i.Datum_Intervencije,
                    Vreme_Intervencije = i.Vreme_Intervencije
            };

            await s.SaveOrUpdateAsync(c);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće dodati objekat.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }

public async static Task<Result<PolicijskaIntervencijaView, string>> IzmeniIntervencijuAsync(PolicijskaIntervencijaView i)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policijska_intervencija o = s.Load<Policijska_intervencija>(i.ID);
                    o.Opis_Intervencije = i.Opis_Intervencije;
                    o.Datum_Intervencije = i.Datum_Intervencije;
                    o.Vreme_Intervencije = i.Vreme_Intervencije;

            await s.UpdateAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće ažurirati stanicu.";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return i;
    }
public async static Task<Result<bool, string>> IzbrisiIntervencijuAsync(int ID)
    {
        ISession? s = null;

        try
        {
            s = DataLayer.GetSession();

            if (!(s?.IsConnected ?? false))
            {
                return "Nemoguće otvoriti sesiju.";
            }

            Policijska_intervencija o = await s.LoadAsync<Policijska_intervencija>(ID);

            await s.DeleteAsync(o);
            await s.FlushAsync();
        }
        catch (Exception)
        {
            return "Nemoguće obrisati intervenciju";
        }
        finally
        {
            s?.Close();
            s?.Dispose();
        }

        return true;
    }



}
