namespace CATAGY_FIFA
{
    internal partial class Program
    {
        class Csapat
        {
            public string Nev { get; set; }
            public int ReszvetelekSzama { get; set; }
            public int ElsoReszvetel { get; set; }
            public int LegutobbiReszvetel { get; set; }
            public string LegjobbEredmeny { get; set; }

            public Csapat(string sor)
            {
                var buff = sor.Split(';');
                Nev = buff[0];
                ReszvetelekSzama = int.Parse(buff[1]);
                ElsoReszvetel = int.Parse(buff[2]);
                LegutobbiReszvetel = int.Parse(buff[3]);
                LegjobbEredmeny = buff[4];
            }
        }
    }
}
