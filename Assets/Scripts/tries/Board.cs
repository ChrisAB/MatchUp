using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    public GameObject[] tiles;
    public GameObject[,] allGeneratedTiles;
    private BackgroundTile[,] allTiles;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allGeneratedTiles = new GameObject[width,height];
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void SetUp()
    {
        for (int i=0; i< width; i++)
            for (int j =0; j<height; j++){
                Vector2 tempPosition = new Vector2(i,j);
                //what we instantiate, position , rotation
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform; //change parent to board
                backgroundTile.name = "BG:(" + i + ","+ j + ")";
            
                int tileToUse = Random.Range(0,tiles.Length);
                
                int maxIter = 0;
                while (MatchesAt(i,j,tiles[tileToUse]) && maxIter < 100){
                    tileToUse = Random.Range(0,tiles.Length);
                    maxIter++;
                }
                maxIter=0;

                // tile prefab from array , where the background tile is 
                GameObject tile = Instantiate(tiles[tileToUse], tempPosition, Quaternion.identity);
                tile.transform.parent = this.transform; // tile child of background tile
                tile.name = "(" + i + ","+ j + ")";

                allGeneratedTiles[i,j] = tile;
            }
        
    }

    private bool MatchesAt(int col, int row, GameObject piece){
        if (col > 1 && row > 1){
            if (allGeneratedTiles[col-1,row].tag == piece.tag && 
                allGeneratedTiles[col-2,row].tag == piece.tag ){
                    return true;
            }
            if (allGeneratedTiles[col,row-1].tag == piece.tag && 
                allGeneratedTiles[col,row-2].tag == piece.tag ){
                    return true;
            }
        }else if(col <= 1 ||  row <= 1){
            if (row >1){
                if (allGeneratedTiles[col,row-1].tag == piece.tag && 
                    allGeneratedTiles[col,row-2].tag == piece.tag){
                        return true;
                    }
            }else if (col >1){
                if (allGeneratedTiles[col-1,row].tag == piece.tag && 
                    allGeneratedTiles[col-2,row].tag == piece.tag){
                        return true;
                }
            }
        }
        
        return false;
    }

    private void DestroyMatchesAt(int col, int row){
        if (allGeneratedTiles[col,row].GetComponent<Tile>().isMatched){
            Destroy(allGeneratedTiles[col,row]);
            allGeneratedTiles[col,row] = null;
        }
    }

    public void DestroyMatches(){
        for (int i=0; i<width; i++){
            for (int j=0; j<height; j++){
                if(allGeneratedTiles[i,j] != null){
                    DestroyMatchesAt(i,j);
                }
            }
        }
        StartCoroutine(DecreaseRowCo());
    }

    private IEnumerator DecreaseRowCo(){
        /*
        for (int i=0; i< width; i++){ 
            for (int j=0; j<height; j++){
                if(allGeneratedTiles[i,j] == null){
                    for (int k = j+1; k < height; k++){
                        if(allGeneratedTiles[i,k] != null){
                            allGeneratedTiles[i,k].GetComponent<Tile>().row -= 1;
                            allGeneratedTiles[i, k] = null;
                        }
                    }
                }
            }
        }*/
        int nullCount = 0;
        for (int i = 0; i < width; i ++){
            for (int j = 0; j < height; j ++){
                if(allGeneratedTiles[i, j] == null){
                    nullCount++;
                }else if(nullCount > 0){
                    allGeneratedTiles[i, j].GetComponent<Tile>().row -= nullCount;
                    allGeneratedTiles[i, j] = null;
                }
            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.6f);
        
    }

    

}
