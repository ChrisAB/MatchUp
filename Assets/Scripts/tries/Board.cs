using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    WAIT,
    MOVE
}

public class Board : MonoBehaviour
{
    public GameManager GameManager;
    public GameState currentState = GameState.MOVE;
    private FindMatches findMatches;
    public int width;
    public int height;
    public int offSet;
    public GameObject tilePrefab;
    public GameObject[] tiles;
    public GameObject[,] allGeneratedTiles;
    public Tile currentTile;
    private BackgroundTile[,] allTiles;
    private HeroBoard heroBoard;
    private MonsterBoard monsterBoard;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allGeneratedTiles = new GameObject[width,height];
        findMatches = FindObjectOfType<FindMatches>();
        heroBoard = FindObjectOfType<HeroBoard>();
        monsterBoard = FindObjectOfType<MonsterBoard>();
        GameManager = FindObjectOfType<GameManager>();
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
                Vector2 tempPosition = new Vector2(i, j + offSet);
                //what we instantiate, position , rotation
                Vector2 bgTiletempPosition = new Vector2(i, j);
                GameObject backgroundTile = Instantiate(tilePrefab, bgTiletempPosition, Quaternion.identity) as GameObject;
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
                tile.GetComponent<Tile>().row = j;
                tile.GetComponent<Tile>().col = i;
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
            heroBoard.AccumulateDamage(allGeneratedTiles[col,row]);

            if(findMatches.currentMatches.Count == 4 ||
                findMatches.currentMatches.Count == 7){
                    findMatches.CheckBombs();
            }

            findMatches.currentMatches.Remove(allGeneratedTiles[col,row]);
            Destroy(allGeneratedTiles[col,row]);
            allGeneratedTiles[col,row] = null;
        }
    }

    public void DoDamageToMonsters(Dictionary<HeroType,int> totalDamage) {
        return;
    }

    public void DestroyMatches(){
        int numberOfPiecesDestroyed = 0;
        for (int i=0; i<width; i++){
            for (int j=0; j<height; j++){
                if(allGeneratedTiles[i,j] != null){
                    numberOfPiecesDestroyed++;
                    DestroyMatchesAt(i,j);
                }
            }
        }
        if(numberOfPiecesDestroyed >= 3) {
            var damage = heroBoard.CalculateTotalDamage();
            monsterBoard.TakeDamage(SumDamageTypes(damage));
            int monstersKilled = monsterBoard.KillAndRespawnMonsters();
            heroBoard.TakeDamage(25);
            if(!heroBoard.AreAllAlive()) {
                GameManager.LoseGame();
            }
            if(monstersKilled > 0) {
                heroBoard.HealAll(10 * monstersKilled);
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
        yield return new WaitForSeconds(.3f);
        StartCoroutine(FillBoardCo());
        
    }

    private void RefillBoard(){
        for (int i = 0; i < width; i ++){
            for (int j = 0; j < height; j ++){
                if (allGeneratedTiles[i,j] == null){
                    Vector2 tempPosition = new Vector2(i,j+offSet);
                    int tileToUse = Random.Range(0,tiles.Length);
                    GameObject piece = Instantiate(tiles[tileToUse], tempPosition, Quaternion.identity);
                    piece.transform.parent = this.transform;

                    allGeneratedTiles[i,j] = piece;
                    piece.GetComponent<Tile>().row = j;
                    piece.GetComponent<Tile>().col = i;
                    piece.GetComponent<Tile>().name = "(" + i + ","+ j + ")";
                }
            }
        }
    }

    private bool MatchesOnBoard(){
        for (int i = 0; i < width; i ++){
            for (int j = 0; j < height; j ++){
                if (allGeneratedTiles[i,j] != null){
                    if(allGeneratedTiles[i,j].GetComponent<Tile>().isMatched){
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private IEnumerator FillBoardCo(){
        RefillBoard();
        yield return new  WaitForSeconds(.5f);
        while(MatchesOnBoard()){
            yield return new WaitForSeconds(.0f);
            DestroyMatches();
        }
        findMatches.currentMatches.Clear();
        currentTile = null;
        yield return new WaitForSeconds(.5f);
        currentState=GameState.MOVE;
    }


    private int SumDamageTypes(Dictionary<HeroType, int> damageDict) {
        int totalDamage = 0;
        foreach (var item in damageDict)
        {
            totalDamage+= item.Value;
        }
        return totalDamage;
    }
}
