using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroType
{
    DARKNESS,
    WATER,
    ICE,
	FIRE,
    STONE,
    ELECTRO,
    NORMAL,
};

public class HeroTile : MonoBehaviour
{
    

    public HeroType heroType;

    private int maxHP;
    private int HP;
    private int maxMP;
    private int MP;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize(){
        maxHP = 100;
        HP = maxHP;
        maxMP = 100;
        MP = 0;
    }

    public bool IsAlive() {
        return HP > 0 ? true : false;
    }

    public void LoseHP(int HPToLose) {
        HP -= HPToLose;
    }

    public void TakeDamage(int damageToTake) {
        HP -= damageToTake;
    }

    public void RegenerateHP(int HPToRegenerate) {
        HP += HPToRegenerate;
        if(HP > maxHP) HP = maxHP;
    }

    public void RegenerateMP(int MPToRegenerate) {
        MP += MPToRegenerate;
    }

    public bool CanUseUltimate() {
        return MP == 100 ? true : false;
    }

    public void UseUltimate() {
        MP = 0;
    }
}
