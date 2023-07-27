using System;
using Cutsceens;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace UI.Menu
{
    public class CarSelectMenu : MonoBehaviour
    {
        [SerializeField] private CutsceenLoadArguments cutsceenLoader;
        
        [SerializeField] private GameObject sedanPanel;
        [SerializeField] private GameObject jeepPanel;
        [SerializeField] private GameObject offroadPanel;

        public void Start()
        {
            switch (ChoiceManager.CurrentCar)
            {
                case Car.Sedan:
                    sedanPanel.SetActive(true);
                    jeepPanel.SetActive(false);
                    offroadPanel.SetActive(false);
                    break;
                case Car.Jeep:
                    sedanPanel.SetActive(false);
                    jeepPanel.SetActive(true);
                    offroadPanel.SetActive(false);
                    break;
                case Car.Offroad:
                    sedanPanel.SetActive(false);
                    jeepPanel.SetActive(false);
                    offroadPanel.SetActive(true);
                    break;
            }
        }

        public void OnButtonBack()
        {
            SceneManager.LoadScene("LocationMenu");
        }

        public void OnButtonStart()
        {
            ChoiceManager.CurrentCutscene = (CutsceenName)Random.Range(0, 4);
            cutsceenLoader.LoadCutsceenArgs(ChoiceManager.CurrentCutscene, CutsceenLoadArguments.CutsceenState.Start);
            SceneManager.LoadScene("CutscenePlayer");
            //SceneManager.LoadScene("LevelCity");
        }

        public void OnButtonGarage()
        {
            SceneManager.LoadScene("GarageMenu");
        }
    }
}
