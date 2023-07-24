using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Old
{
    public class Promocode3 : MonoBehaviour {

        public InputField inputField;
        private List<string[]> data = new List<string[]>();
        private List<int> printedIndexes = new List<int>();
        private int currentIndex = 0;

        void Start() {
            LoadCsvFile();
        }

        void LoadCsvFile() {
            // Read the file as one string.
            string content = File.ReadAllText(Application.streamingAssetsPath + "/Promo3.csv");

            // Split the content into lines and store as string array
            string[] lines = content.Split('\n');

            // Split each line into columns and store as string array.
            // Add each row to the list
            foreach (string line in lines) {
                string[] columns = line.Split(',');
                data.Add(columns);
            }
        }

        public void OnYesButtonClick() {
            // get next index
            do {
                currentIndex = (currentIndex + 1) % data.Count;
            } while (printedIndexes.Contains(currentIndex));
            printedIndexes.Add(currentIndex);

            // get values from next row and display
            string[] rowValues = data[currentIndex];
            string selectedValue = string.Join(",", rowValues);
            inputField.text = selectedValue;
        }
    }
}