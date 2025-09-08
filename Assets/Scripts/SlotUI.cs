using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text amountText;

    public int slotIndex;

    public void SetEmpty()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        amountText.text = "";
    }

    public void SetItem(Sprite sprite, int amont)
    {
        itemImage.sprite = sprite;
        itemImage.preserveAspect = true;
        itemImage.enabled = true;
        amountText.text = amont < 1 ? amont.ToString() : "";
    }
}
