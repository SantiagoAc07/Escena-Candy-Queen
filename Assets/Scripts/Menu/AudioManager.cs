using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Más de un AudioMnager en escena.");
        }
    }

    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void ReproducirSonido(AudioClip audio)
    {


    }

}
