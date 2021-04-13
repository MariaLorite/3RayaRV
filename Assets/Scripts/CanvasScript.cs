using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image UIImagen;
    public TextMeshProUGUI UIText;
    int i = 0;

    public List<Sprite> SpriteList;
    int spriteIndex;

    private void Awake()
    {
        spriteIndex = 0;

        UIImagen.sprite = SpriteList[spriteIndex];
    }


    public void ChangeImagen()
    {
        if (spriteIndex < SpriteList.Count -1)
        {
            spriteIndex++;
        }

        else
            spriteIndex = 0;

        UIImagen.sprite = SpriteList[spriteIndex];
    }

    public void ChangeText()
    {
        i++;
        UIText.text = "A lo loco" + i;
    }

    public void ChangeEverithing()
    {
        ChangeImagen();
        ChangeText();
    }

}
