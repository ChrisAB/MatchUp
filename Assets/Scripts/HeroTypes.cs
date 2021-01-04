using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HeroTypes : MonoBehaviour
{
    public enum HeroType
	{
		SOLDIER,
        WITCH,
        WARLOCK,
        KITSUNE,
        ROME	
	};
    
    public enum PowerType
	{
		ICE,
        FIRE,
        HEALING,
        DARKNESS,
        STONE,
        WATER,
        NORMAL,
        ELECTRO
	};
    
    /*
    public int Herohealth;
    private int ultimateBarCharge;
    private int name;*/

    [System.Serializable]
    public struct HeroSprite
	{
		public HeroType heroType;
        public PowerType powerType;
        public string name;
        public int maxHealthPoints;
        public HeroDtails heroDetails;
		public Sprite sprite;
	};

    public HeroSprite[] heroSpites;
    public HeroDtails newHeroDetailsAux;


	public HeroType HeroTypeVar
	{
		get { return newHeroDetailsAux.HT; }
		set { SetHeroType (value); }
	}
    public PowerType PowerTypeVar
	{
		get { return newHeroDetailsAux.PT; }
		set { SetPowerType (value); }
	}
     public string NameHero
	{
		get { return newHeroDetailsAux.Name; }
		set { SetHeroName (value); }
	}
    public int MaxHP
	{
		get { return newHeroDetailsAux.MHP; }
		set { SetMHP (value); }
	}
    
    /*
    public int NumHeroTypes
	{
		get { return name.Length; }
	}*/

        
    public struct HeroDtails{

        public HeroType HT;
        public PowerType PT;
        public string Name;
        public int MHP;

        /*
        public HeroDtails(HeroType heroType, PowerType powerType, string name, int maxHealthPoints){
            HT = heroType;
            PT = powerType;
            Name = name;
            MHP = maxHealthPoints;
        }*/

    }

    public HeroDtails HeroDtailsVar{
        get { return newHeroDetailsAux; }
        set { SetHeroDetails (newHeroDetailsAux); }
    }

	private SpriteRenderer sprite;
	private Dictionary<HeroDtails, Sprite> heroTypeSpriteDict;

    void Awake()
	{
		sprite = transform.Find ("piece").GetComponent<SpriteRenderer> ();

		heroTypeSpriteDict = new Dictionary<HeroDtails, Sprite> ();

		for (int i = 0; i < heroSpites.Length; i++) {
			if (!heroTypeSpriteDict.ContainsKey (heroSpites [i].heroDetails)) {
				heroTypeSpriteDict.Add (heroSpites[i].heroDetails, heroSpites [i].sprite);
			}
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetHeroType(HeroType newHeroType)
	{
        newHeroDetailsAux.HT = newHeroType;

		//if (heroTypeSpriteDict.ContainsKey (newHeroType)) {
		//	sprite.sprite = heroTypeSpriteDict [newHeroType];
		//}
    }
    public void SetPowerType( PowerType newPowerType)
	{
        newHeroDetailsAux.PT = newPowerType;
	}
    public void SetHeroName( string hname)
	{
        newHeroDetailsAux.Name = hname;
	}
    public void SetMHP( int mhp)
	{
        newHeroDetailsAux.MHP = mhp;
	}

    

    public void SetHeroDetails(HeroDtails newHeroDetails)
	{
		newHeroDetailsAux = newHeroDetails;

		if (heroTypeSpriteDict.ContainsKey (newHeroDetails)) {
			sprite.sprite = heroTypeSpriteDict [newHeroDetails];
		}
	}

    public void Init(HeroType nheroType, PowerType npowerType, string nname, int nmaxHealthPoints){
        newHeroDetailsAux.HT = nheroType;
        newHeroDetailsAux.PT = npowerType;
        newHeroDetailsAux.Name = nname;
        newHeroDetailsAux.MHP = nmaxHealthPoints;
    }

    public HeroDtails HeroDetailsAux{
        get {return newHeroDetailsAux;}
    }
}
