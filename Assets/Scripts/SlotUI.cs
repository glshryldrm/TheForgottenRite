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
    private Button button;
    public int slotIndex;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    public void SetEmpty()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        amountText.text = "";
        
    }

    //public void SetItem(Sprite sprite, int amont)
    //{
    //    itemImage.sprite = sprite;
    //    itemImage.preserveAspect = true;
    //    itemImage.enabled = true;
    //    amountText.text = amont <= 1 ? "" : amont.ToString();
    //}
    //public void Setup(int slotIndex, ItemDrop dropRef)
    //{
    //    itemDrop = dropRef;

    //    GetComponent<Button>().onClick.RemoveAllListeners();
    //    GetComponent<Button>().onClick.AddListener(() => {
    //        Debug.Log("týklandý");
    //        itemDrop.DropItem(slotIndex, 1);
    //        }); // 1 adet býrak
    //}
    public void SetItem(ItemSO newItem, int amnt, ItemDrop dropRef)
    {
        if (newItem == null)
        {
            SetEmpty();
            return;
        }

        item = newItem;

        if (itemImage != null)
        {
            itemImage.sprite = item.icon;
            itemImage.enabled = true;
            itemImage.preserveAspect = true;
        }

        if (amountText != null)
            amountText.text = amnt > 1 ? amnt.ToString() : "";

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            // capture slotIndex at the time of bind
            int capturedIndex = slotIndex;
            button.onClick.AddListener(() =>
            {
                Debug.Log($"Slot button clicked - slotIndex: {capturedIndex}, item: {item?.name}");
                if (dropRef != null)
                    dropRef.DropItem(capturedIndex, 1);
                else
                    Debug.LogWarning("dropRef null! ItemDrop referansý verilmedi.");
            });
            button.interactable = true;
        }
    }
}
