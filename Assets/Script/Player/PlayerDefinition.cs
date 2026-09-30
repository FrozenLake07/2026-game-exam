
using UnityEngine;

public class PlayerDefinition : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerSpeed=5;
    public int PlayerHP = 10;

    public int hp;
    public int PlayerDamage = 50;

    public float cd=2;

    public float lastingtime = 1;
    public int BloodSucking = 0;
    public int StrongHeart = 0;

    public bool Anger=false;

    public int Strength=0;

    public bool Faster=false;

    public int FastShoe=0;

    public bool Defence=false;
}
