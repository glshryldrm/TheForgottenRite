using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public InventoryManager inventory;         // Inspector’dan atanacak
    public Sprite elmaSprite;           // Inspector’dan atanacak

    void Start()
    {
        // Yeni bir Item oluþtur
        Item elma = new Item(elmaSprite);

        // Envantere ekle
        bool eklendi = inventory.AddItem(elma);

        if (eklendi)
            Debug.Log("Elma envantere eklendi.");
        else
            Debug.Log("Elma eklenemedi, envanter dolu.");
    }
}
