using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Fishes;
    public int startFishes;

    public static int Rounds;
    public int _rounds;

    private void Start()
    {
        Money = startMoney;
        Fishes = startFishes;
        Rounds = _rounds;
    }
}
