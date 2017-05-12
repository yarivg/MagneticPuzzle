using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager {

    public void setAudio(List<AudioSource> goSounds, bool bIsActive)
    {
        goSounds.ForEach((sound) => {
            if (bIsActive)
            {
                sound.UnPause();
                sound.volume = 1;
            }
            else
            {
                sound.Pause();
                sound.volume = 0;
            }

        });
    }
}
