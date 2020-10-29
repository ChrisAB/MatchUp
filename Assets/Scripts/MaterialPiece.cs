using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPiece : MonoBehaviour
{

  public enum MaterialType
  {
    HERB,
    POTION,
    SPELLBOOK,
    CRYSTAL,
    SPECIALSTONE,
    ARTIFACT,
    ANY,
    COUNT
  }

  [System.Serializable]
  public struct MaterialSprite
  {
    public MaterialType material;
    public Sprite sprite;
  }

  public int NumMaterials
  {
    get { return materialSprites.Length; }
  }

  public MaterialSprite[] materialSprites;

  private Dictionary<MaterialType, Sprite> materialSpriteDict;

  private MaterialType material;

  public MaterialType Material
  {
    get { return material; }
    set { SetMaterial(value); }
  }

  private SpriteRenderer sprite;

  void Awake()
  {
    sprite = transform.Find("piece").GetComponent<SpriteRenderer>();

    materialSpriteDict = new Dictionary<MaterialType, Sprite>();
    for (int i = 0; i < materialSprites.Length; i++)
    {
      if (!materialSpriteDict.ContainsKey(materialSprites[i].material))
      {
        materialSpriteDict.Add(materialSprites[i].material, materialSprites[i].sprite);
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

  public void SetMaterial(MaterialType newMaterial)
  {
    material = newMaterial;
    if (materialSpriteDict.ContainsKey(newMaterial))
    {
      sprite.sprite = materialSpriteDict[newMaterial];
    }
  }

}
