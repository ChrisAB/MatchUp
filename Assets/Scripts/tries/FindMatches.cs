using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class FindMatches : MonoBehaviour
{
    private Board board;
    public List<GameObject> currentMatches = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    public void FindAllMatches(){
        StartCoroutine(FindAllMAtchesCo());
    }

    private IEnumerator FindAllMAtchesCo(){
        yield return new WaitForSeconds(.2f);
         for (int i=0; i< board.width; i++){
            for (int j =0; j<board.height; j++){
                GameObject currentTile = board.allGeneratedTiles[i,j];
                if(currentTile!= null){
                    if (i>0 && i<board.width-1){ //horizontal
                        GameObject leftTile = board.allGeneratedTiles[i-1,j];
                        GameObject rightTile = board.allGeneratedTiles[i+1,j];
                        if(leftTile!=null && rightTile!=null){
                            if(leftTile.tag == currentTile.tag && rightTile.tag == currentTile.tag){
                                if(currentTile.GetComponent<Tile>().isRowBomb ||
                                    leftTile.GetComponent<Tile>().isRowBomb ||
                                    rightTile.GetComponent<Tile>().isRowBomb){
                                        currentMatches.Union(GetRowPieces(j));
                                    } 
                                if(!currentMatches.Contains(leftTile)){
                                    currentMatches.Add(leftTile);
                                }
                                leftTile.GetComponent<Tile>().isMatched = true;
                                if(!currentMatches.Contains(rightTile)){
                                    currentMatches.Add(rightTile);
                                }
                                rightTile.GetComponent<Tile>().isMatched = true;
                                if(!currentMatches.Contains(currentTile)){
                                    currentMatches.Add(currentTile);
                                }
                                currentTile.GetComponent<Tile>().isMatched = true;
                            }
                        }
                    }

                     if (j>0 && j<board.height-1){ //horizontal
                        GameObject upTile = board.allGeneratedTiles[i,j+1];
                        GameObject downTile = board.allGeneratedTiles[i,j-1];
                        if(upTile!=null && downTile!=null){
                            if(upTile.tag == currentTile.tag && downTile.tag == currentTile.tag){
                                if(!currentMatches.Contains(upTile)){
                                    currentMatches.Add(upTile);
                                }
                                upTile.GetComponent<Tile>().isMatched = true;
                                if(!currentMatches.Contains(downTile)){
                                    currentMatches.Add(downTile);
                                }
                                downTile.GetComponent<Tile>().isMatched = true;
                                if(!currentMatches.Contains(currentTile)){
                                    currentMatches.Add(currentTile);
                                }
                                currentTile.GetComponent<Tile>().isMatched = true;
                            }
                        }
                    }
                }
            }
        }
    }

    List<GameObject> GetColumnPieces(int column){
        List<GameObject> tiles = new List<GameObject>();
        for (int i = 0; i< board.height; i++){
            if(board.allGeneratedTiles[column,i]!=null){
                tiles.Add(board.allGeneratedTiles[column,i]);
                board.allGeneratedTiles[column,i].GetComponent<Tile>().isMatched= true;
            }
        }
        return tiles;
    }

     List<GameObject> GetRowPieces(int row){
        List<GameObject> tiles = new List<GameObject>();
        for (int i = 0; i< board.width; i++){
            if(board.allGeneratedTiles[i,row]!=null){
                tiles.Add(board.allGeneratedTiles[i,row]);
                board.allGeneratedTiles[i,row].GetComponent<Tile>().isMatched= true;
            }
        }
        return tiles;
    }
}
