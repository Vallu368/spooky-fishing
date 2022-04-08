using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public int ID = 0;
    public InventoryManager inv;
    public string descriptionText;
    public UnityEngine.UI.Text text;
    public Sprite sprite;
    public Image img;


    private void Update()
    {
        
    }
    public void OnClick()
    {
        text.text = descriptionText;
        img.sprite = sprite;
}
}
