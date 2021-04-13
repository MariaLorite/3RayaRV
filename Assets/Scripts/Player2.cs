using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    protected override void Saludar()
    {
        print("No me agradas >:c");
    }

    protected override void Despedir()
    {
        base.Despedir();
        print("Dame un dulce");
    }
}
