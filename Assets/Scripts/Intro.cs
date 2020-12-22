using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public TMP_Text tmpText;
    
    private AudioSource audioSource;
    private readonly string line1 = "Realm Quantum Technologies";
    private readonly string line2 = "Mind uploading in process... {0}";

    private readonly string[] mindUploadingStatuses =
    {
        "███ (15%)",
        "█████ (25%)",
        "██████ (30%)",
        "████████ (40%)",
        "██████████ (50%)"
    };
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        tmpText.text = line1 + "\n\n" + string.Format(line2, mindUploadingStatuses[0]);
        StartCoroutine(MindUploading());
    }

    void Update()
    {
        
    }

    private IEnumerator MindUploading()
    {
        audioSource.PlayOneShot((AudioClip)Resources.Load("mind_uploading_in_process"));
        yield return new WaitForSeconds(1f);
        tmpText.text = line1 + "\n\n" + string.Format(line2, mindUploadingStatuses[1]);
        yield return new WaitForSeconds(1.7f);
        tmpText.text = line1 + "\n\n" + string.Format(line2, mindUploadingStatuses[2]);
        yield return new WaitForSeconds(1.5f);
        tmpText.text = line1 + "\n\n" + string.Format(line2, mindUploadingStatuses[3]);
        yield return new WaitForSeconds(1f);
        tmpText.text = line1 + "\n\n" + string.Format(line2, mindUploadingStatuses[4]);
        yield return new WaitForSeconds(2f);
        tmpText.text = line1 + "\n\n" 
                             + "Mind uploading process failed. Error code [332004]." 
                             + "\n" + "Person #A754F9234 is registered as a criminal." 
                             + "\n" + "Disabling functions...";
        audioSource.PlayOneShot((AudioClip)Resources.Load("mind_uploading_process_failed_2"));
        yield return new WaitForSeconds(12f);
        tmpText.text = tmpText.text + "\n"
                                    + "Assigning monitor to person #A754F9234...";
        audioSource.PlayOneShot((AudioClip)Resources.Load("assigning_monitor"));
        yield return new WaitForSeconds(8f);
        tmpText.text = line1 + "\n\n"
                             + "CRITICAL SYSTEM ERROR [300]. Brain metadata creation failed. Locking down person #A754F9234";
        audioSource.PlayOneShot((AudioClip)Resources.Load("critical_system_error_2"));
        yield return new WaitForSeconds(4f);
        tmpText.text = tmpText.text + "\n"
                                    + "Moving person #A754F9234 to lockdown...";
        yield return new WaitForSeconds(3f);
        tmpText.text = tmpText.text + "\n"
                                    + "Lockdown suc¥¢ ..??◘╔‰``-Æ╢○234 brain interface >|`?╞♀Æ B_╢ ...";
        audioSource.PlayOneShot((AudioClip)Resources.Load("lockdown_failed_error"));
        yield return new WaitForSeconds(5f);
        tmpText.text = tmpText.text + "\n\n"
                                    + "Exception in thread main org.realm.qbit.interface.BrainMetadata\n" 
                                    + "    at org.realm.qbit.interface.BrainMetadata(Function:13)\n"
                                    + "    at org.realm.qbit.interface.BrainMetadata(CreateMetadata:145)\n";
        yield return new WaitForSeconds(3f);
        tmpText.text += "    .................\n";
        yield return new WaitForSeconds(1f);
        tmpText.text += "    .................\n";
        yield return new WaitForSeconds(1f);
        tmpText.text += "    .................\n";
        yield return new WaitForSeconds(1f);
        tmpText.text = line1 + "\n\n" + "Rebooting...";
        yield return new WaitForSeconds(5f);
        tmpText.text = line1;
        audioSource.PlayOneShot((AudioClip)Resources.Load("what_is_all_this"));
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main");
    }
}
