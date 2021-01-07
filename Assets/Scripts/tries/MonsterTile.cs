using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTile : MonoBehaviour
{
  public int damage;
  private int maxHP;
  private int HP;
  // Start is called before the first frame update
  void Start()
  {
    maxHP = 100;
    HP = maxHP;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public int GetDamage()
  {
    return damage;
  }

  public void TakeDamage(int damagaToTake)
  {
    HP -= damagaToTake;
    Debug.Log("I have " + HP.ToString() + " HP left");
  }

  public bool IsAlive()
  {
    return HP > 0 ? true : false;
  }
}
