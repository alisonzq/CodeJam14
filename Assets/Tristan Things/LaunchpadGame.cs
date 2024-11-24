using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchpadGame : MonoBehaviour
{
    public Sprite red;
    public Sprite green;
    public Sprite blue;

    public GameObject door;

    public int score = 0;

    public Transform gamePosition;
    public Vector2 returnPosition;

    public GameObject player;

    public bool isPlaying = false;

    public List<Transform> computerLocations = new List<Transform>();
    public List<GameObject> Es = new List<GameObject>();

    public void Update()
    {
        if (!isPlaying && AnimationSwitcher.currentMode == "Tech" && AnimationSwitcher.collectedInstruments.Contains("Launchpad"))
        {
            int i = 0;
            foreach (Transform computerLocation in computerLocations)
            {
                float distance = Vector3.Distance(computerLocation.position, player.transform.position);
                if (distance <= 1.5f)
                {
                    Es[i].SetActive(true);
                }
                else
                {
                    Es[i].SetActive(false);
                }

                if (Es[i].activeSelf && Input.GetKey(KeyCode.E))
                {
                    isPlaying = true;
                    StartGame();
                }

                i++;
            }
        }



    }

    public void StartGame() {
        returnPosition = player.transform.position;
        player.transform.position = gamePosition.transform.position;

    }

    public void EndGame() {
        player.transform.position = returnPosition;
        door.SetActive(false);
    }

    public void ChangeColor(GameObject button) {
        LaunchColor color = button.GetComponent<LaunchPadButton>().color;
        Debug.Log(color);
        switch (color) {
            case LaunchColor.Red:
                button.GetComponent<LaunchPadButton>().color = LaunchColor.Green;
                button.GetComponent<SpriteRenderer>().sprite = green;
                score++;
                break;
            case LaunchColor.Green:
                button.GetComponent<LaunchPadButton>().color = LaunchColor.Blue;
                button.GetComponent<SpriteRenderer>().sprite = blue;
                score--;
                break;
            case LaunchColor.Blue:
                button.GetComponent<LaunchPadButton>().color = LaunchColor.Red;
                button.GetComponent<SpriteRenderer>().sprite = red;
                break;
            default:
                break;
           
        }
        if (score >= 9) {
            EndGame();
        }
    }



}
