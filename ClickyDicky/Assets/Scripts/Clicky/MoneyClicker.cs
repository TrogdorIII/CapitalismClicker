using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyClicker : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public UpgradeHandler upgradehandler;
    public Animation juicyTrump;
    [Header("Click Variables")]
    public float defaultSize = 1f;
    public float hoverSize = 1.1f;
    public float clickSize = 0.8f;
    public float animationTime = 0.1f;
    #endregion

    #region EventManager Methods
    /// <summary>
    /// This method is the one which is called when the money is moused down on
    /// </summary>
    /// <param name="image"></param>
    public void MoneyMouseDown(GameObject image)
    {
        BootlegTween.ScaleUI(image, new Vector3(clickSize, clickSize, clickSize), animationTime, BootlegTween.MotionCurve.EaseOutElastic);
    }

    /// <summary>
    /// This method is the one which is called when the money is moused up on
    /// </summary>
    /// <param name="image"></param>
    public void MoneyMouseUp(GameObject image)
    {
        GameManager.manager.moneyAvaliable += upgradehandler.clickMultiplier;
        BootlegTween.ScaleUI(image, new Vector3(hoverSize, hoverSize, hoverSize), animationTime, BootlegTween.MotionCurve.EaseOutElastic);
    }

    /// <summary>
    /// This method is the one which is called when the money is hovered over
    /// </summary>
    /// <param name="image"></param>
    public void HoverIntoImageAnim(GameObject image)
    {
        BootlegTween.ScaleUI(image, new Vector3(hoverSize, hoverSize, hoverSize), animationTime, BootlegTween.MotionCurve.EaseOutElastic);
    }

    /// <summary>
    /// This method is the one which is called when the money is hovered
    /// </summary>
    /// <param name="image"></param>
    public void HoverOutImageAnim(GameObject image)
    {
        BootlegTween.ScaleUI(image, new Vector3(defaultSize, defaultSize, defaultSize), animationTime, BootlegTween.MotionCurve.EaseOutElastic);
    }
    #endregion
}
