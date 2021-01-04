using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

  public enum LevelType
  {
    NORMAL,
    TIMER,
    SURVIVE_MOVES,
  }

  public Grid grid;
  public HUD hud;

  protected List<Monster> monsters;
  protected List<Hero> heroes;

  protected LevelType type;

  //public Hero heroPrefab;

  // Start is called before the first frame update
  void Start()
  {
    hud.SetMonsters(monsters);
    hud.SetHeroes(heroes);
    hud.SetLevelType(LevelType.NORMAL);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public virtual void GameWin()
  {
    grid.GameOver();
    hud.OnGameWin();
    Debug.Log("You win");
  }

  public virtual void GameLose()
  {
    grid.GameOver();
    hud.OnGameLose();
    Debug.Log("You lose");
  }

  public virtual void OnMove()
  {/*
    for (int i = 0; i < monsters.Count; i++)
      monsters[i].DoDamage(heroes);*/
  }

  public virtual void OnPiecesMatch(List<GamePiece> pieces)
  {
    //Remove HP Of Monster
    //Remove HP Of Player if Monser attacks
  }
  /*
  public Hero spawnHero()
  {
    GameObject newHero = (GameObject)Instantiate( Quaternion.identity);
    newPiece.transform.parent = transform;
    
    auxHero = newHero.GetComponent<Hero>();
    heroes.add(auxHero);

    return auxHero;
  }*/
}
