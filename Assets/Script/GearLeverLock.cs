using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearLeverLock : MonoBehaviour
{
    private int _currentZrotation;
    private bool _SoundJudge;
    private AudioSource audioSource;
    public GameObject PowerFeedChangeDialBackHandGrab;
    //public GameObject PowerFeedChangeDialMiddleHandGrab;
    public GameObject PowerFeedChangeDialFrontHandGrab;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _SoundJudge = true;
    }

    // Update is called once per frame
    void Update()
    {
        _currentZrotation = (int)this.transform.rotation.eulerAngles.z;
        if (_currentZrotation >= 10 && _currentZrotation <= 30) {
            PowerFeedChangeDialBackHandGrab.SetActive(false);
            //PowerFeedChangeDialMiddleHandGrab.SetActive(false);
            PowerFeedChangeDialFrontHandGrab.SetActive(false);
            if (_SoundJudge) {
                audioSource.Play();
                _SoundJudge = false;
            }

        }
        else {
            PowerFeedChangeDialBackHandGrab.SetActive(true);
            //PowerFeedChangeDialMiddleHandGrab.SetActive(true);
            PowerFeedChangeDialFrontHandGrab.SetActive(true);
            _SoundJudge = true;
        }
    }
}
