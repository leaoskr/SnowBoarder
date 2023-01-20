using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip crashSFX;
    bool playOnce = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !playOnce){
            playOnce = true;
            Debug.Log("My head!");
            FindObjectOfType<PlayerController>().DisableControl();
            CrashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
