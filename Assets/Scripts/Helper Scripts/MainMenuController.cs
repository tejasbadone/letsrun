using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public GameObject hero_Menu;
	public Text starScoreText;

	public Image music_Img;
	public Sprite music_Off, music_On;

	public void PlayGame() {
		SceneManager.LoadScene ("Gameplay");
	}

	public void HeroMenu() {
		hero_Menu.SetActive (true);
		starScoreText.text = "" + GameManager.instance.starScore;
	}

	public void HomeButton() {
		hero_Menu.SetActive (false);
	}

	public void MusicButton() {
		if (GameManager.instance.playSound) {
			music_Img.sprite = music_Off;
			GameManager.instance.playSound = false;
		} else {
			music_Img.sprite = music_On;
			GameManager.instance.playSound = true;
		}
	}

} // class


































