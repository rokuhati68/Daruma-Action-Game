using UnityEngine;

public class DownDaruma : MonoBehaviour
{
    public Vector2 darumaDirection = new Vector2(0, 1);
    
    public Sprite normalSprite;
    public Sprite findSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Daruma daruma = GetComponent<Daruma>();
        daruma.darumaDirection = darumaDirection;
        daruma.normalSprite = normalSprite;
        daruma.findSprite = findSprite;
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    
}
