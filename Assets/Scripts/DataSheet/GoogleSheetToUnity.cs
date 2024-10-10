using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GoogleSheetLib {
    public class GoogleSheetToUnity {

        /// <summary>
        /// Set this as callback: result => { googleSheet = result; }
        /// </summary>
        public static IEnumerator ObtainSheetData(string link, System.Action<GoogleSheet> callback) {
            UnityWebRequest www = UnityWebRequest.Get(link);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log("ERROR: " + www.error);
            }
            else {
                string json = www.downloadHandler.text;
                int x = -1;
                bool startAddingValues = false;
                bool startReadingValues = false;
                string temporary = "";
                List<List<string>> cells = new List<List<string>>();
                foreach (char c in json) {
                    if (c == '[') {
                        if (x >= 0) cells.Add(new List<string>());
                        x++;
                    }
                    if (startReadingValues || c == '"') {
                        if (c != '"') temporary += c;
                        else {
                            startReadingValues = !startReadingValues;
                            if (!startReadingValues && startAddingValues && (x - 1) >= 0) cells[x - 1].Add(temporary);
                            if (!startReadingValues && temporary == "values") startAddingValues = true;
                            temporary = "";
                        }
                    }

                }
                callback.Invoke(new GoogleSheet(x - 1, cells));
            }
        }
    }

    public class GoogleSheet {
        private string[] titles;
        private string[,] grid;

        private int rowsNumber;
        private int columnsNumber;

        public string[] row;

        public string this[string name, string type] {
            get {
                for (int y = 0; y < rowsNumber; y++) {
                    if (grid[0, y].ToLower() == name.ToLower()) {
                        for (int x = 0; x < columnsNumber; x++) {
                            if (titles[x].ToLower() == type.ToLower()) {
                                return grid[x, y];
                            }
                        }
                    }
                }
                return null;
            }
        }
        public string[] this[string name, bool row = true] {
            get {
                if (row) {
                    for (int y = 0; y < rowsNumber; y++) {
                        if (grid[0, y].ToLower() == name.ToLower()) {
                            string[] r = new string[columnsNumber];
                            for (int x = 0; x < columnsNumber; x++) {
                                r[x] = grid[x, y];
                            }
                            return r;
                        }
                    }
                    return null;
                }
                else {
                    for (int x = 0; x < columnsNumber; x++) {
                        if (titles[x].ToLower() == name.ToLower()) {
                            string[] c = new string[rowsNumber];
                            for (int y = 0; y < rowsNumber; y++) {
                                c[y] = grid[x, y];
                            }
                            return c;
                        }
                    }
                    return null;
                }
            }
        }
        public GoogleSheet(int rowsNumber, List<List<string>> cells) {
            if (cells.Count == 0) return;
            this.rowsNumber = rowsNumber;
            this.columnsNumber = cells[0].Count;

            this.titles = new string[columnsNumber];
            this.grid = new string[columnsNumber, rowsNumber];

            for (int x = 0; x < columnsNumber; x++) {
                titles[x] = cells[0][x];
            }
            for (int y = 0; y < rowsNumber; y++) {
                for (int x = 0; x < columnsNumber; x++) {
                    grid[x, y] = cells[y + 1][x];
                }
            }
        }

        public static List<string> FromStringToListString(string s) {

            List<string> list = new List<string>();
            string temporary = "";
            foreach (char c in s) {
                if (c == ',') {
                    list.Add(temporary);
                    temporary = "";
                }
                else if (c != ' ') {
                    temporary += c;
                }
            }
            list.Add(temporary);
            return list;
        }
        public static bool TryFromStringToListInt(string s, out List<int> intList) {
            intList = new List<int>();
            string temporary = "";
            foreach (char c in s) {
                if (c == ',') {
                    if (int.TryParse(temporary, out int outInt)) {
                        intList.Add(outInt);
                    }
                    else if (temporary == "") {
                        intList.Add(0);
                    }
                    else {
                        return false;
                    }
                    temporary = "";
                }
                else if (c != ' ') {
                    temporary += c;
                }
            }

            if (int.TryParse(temporary, out int i)) {
                intList.Add(i);
            }
            else if (temporary == "") {
                intList.Add(0);
            }
            else {
                return false;
            }
            return true;
        }
    }
}

