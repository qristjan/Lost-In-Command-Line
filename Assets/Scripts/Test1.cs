using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test1 : Test
{
    private readonly AudioSource _audioSource;
    private readonly TMP_InputField _tmpInputField;
    private readonly TMP_Text _tmpText;

    private bool _init = true;

    public Test1(AudioSource audioSource, TMP_InputField tmpInputField, TMP_Text tmpText)
    {
        Question = "1 + 4 = ?";
        Answer = "5";
        SuccessAudio = (AudioClip) Resources.Load("first_success");
        FailureAudio = (AudioClip) Resources.Load("first_failure");
        
        _audioSource = audioSource;
        _tmpInputField = tmpInputField;
        _tmpText = tmpText;
    }

    public override IEnumerator Run()
    {
        GameFlowContoller.Testing = true;
        
        _tmpInputField.readOnly = true;
        _tmpText.text = "Welcome to your first test.\n"
                       + "These tests are meant to check your compatibility\n"
                       + "with the Virtual Mind Interface Program and your state of health.\n"
                       + "Here is your first assignment.";
        _audioSource.PlayOneShot((AudioClip)Resources.Load("first_test"));
        yield return new WaitForSeconds(2f); // 12f
        _tmpInputField.readOnly = false;
        _tmpText.text = "mov     eax, 0001";
        yield return new WaitForSeconds(0.5f);
        _tmpText.text = "mov     eax, 0001\nmov     ebx, 0100";
        yield return new WaitForSeconds(0.5f);
        _tmpText.color = new Color(255, 0, 0);
        _tmpText.text = "mov     eax, 0001\nmov     ebx, 0100\nadd     eax, ebx\nIllegal override register\nFatal error";
        yield return new WaitForSeconds(0.7f);
        _tmpText.color = new Color(0f, 1f, 0.263f);
        _tmpText.text = Question;
    }

    public override IEnumerator HandleTest(string input)
    {
        if (input.Equals(Answer))
        {
            _tmpText.text = "Congratulations!";
            if (SuccessAudio != null)
            {
                _tmpInputField.readOnly = true;
                _audioSource.PlayOneShot(SuccessAudio);
                yield return new WaitForSeconds(9f);
                _tmpInputField.readOnly = false;
            }
            GameFlowContoller.Testing = false;
        }
        else
        {
            _tmpText.text = "Incorrect.\n" + Question;
            if (_init && FailureAudio != null)
            {
                _init = false;
                _tmpInputField.readOnly = true;
                _audioSource.PlayOneShot(FailureAudio);
                yield return new WaitForSeconds(4f);
                _tmpInputField.readOnly = false;
            }
        }
    }
    
}
