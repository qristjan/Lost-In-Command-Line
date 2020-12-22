using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test
{
    public string Question;
    public string Answer;
    public AudioClip SuccessAudio;
    public AudioClip FailureAudio;

    public abstract IEnumerator Run();

    public abstract IEnumerator HandleTest(string input);
}
