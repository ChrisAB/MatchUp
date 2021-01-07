using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //In case that tiles aren't correct indexes check for board to be at 0 0 0
    // Start is called before the first frame update
    [Header("Board variables")]
    public int col;
    public int  row;
    public int previousColumn, previousRow;
    public int targetX, targetY;
    public bool isMatched = false;

    private GameObject otherTile;
    private FindMatches findMatches;
    private Board board;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    public float swipeAngle = 0;
    public float swipeResist = 1f;
    public float swipeMax = 2f;

    [Header("PwerUp")]
    public bool isColBomb, isRowBomb;
    public GameObject rowArrow, colArrow;

    void Start()
    {
        isColBomb =false;
        isRowBomb=false;

        board = FindObjectOfType<Board>();
        findMatches = FindObjectOfType<FindMatches>();
        /*
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        
        row=targetY;
        col=targetX;
        previousColumn=col;
        previousRow=row;*/
    }

    //Debug
    private void OnMouseOver(){
        if(Input.GetMouseButtonDown(1)){
            isColBomb = true;
            GameObject arrow = Instantiate(rowArrow, transform.position, Quaternion.identity);
            arrow.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //FindMatches();
        
        if (isMatched==true){
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(102,45,145,.2f);
        }
        targetX=col;
        targetY=row;
        try{
            if(Mathf.Abs(targetX-transform.position.x) > .1){ //horizontal
                //Move to the target
                tempPosition = new Vector2(targetX,transform.position.y);
                transform.position = Vector2.Lerp(transform.position, tempPosition, .6f);
                if (board.allGeneratedTiles[col,row]!= this.gameObject){
                    board.allGeneratedTiles[col,row] = this.gameObject;
                }
                findMatches.FindAllMatches();
            }else{
                //Directly set position
                tempPosition = new Vector2(targetX,transform.position.y);
                transform.position = tempPosition;
            }

            if(Mathf.Abs(targetY-transform.position.y) > .1){//vertical
                //Move to the target
                tempPosition = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.Lerp(transform.position, tempPosition, .6f);
                 if (board.allGeneratedTiles[col,row]!= this.gameObject){
                    board.allGeneratedTiles[col,row] = this.gameObject;
                }
                findMatches.FindAllMatches();
            }else{
                //Directly set position
                tempPosition = new Vector2(transform.position.x, targetY);
                transform.position = tempPosition;
            }
        }catch(System.IndexOutOfRangeException e){
            Debug.Log ("Out of range happened");
        }
    }

    public IEnumerator CheckMoveCo(){
        yield return new WaitForSeconds(.4f);
        if (otherTile!=null){
            if(!isMatched && !otherTile.GetComponent<Tile>().isMatched){
                otherTile.GetComponent<Tile>().row = row;
                otherTile.GetComponent<Tile>().col = col;
                row = previousRow;
                col = previousColumn;
                yield return new WaitForSeconds(.5f);
                board.currentState = GameState.MOVE;
            }else{
                board.DestroyMatches();
            }
            otherTile = null;
        }
    }

    private void OnMouseDown(){ //presed
        if(board.currentState == GameState.MOVE){
            firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

    }

    private void OnMouseUp(){ //released
        if(board.currentState == GameState.MOVE){
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CalculateAngle();
        }
    }

    void CalculateAngle(){
        if (Mathf.Abs(finalTouchPosition.y-firstTouchPosition.y) > swipeResist || 
            Mathf.Abs(finalTouchPosition.x-firstTouchPosition.x) > swipeResist )            {
            swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x ) * 180/Mathf.PI;
            //Debug.Log(swipeAngle);
            try {
                MovePieces();
                board.currentState = GameState.WAIT;
            }catch(System.IndexOutOfRangeException e){
                Debug.Log ("Out of range happened");
            }
        }else {
            board.currentState = GameState.MOVE;
        }
    }
    void MovePieces(){
        previousColumn=col;
        previousRow=row;

        if(swipeAngle > -45 && swipeAngle <= 45 && col<board.width-1){ // Right
            otherTile = board.allGeneratedTiles[col +1, row];
            otherTile.GetComponent<Tile>().col -=1;
            col+=1;
        }else if(swipeAngle > 45 && swipeAngle <= 135 && row<board.height-1){ // UP
            otherTile = board.allGeneratedTiles[col, row+1];
            otherTile.GetComponent<Tile>().row -=1;
            row+=1;
        }else if((swipeAngle > 135 || swipeAngle <= -135) && col>0){ // LEFT
            otherTile = board.allGeneratedTiles[col - 1, row];
            otherTile.GetComponent<Tile>().col +=1;
            col-=1;
        }else if(swipeAngle > -135 && swipeAngle <= -45 && row>0 ){ // DOWN
            otherTile = board.allGeneratedTiles[col, row-1];
            otherTile.GetComponent<Tile>().row +=1;
            row-=1;
        }
        StartCoroutine(CheckMoveCo());

    }
    void FindMatches(){
        if(col>0 && col<board.width-1){ //horizontal match
            GameObject leftTile1 = board.allGeneratedTiles[col-1,row];
            GameObject rightTile1 = board.allGeneratedTiles[col+1,row];
            if (leftTile1 != null && rightTile1 != null){
                if((leftTile1.tag == this.gameObject.tag) && (rightTile1.tag == this.gameObject.tag)){
                    leftTile1.GetComponent<Tile>().isMatched = true;
                    rightTile1.GetComponent<Tile>().isMatched = true;
                    isMatched=true;
                }
            }
        }
        if(row > 0 && row < board.height-1){//vertical match
            GameObject upTile1 = board.allGeneratedTiles[col,row+1];
            GameObject downTile1 = board.allGeneratedTiles[col,row-1];
            if (upTile1 != null && downTile1 != null){
                if((upTile1.tag == this.gameObject.tag) && (downTile1.tag == this.gameObject.tag)){
                    upTile1.GetComponent<Tile>().isMatched = true;
                    downTile1.GetComponent<Tile>().isMatched = true;
                    isMatched=true;
                }
            }
        }
    }

}
