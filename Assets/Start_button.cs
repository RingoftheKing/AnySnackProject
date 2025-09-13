using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonImageSwap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;    // The Image component of the button
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public GameObject panelToClose;
    public GameObject panelToOpen;

    // Called when button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedSprite;
    }

    // Called when button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
        panelToClose.SetActive(false);
        panelToOpen.SetActive(true);
    }
}
