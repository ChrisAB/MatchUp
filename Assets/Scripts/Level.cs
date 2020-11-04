using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

  public enum LevelType
  {
    NORMAL,
    TIMER,
    MOVES,
  }

  public Grid grid;

  protected List<Monster> monsters;
  protected List<Hero> heroes;

  protected LevelType level;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public virtual void GameWin()
  {
    grid.GameOver();
    Debug.Log("You win");
  }

  public virtual void GameLose()
  {
    grid.GameOver();

    Debug.Log("You lose");
  }

  public virtual void OnMove()
  {
    for (int i = 0; i < monsters.Count; i++)
      monsters[i].DoDamage(heroes);
  }

  public virtual void OnPiecesMatch(List<GamePiece> pieces)
  {
    //Remove HP Of Monster
    //Remove HP Of Player if Monser attacks
  }
}
