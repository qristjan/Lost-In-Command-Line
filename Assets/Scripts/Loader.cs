using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public TMP_Text loadingText;
    public TMP_Text errorText;
    
    private AudioSource audioSource;
    
    private const string Loading = "Loading Virtual Mind Interface";

    void Start()
    {
        loadingText.text = Loading;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.0f;
        StartCoroutine(LoadingCoroutine());
        StartCoroutine(UpdateOpacityCoroutine());
    }
    
    void Update()
    {
        
    }

    private IEnumerator LoadingCoroutine()
    {
        audioSource.PlayOneShot((AudioClip)Resources.Load("loading"));
        for (var i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.6f);
            loadingText.text = Loading + ".";
            yield return new WaitForSeconds(0.6f);
            loadingText.text = Loading + "..";
            yield return new WaitForSeconds(0.6f);
            loadingText.text = Loading + "...";
        }
        yield return new WaitForSeconds(0.6f);
        audioSource.Stop();
        audioSource.PlayOneShot((AudioClip)Resources.Load("soft_error_sound"));
        loadingText.text = "";
        errorText.text = "Error in Virtual Mind Interface...\n" 
                         + "   System conflict detected... ERROR [324]: Files are corrupted\n"
                         + "   .....\n"
                         + "   .....\n"
                         + "   .....\n"
                         + "Fallback to default console. User functions are limited.\n"
                         + "Loading default console with default settings...";
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Main");
    }

    private IEnumerator UpdateOpacityCoroutine()
    {
        for (var i = 0.1f; i <= 1.0f; i += 0.025f)
        {
            audioSource.volume += i;
            yield return new WaitForSeconds(0.1f);
            loadingText.color = new Color(255, 255, 255, i);
        }
    }
}
