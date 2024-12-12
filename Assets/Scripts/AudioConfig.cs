using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    public Slider volumeSlider; // Referência ao slider de volume
    public AudioSource musica; // Referência à fonte de som da música

    void Start()
    {
        // Inicializa o volume do slider com o volume atual da música
        volumeSlider.value = musica.volume;
    }

    void Update()
    {
        // Atualiza o volume da música com base no valor do slider
        musica.volume = volumeSlider.value;
    }
}