using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainInputLine : MonoBehaviour
{

    public TMP_InputField tmpInputField;
    public TMP_Text tmpText;

    void Start()
    {
        tmpText.text = "type /help for¥¢ .. ‰  and ð∂..ø Ø";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.tmpInputField.text = "";
        }
    }

}
