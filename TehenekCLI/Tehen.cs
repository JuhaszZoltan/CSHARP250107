﻿namespace TehenekCLI;

class Tehen : IEquatable<Tehen>
{
    public string Id { get; private set; }
    public int[] Mennyisegek { get; private set; }

    public bool Equals(Tehen masik)
    {
        return masik != null && masik.Id == this.Id;
    }

    public void EredmenytRogzit(string nap, string menyiseg)
    {
        Mennyisegek[int.Parse(nap)] = int.Parse(menyiseg);
    }

    public int HetiTej => Mennyisegek.Sum();

    public int HetiAtlag =>
        Mennyisegek.Count(x => x > 0) >= 3
            ? (int)Math.Round(HetiTej / (double)Mennyisegek.Count(x => x > 0))
            : -1;

    public Tehen(string id)
    {
        Id = id;
        Mennyisegek = new int[7];
    }
}
