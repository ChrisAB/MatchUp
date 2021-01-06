using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public int width;
    
    public GameObject heroPrefab;
    public GameObject[] heroes;
    public GameObject[] allGeneratedHeroes;
    private static ArrayList usedIndexes = new ArrayList();
    private HeroTile[] allHeroes;
    void Start()
    {
        allHeroes = new HeroTile[width];
        allGeneratedHeroes = new GameObject[width];
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetUp()
    {
        for (int i=0; i< width; i++)
            {
                Vector2 tempPosition = new Vector2((i-0.5f)*2.5f, -2);
                //what we instantiate, position , rotation
                GameObject backgroundTile = Instantiate(heroPrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform; //change parent to board
                backgroundTile.name = "Hero"+ i;

                int heroToUse = getHeroIndex();
        
                // tile prefab from array , where the background tile is 
                GameObject heroTile = Instantiate(heroes[heroToUse], tempPosition, Quaternion.identity);
                heroTile.transform.parent = this.transform; // tile child of background tile
                heroTile.name = "Hero"+ i;
                
                allGeneratedHeroes[i] = heroTile;
            
            }
        
    }
    private int getHeroIndex(){
        int idx = Random.Range(0,heroes.Length);
        if (checkindex(idx)==0) 
            {
                usedIndexes.Add(idx);
                return idx;
            }
        return  getHeroIndex();

    }
    private int checkindex(int index){
        if (usedIndexes.Contains(index)) return 1;
        return 0;
    }
}
