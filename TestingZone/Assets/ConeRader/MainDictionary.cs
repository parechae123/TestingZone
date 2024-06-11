using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainDictionary
{
    private static MainDictionary instance = new MainDictionary();
    public static MainDictionary Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MainDictionary();
            }
            return instance;
        }
    }

    public Dictionary<Vector2, SpriteRenderer> sprites = new Dictionary<Vector2, SpriteRenderer>();

    public void AddDictionary(Vector2 pos,SpriteRenderer SR)
    {
        sprites.Add(pos, SR);
    }
}
