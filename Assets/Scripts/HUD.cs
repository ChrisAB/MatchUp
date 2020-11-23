using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
  public Level level;

  public GameObject Heroes;
  public GameObject Monsters;
  public GameObject RemainingTimeOrMoves;
  private TextMeshPro remainingText;
  private TextMeshPro remainingSubtext;

  private bool isGameOver = false;

  // Start is called before the first frame update
  void Start()
  {
    remainingText = RemainingTimeOrMoves.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
    remainingSubtext = RemainingTimeOrMoves.transform.GetChild(2).gameObject.GetComponent<TextMeshPro>();
    Debug.Log(remainingText);
    Debug.Log(remainingSubtext);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetHeroes(List<Hero> heroes)
  {

  }

  public void SetMonsters(List<Monster> monsters)
  {

  }

  public void SetHeroesHitPoints()
  {
    foreach (Transform hero in Heroes.transform)
    {
      Debug.Log(hero);
    }
  }

  public void SetMonstersHitPoints()
  {
    foreach (Transform monster in Monsters.transform)
    {
      Debug.Log(monster);
    }
  }

  public void SetRemaining(int remaining)
  {
    remainingText.text = remaining.ToString();
  }

  public void SetRemaining(string remaining)
  {
    remainingText.text = remaining;
  }

  public void SetLevelType(Level.LevelType type)
  {
    Debug.Log("Here");
    if (type == Level.LevelType.NORMAL)
    {
      RemainingTimeOrMoves.SetActive(false);
    }
    else if (type == Level.LevelType.SURVIVE_MOVES)
    {
      remainingSubtext.text = "Moves to survive";
    }
    else if (type == Level.LevelType.TIMER)
    {
      remainingSubtext.text = "Time left";
    }
  }

  public void OnGameWin()
  {
    isGameOver = true;
  }

  public void OnGameLose()
  {
    isGameOver = true;
  }
}
