using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioConfig : MonoBehaviour
{
    public Slider volumeSlider; // Refer�ncia ao slider de volume
    public AudioSource musica; // Refer�ncia � fonte de som da m�sica

    void Start()
    {
        // Inicializa o volume do slider com o volume atual da m�sica
        volumeSlider.value = musica.volume;
    }

    void Update()
    {
        // Atualiza o volume da m�sica com base no valor do slider
        musica.volume = volumeSlider.value;
    }
}