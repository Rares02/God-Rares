using GoogleSheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GoogleSheet.GoogleSheet googleSheet;        
    const string linkToSheet = "https://sheets.googleapis.com/v4/spreadsheets/14jqLb3pwnneEam54HM05yes5jRJkelrUBzp3YRgRKA4/values/Foglio1?key=AIzaSyCAqTvJSJqZE_RLfk03HQKQj2EEGjbK1Cg";
   
    private IEnumerator Start() {       
        yield return GoogleSheetToUnity.ObtainSheetData(linkToSheet, result => { googleSheet = result; });
    }

}
