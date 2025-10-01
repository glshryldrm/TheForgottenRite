using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text amountText;
    public ItemSO item;
    private ItemDrop itemDrop;

    public int slotIndex;

    public void SetEmpty()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        amountText.text = "";
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    public void SetItem(Sprite sprite, int amont)
    {
        itemImage.sprite = sprite;
        itemImage.preserveAspect = true;
        itemImage.enabled = true;
        amountText.text = amont <= 1 ? "" : amont.ToString();
    }
    public void Setup(int slotIndex, ItemDrop dropRef)
    {
        itemDrop = dropRef;

        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => {
            Debug.Log("týklandý");
            itemDrop.DropItem(slotIndex, 1);
            }); // 1 adet býrak
    }
}
