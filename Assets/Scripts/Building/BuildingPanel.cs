using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPanel : UIPanel
{
    private ExagoneCell currentCell;

    public ExagoneCell CurrentCell => currentCell;

    public void SetCurrentCell(ExagoneCell newCell){
        currentCell = newCell;
    }

    public virtual void OpenPanel(ExagoneCell exagoneCell) {
        SetCurrentCell(exagoneCell);
        gameObject.SetActive(true);
    }
    public void CloseMenu() {
        gameObject.SetActive(false);
    }
}
