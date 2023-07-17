using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Ses Kaynaklarini atamak icin gerekli degiskenleri olusturduk.
    [SerializeField] AudioSource audioSource;
    
    public AudioClip[] sounds;
    #region Singleton    
    // #region bu þekilde kullanýlýr... // Kodlarý gruplamak için kullanýlýr.
    public static SoundManager instance; // "Singleton sahnede tek bir obje için kullanýlýr. Örneðin score tabelasý...."

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }
    #endregion
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayWithIndex(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
