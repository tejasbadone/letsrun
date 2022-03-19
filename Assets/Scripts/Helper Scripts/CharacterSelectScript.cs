using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScript : MonoBehaviour {

	public GameObject[] available_Heroes;

	private int currentIndex;

	public Text selectedText;
	public GameObject starIcon;
	public Image selectBtn_Image;
	public Sprite button_Green, button_Blue;

	private bool[] heroes;

	public Text starScoreText;

	void Start () {
		InitializeCharacters ();
	}
	
	void InitializeCharacters() {
		
		currentIndex = GameManager.instance.selected_Index;

		for (int i = 0; i < available_Heroes.Length; i++) {
			available_Heroes [i].SetActive (false);
		}
		available_Heroes [currentIndex].SetActive (true);

		heroes = GameManager.instance.heroes;
	}

	public void NextHero() {
		available_Heroes [currentIndex].SetActive (false);

		if (currentIndex + 1 == available_Heroes.Length) {
			currentIndex = 0;

		} else {
			currentIndex++;
		}

		available_Heroes [currentIndex].SetActive (true);

		CheckIfCharacterIsUnlocked ();

	}

	public void PreviousHero() {
		available_Heroes [currentIndex].SetActive (false);

		if (currentIndex - 1 == -1) {
			currentIndex = available_Heroes.Length - 1;

		} else {
			currentIndex--;
		}

		available_Heroes [currentIndex].SetActive (true);

		CheckIfCharacterIsUnlocked ();

	}

	void CheckIfCharacterIsUnlocked() {

		if (heroes [currentIndex]) {
			// if the hero is unlocked

			starIcon.SetActive (false);

			if (currentIndex == GameManager.instance.selected_Index) {
				selectBtn_Image.sprite = button_Green;
				selectedText.text = "Selected";
			} else {
				selectBtn_Image.sprite = button_Blue;
				selectedText.text = "Select?";
			}

		} else {
			// if the hero is LOCKED
			selectBtn_Image.sprite = button_Blue;
			starIcon.SetActive (true);
			selectedText.text = "1000";
		}
	}

	public void SelectHero() {
		if (!heroes [currentIndex]) {
			// IF THE HERO IS NOT UNLOCKED - MEANING HE IS LOCKED

			if (currentIndex != GameManager.instance.selected_Index) {
				// UNLOCK HERO IF YOU HAVE ENOUGH STAR COUINS

				if (GameManager.instance.starScore >= 1000) {
					GameManager.instance.starScore -= 1000;

					selectBtn_Image.sprite = button_Green;
					selectedText.text = "Selected";
					starIcon.SetActive (false);

					heroes [currentIndex] = true;

					starScoreText.text = GameManager.instance.starScore.ToString ();

					GameManager.instance.selected_Index = currentIndex;
					GameManager.instance.heroes = heroes;

					GameManager.instance.SaveGameData ();

				} else {
					print ("NOT ENOUGH STAR POINTS TO UNLOCK THE PLAYER");
				}
			}

		} else {

			selectBtn_Image.sprite = button_Green;
			selectedText.text = "Selected";
			GameManager.instance.selected_Index = currentIndex;

			GameManager.instance.SaveGameData ();
		}
	}

} // class








































