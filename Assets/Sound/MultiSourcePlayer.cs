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
        tech.Play();
        if (hell.isPlaying) {
            tech.timeSamples = hell.timeSamples;
        }
        else if (nature.isPlaying) {
            tech.timeSamples = nature.timeSamples;
        }

    }

    public void startHell() {
        hell.Play();
        if (tech.isPlaying) {
            hell.timeSamples = tech.timeSamples;
        }
        else if (nature.isPlaying) {
            hell.timeSamples = nature.timeSamples;
        }
    }
    public void startNature() {
        nature.Play();
        if (tech.isPlaying) {
            nature.timeSamples = tech.timeSamples;
        }
        else if (hell.isPlaying) {
            nature.timeSamples = hell.timeSamples;
        }
    }

    public void startEnd() {
        end.Play();
        end.timeSamples = tech.timeSamples;

    }

    public void play() {
        if (Progression.tech) {
            tech.Play();
        }
        if (Progression.hell) {
            hell.Play();
        }
        if (Progression.nature) {
            nature.Play();
        }
        if (Progression.tech && Progression.hell && Progression.nature) {
            end.Play();
        }
    }

    public void stop() {
        tech.Stop();
        hell.Stop();
        nature.Stop();
        end .Stop();
    }


}
