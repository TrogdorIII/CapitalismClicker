using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DesaturateAll : MonoBehaviour
{
    public Image[] imagesInScene;
    void OnEnable()
    {
        imagesInScene = (Image[])GameObject.FindObjectsOfType(typeof(Image)); //returns Image[]
    }

    public void AdjustGreyscale(float value)
    {
        Color colour;
        float greyVal;
        for (int i = 0; i < imagesInScene.Length; i++)
        {
            colour = imagesInScene[i].color;
            greyVal = ((colour.r + colour.g + colour.b) / 3);
            imagesInScene[i].color = Color.Lerp(imagesInScene[i].color, new Color(greyVal, greyVal, greyVal, colour.a), value);
        }
    }
}
