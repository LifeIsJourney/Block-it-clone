using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitcher : MonoBehaviour
{
    bool tapped;
    [SerializeField] float timerOfWall = .3f;
    [SerializeField] GameObject offWallGo, onWallGo;
    bool showingDottedWall=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //private void OnMouseDown()
    //{
    //    Switch();
    //}
    //called from button can also add collider
    public void Switch()
    {
        if (tapped) return;
        tapped = true;
        StartCoroutine(ShowWall());
    }
    IEnumerator ShowWall()
    {
        SwitchWallNow();
        yield return new WaitForSeconds(timerOfWall);
        SwitchWallNow();
        tapped = false;
    }
    void SwitchWallNow()
    {
        showingDottedWall = !showingDottedWall;
        offWallGo.SetActive(showingDottedWall);
        onWallGo.SetActive(!showingDottedWall);
    }
}
