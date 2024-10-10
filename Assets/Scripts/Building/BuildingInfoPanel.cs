

public class BuildingInfoPanel : BuildingPanel {
    private bool permanent;
    public void SetPermanent() {
        permanent = true;
    }
    public void SetTemporary() {
        permanent = false;
    }
    public void OpenPermanentInfo() {
        gameObject.SetActive(true);
        SetPermanent();
    }
    public void OpenTemporaryInfo(ExagoneCell exagoneCell) {
        SetupInfo(exagoneCell);
        if(!permanent) gameObject.SetActive(true);
    }
    public void CloseTemporaryInfo() {
        if (!permanent) {
            gameObject.SetActive(false);
        }
    }
    public void ClosePermanentInfo() {
        gameObject.SetActive(false);
        SetTemporary();
    }
    private void SetupInfo(ExagoneCell exagoneCell) {
        if (exagoneCell.CellData.CurrentBuilding == null) {
            //empty
        }
    }
}
