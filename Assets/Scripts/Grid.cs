using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{

  public enum PieceType
  {
    EMPTY,
    NORMAL,
    COUNT,
  };

  [System.Serializable]
  public struct PiecePrefab
  {
    public PieceType type;
    public GameObject prefab;
  };

  public int xDim;
  public int yDim;

  public PiecePrefab[] piecePrefabs;
  public GameObject backgroundPrefab;

  private Dictionary<PieceType, GameObject> piecePrefabDict;

  private GamePiece[,] pieces;

  // Use this for initialization
  void Start()
  {
    piecePrefabDict = new Dictionary<PieceType, GameObject>();

    for (int i = 0; i < piecePrefabs.Length; i++)
    {
      if (!piecePrefabDict.ContainsKey(piecePrefabs[i].type))
      {
        piecePrefabDict.Add(piecePrefabs[i].type, piecePrefabs[i].prefab);
      }
    }

    for (int x = 0; x < xDim; x++)
    {
      for (int y = 0; y < yDim; y++)
      {
        GameObject background = (GameObject)Instantiate(backgroundPrefab, GetWorldPosition(x, y), Quaternion.identity);
        background.transform.parent = transform;
      }
    }

    pieces = new GamePiece[xDim, yDim];
    for (int x = 0; x < xDim; x++)
    {
      for (int y = 0; y < yDim; y++)
      {
        SpawnNewPiece(x, y, PieceType.EMPTY);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  public Vector2 GetWorldPosition(int x, int y)
  {
    return new Vector2(transform.position.x - xDim / 2.0f + x,
      transform.position.y + yDim / 2.0f - y);
  }

  public void Fill()
  {

  }

  public bool FillStep()
  {
    bool movedPiece = false;

    for (int y = yDim - 2; y >= 0; y--)
    {
      for (int x = 0; x < xDim; x++)
      {
        GamePiece piece = pieces[x, y];
        if (piece.IsMovable())
        {
          GamePiece pieceBelow = pieces[x, y + 1];
          if (pieceBelow.Type == PieceType.EMPTY)
          {
            piece.MovableComponent.Move(x, y + 1);
            pieces[x, y + 1] = piece;
            SpawnNewPiece(x, y, PieceType.EMPTY);
            movedPiece = true;
          }
        }
      }
    }

    for (int x = 0; x < xDim; x++)
    {
      GamePiece pieceBelow = pieces[x, 0];

      if (pieceBelow.Type == PieceType.EMPTY)
      {
        GameObject newPiece = (GameObject)Instantiate(piecePrefabDict[PieceType.NORMAL], GetWorldPosition(x, -1), Quaternion.identity);
        newPiece.transform.parent = transform;

        pieces[x, 0] = newPiece.GetComponent<GamePiece>();
        pieces[x, 0].Init(x, -1, this, PieceType.NORMAL);
        pieces[x, 0].MovableComponent.Move(x, 0);
        pieces[x, 0].MaterialComponent.SetMaterial((MaterialPiece.MaterialType)Random.Range(0, pieces[x, 0].MaterialComponent.NumMaterials));
        movedPiece = true;
      }
    }

    return movedPiece;
  }

  public GamePiece SpawnNewPiece(int x, int y, PieceType type)
  {
    GameObject newPiece = (GameObject)Instantiate(piecePrefabDict[type], GetWorldPosition(x, y), Quaternion.identity);
    newPiece.transform.parent = transform;

    pieces[x, y] = newPiece.GetComponent<GamePiece>();
    pieces[x, y].Init(x, y, this, type);

    return pieces[x, y];
  }
}
