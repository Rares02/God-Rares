

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
    public void OpenTemporaryInfo() {
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
}
