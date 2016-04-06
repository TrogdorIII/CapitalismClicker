using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyClicker : MonoBehaviour
{

    public UpgradeHandler upgradehandler;
    public Animation juicyTrump;
    private bool scaleIn;

    void Update()
    {
        if (scaleIn)
        {

        }
        else
        {

        }
    }

    public void MoneyClicked()
    {
        GameManager.manager.moneyAvaliable += upgradehandler.clickMultiplier;
        gameObject.AddComponent<Scaler>().SetAnimation(new Vector3(1.2f, 1.2f, 1.2f), 3f);
        //juicyTrump.Play();
    }

    public void HoverIntoImageAnim(GameObject image)
    {
        Vector3 scale = image.GetComponent<RectTransform>().localScale;
        if (scale.x <= 1.2)
        {
            scale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    public void HoverOutImageAnim(GameObject image)
    {
        Vector3 scale = image.GetComponent<RectTransform>().localScale;
        if (scale.x <= 0.8)
        {
            scale -= new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    void ClickImageAnim(RectTransform image)
    {

    }

}
