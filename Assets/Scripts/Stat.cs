using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public Elemental elemental;
    public int amount;

    public Stat(Elemental elemental, int amount)
    {
        this.elemental = elemental;
        this.amount = amount;
    }
}
