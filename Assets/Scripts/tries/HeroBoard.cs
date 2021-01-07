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

    private Dictionary<HeroType, int> numberOfMatches = new Dictionary<HeroType, int>() {
        {HeroType.DARKNESS,0},
        {HeroType.WATER,0},
        {HeroType.ICE,0},
		{HeroType.FIRE,0},
        {HeroType.STONE,0},
        {HeroType.ELECTRO,0},
        {HeroType.NORMAL,0}
    };

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
                allHeroes[i] = heroTile.GetComponent<HeroTile>();
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

    public void AccumulateDamage(GameObject pieceObject) {
        Tile tile = pieceObject.GetComponent<Tile>();
        numberOfMatches[tile.ConvertTagToHeroType()]++;
    }

    public int CalculateTypeDamage(HeroType type) {
        int damage = 0;
        foreach (HeroTile item in allHeroes)
        {
            if(item.heroType == type) {
                damage += numberOfMatches[type] * 2;
            } else if(item.heroType == HeroType.NORMAL) {
                damage += numberOfMatches[type];
            }
        }
        return damage;
    }

    public Dictionary<HeroType,int> CalculateTotalDamage() {
        Dictionary<HeroType, int> totalDamage = new Dictionary<HeroType, int>() {
            {HeroType.DARKNESS,0},
            {HeroType.WATER,0},
            {HeroType.ICE,0},
	    	{HeroType.FIRE,0},
            {HeroType.STONE,0},
            {HeroType.ELECTRO,0},
            {HeroType.NORMAL,0}
        };

        foreach (KeyValuePair<HeroType, int> item in numberOfMatches)
        {
            totalDamage[item.Key] += CalculateTypeDamage(item.Key);
            numberOfMatches[item.Key] = 0;
        }
        return totalDamage;
    }
}
