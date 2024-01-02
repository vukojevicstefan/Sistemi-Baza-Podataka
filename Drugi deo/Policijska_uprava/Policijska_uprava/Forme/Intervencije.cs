using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policijska_uprava.Forme
{
    public partial class Intervencije : Form
    {
        public Intervencije()
        {
            InitializeComponent();
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {


            listView1.Items.Clear();
            List<IntervencijaBasic> podaci = DTOManager.GetIntervencijaBasic();



            foreach (IntervencijaBasic p in podaci)
            {
              ListViewItem item = new ListViewItem(new string[] { p.ID.ToString(), p.Opis_Intervencije.ToString(), p.Datum_Intervencije.ToString(), p.Vreme_Intervencije });

               listView1.Items.Add(item);

            }

            listView1.Refresh();
        }
    }
}
