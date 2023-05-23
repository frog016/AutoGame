using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public bool clickedIs = false;
    private void OnMouseUp()
    {
        clickedIs = false;
    }
    void OnMouseDown()
    {
        clickedIs = true;
    }
}
