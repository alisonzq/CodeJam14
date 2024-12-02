using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class MultiSourcePlayer : MonoBehaviour
{
    public AudioSource tech;
    public AudioSource hell;
    public AudioSource nature;
    public AudioSource end;
    public void startTech() {
        tech.Pause();
        if (hell.isPlaying) {
            tech.timeSamples = hell.timeSamples;
        }
        else if (nature.isPlaying) {
            tech.timeSamples = nature.timeSamples;
        }
        tech.Play();

    }

    public void startHell() {
        hell.Pause();   
        if (tech.isPlaying) {
            hell.timeSamples = tech.timeSamples;
        }
        else if (nature.isPlaying) {
            hell.timeSamples = nature.timeSamples;
        }
        hell.Play();
    }
    public void startNature() {
        nature.Pause();
        if (tech.isPlaying) {
            nature.timeSamples = tech.timeSamples;
        }
        else if (hell.isPlaying) {
            nature.timeSamples = hell.timeSamples;
        }
        nature.Play();
    }

    public void startEnd() {
        end.Pause();    
        end.timeSamples = tech.timeSamples;
        end.Play(); 

    }

    public void play() {
        if (Progression.tech) {
            startTech();
        }
        if (Progression.hell) {
            startHell();
        }
        if (Progression.nature) {
            startNature();
        }
        if (Progression.tech && Progression.hell && Progression.nature) {
            startEnd();
        }
    }

    public void stop() {
        tech.Pause();
        hell.Stop();
        nature.Stop();
        end.Stop();
    }


}

