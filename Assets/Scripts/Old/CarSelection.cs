using UnityEngine;
using UnityEngine.SceneManagement;

namespace Old
{
	public class CarSelection : MonoBehaviour
	{
		public GameObject[] cars;
		public int selectedCar = 0;

		public void NextCharacter()
		{
			cars[selectedCar].SetActive(false);
			selectedCar = (selectedCar + 1) % cars.Length;
			cars[selectedCar].SetActive(true);
		}

		public void PreviousCharacter()
		{
			cars[selectedCar].SetActive(false);
			selectedCar--;
			if (selectedCar < 0)
			{
				selectedCar += cars.Length;
			}
			cars[selectedCar].SetActive(true);
		}

		public void StartGame()
		{
			PlayerPrefs.SetInt("selectedCharacter", selectedCar);
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		}
	}
}
