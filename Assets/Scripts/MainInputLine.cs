using TMPro;
using UnityEngine;
public class MainInputLine : MonoBehaviour
{

    public TMP_InputField tmpInputField;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && tmpInputField.text != null)
        {
            var input = tmpInputField.text;
            GameFlowContoller.MainInputEnterClicked += () => input;
            tmpInputField.text = "";
            tmpInputField.ActivateInputField();
        }
    }

}
