using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoard : MonoBehaviour
{
  public int width;

  public GameObject monsterPrefab;
  public GameObject[] monsters;
  public GameObject[] allGeneratedMonsters;
  private static ArrayList usedIndexes = new ArrayList();
  private MonsterTile[] allMonsters;
  // Start is called before the first frame update
  void Start()
  {
    allMonsters = new MonsterTile[width];
    allGeneratedMonsters = new GameObject[width];
    SetUp();
  }


  // Update is called once per frame
  void Update()
  {

  }

  private void SetUp()
  {
    for (int i = 0; i < width; i++)
    {
      Vector2 tempPosition = new Vector2((i - 0.5f) * 2.5f, 12);
      //what we instantiate, position , rotation
      GameObject backgroundTile = Instantiate(monsterPrefab, tempPosition, Quaternion.identity) as GameObject;
      backgroundTile.transform.parent = this.transform; //change parent to board
      backgroundTile.name = "Monster" + i;

      int monsterToUse = getMonsterIndex();

      // tile prefab from array , where the background tile is 
      GameObject monsterTile = Instantiate(monsters[monsterToUse], tempPosition, Quaternion.identity);
      monsterTile.transform.parent = this.transform; // tile child of background tile
      monsterTile.name = "Monster" + i;

      allGeneratedMonsters[i] = monsterTile;
      allMonsters[i] = monsterTile.GetComponent<MonsterTile>();
    }

  }

  private int getMonsterIndex()
  {
    int idx = Random.Range(0, monsters.Length);
    if (checkindex(idx) == 0)
    {
      usedIndexes.Add(idx);
      return idx;
    }
    return getMonsterIndex();
  }

  private int checkindex(int index)
  {
    if (usedIndexes.Contains(index)) return 1;
    return 0;
  }

  public void TakeDamage(int damageToTake)
  {
    foreach (MonsterTile monster in allMonsters)
    {
      monster.TakeDamage(damageToTake / allMonsters.Length);
    }
  }

  public int KillAndRespawnMonsters()
  {
    int numberOfMonstersKilled = 0;
    for (int i = 0; i < allMonsters.Length; i++)
    {
      if (!allMonsters[i].IsAlive())
      {
        numberOfMonstersKilled++;
        Destroy(allGeneratedMonsters[i]);
        usedIndexes.Remove(i);
        Vector2 tempPosition = new Vector2((i - 0.5f) * 2.5f, 12);

        int monsterToUse = getMonsterIndex();

        // tile prefab from array , where the background tile is 
        GameObject monsterTile = Instantiate(monsters[monsterToUse], tempPosition, Quaternion.identity);
        monsterTile.transform.parent = this.transform; // tile child of background tile
        monsterTile.name = "Monster" + i;

        allGeneratedMonsters[i] = monsterTile;
        allMonsters[i] = monsterTile.GetComponent<MonsterTile>();
      }
    }
    return numberOfMonstersKilled;
  }

  public int getTurnDamage()
  {
    int totalDamage = 0;
    foreach (var monster in allMonsters)
    {
      totalDamage += monster.GetDamage();
    }

    return totalDamage;
  }
}
