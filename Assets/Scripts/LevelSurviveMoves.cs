using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSurviveMoves : Level
{
  public int numMoves;

  private int movesUsed = 0;

  // Start is called before the first frame update
  void Start()
  {
    type = LevelType.SURVIVE_MOVES;
    hud.SetLevelType(type);
    hud.SetRemaining(numMoves);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public override void OnMove()
  {
    movesUsed++;

    hud.SetRemaining(numMoves - movesUsed);
    if (numMoves - movesUsed == 0)
    {
      GameWin();
    }
  }
}
