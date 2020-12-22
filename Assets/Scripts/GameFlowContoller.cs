using System.Collections;
using TMPro;
using UnityEngine;

public class GameFlowContoller : MonoBehaviour
{
    public TMP_InputField tmpInputField;
    public TMP_Text tmpText;
    public static bool Testing;

    public delegate string OnMainInputEnterClicked();
    public static event OnMainInputEnterClicked MainInputEnterClicked;

    private AudioSource _audioSource;
    private const string InitHelpText = "type /help for ¥¢ .. ‰  and ð∂..ø Ø";
    private Test _currentTest;

    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        tmpText.text = InitHelpText;
        _createCommands();
        _currentTest = new Test1(_audioSource, tmpInputField, tmpText);
    }

    private static void _createCommands()
    {
        GameCommands.availableCommands.Add("/test");
        GameCommands.AddCommand("/help", new Command(GameCommands.HelpText, "available_mind_interface_commands", 4f));
        GameCommands.AddCommand("/about", new Command(GameCommands.AboutText, "about", 27f));
    }


    private void Update()
    {
        if (MainInputEnterClicked == null) return;
        var input = MainInputEnterClicked();
        MainInputEnterClicked = null;
        HandleMainInput(input);
    }

    private void HandleMainInput(string input)
    {
        if (string.IsNullOrEmpty(input)) return;
        if (Testing)
        {
            StartCoroutine(_currentTest.HandleTest(input));
            return;
        }
        var parts = input.Split(' ');
        if (GameCommands.Allowed(parts[0]))
        {
            if (parts[0].Equals("/test"))
            {
                StartCoroutine(_currentTest.Run());
            }
            else
            {
                StartCoroutine(Use(GameCommands.allCommands[parts[0]]));   
            }
        } else
        {
            tmpText.text = parts[0] + " is unrecognized method.\n" + InitHelpText;
        }
    }

    private IEnumerator Use(Command command)
    {
        tmpText.text = command.Text;
        if (command.Used) yield break;
        command.Used = true;
        tmpInputField.readOnly = true;
        _audioSource.PlayOneShot((AudioClip)Resources.Load(command.AudioName));
        yield return new WaitForSeconds(command.WaitTime); 
        tmpInputField.readOnly = false;
    }
    
}

public class Command
{
    public bool Used;
    public readonly string Text;
    public readonly string AudioName;
    public readonly float WaitTime;

    public Command(string text, string audioName, float waitTime)
    {
        Text = text;
        AudioName = audioName;
        WaitTime = waitTime;
    }
    
}
