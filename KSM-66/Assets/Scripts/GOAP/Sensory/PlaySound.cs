using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    [SerializeField] private int random;

    public bool scarePlayer;

    public event Action onPlayerScared;

    private void Awake()
    {
        random = Random.Range(0, 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        ScareIA();
    }

    private void ScareIA()
    {
        if (random == 0)
        {
            audio.Play();
            scarePlayer = true;
            onPlayerScared?.Invoke();
        }
        else
        {
            scarePlayer = false;
            audio.Stop();
        }
    }
}
