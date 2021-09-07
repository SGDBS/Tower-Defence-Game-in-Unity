using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int money;
    public static int life;
    public int startMoney = 250;
    public int startLife = 20;
    public static int rounds;

    void Start() {
        money = startMoney;
        life = startLife;
        rounds = 0;
    }
}
