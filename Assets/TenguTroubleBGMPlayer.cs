using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguTroubleBGMPlayer : MonoBehaviour
{
    AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();

        StartCoroutine(DelayLoopingPart());
    }

    void Update()
    {
        if (audioSources[1].time >= 69.333f)
            audioSources[1].time = 0;
    }

    IEnumerator DelayLoopingPart()
    {
        while (audioSources[0].isPlaying == false)
        {
            yield return new WaitForEndOfFrame();
        }

        audioSources[1].PlayDelayed(8.33f);

        yield return new WaitForSeconds(8.1f);
        audioSources[0].volume = .2f;
    }

}
