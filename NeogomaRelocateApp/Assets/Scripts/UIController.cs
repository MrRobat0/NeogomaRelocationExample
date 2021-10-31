using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.Neogoma.Stardust.API.Relocation;
using com.Neogoma.Stardust.Datamodel;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject relocateButton;
    [SerializeField]
    private TMP_Text warningText;
    [SerializeField]
    private float warningTextActiveSeconds;

    private void Start()
    {
        MapRelocationManager mapRelocationManager = MapRelocationManager.Instance;

        mapRelocationManager.onMapDownloadedSucessfully.AddListener(OnMapDownloaded);

        //Called when the map starts downloading
        mapRelocationManager.onMapDownloadStarted.AddListener(OnMapStartDownloading);

        //Called when the position in map has been found after relocation request
        mapRelocationManager.onPositionFound.AddListener(OnPositionMatched);

        //Called when the position in map has not been found after relocation request
        mapRelocationManager.onPositionNotFound.AddListener(OnPositionMatchFailed);

        //Called when you reached the maximum of monthly requests
        mapRelocationManager.onMaxRequestReached.AddListener(OnMaximumRequestReached);

        mapRelocationManager.onRelocateProcessing.AddListener(OnRelocateProcess);
        
    }

    private void OnRelocateProcess()
    {
        warningText.text = "Relocating...";
        StartCoroutine("TextTimer");
        relocateButton.SetActive(false);
    }
    private void OnMapDownloaded(Session session, GameObject map)
    {
        warningText.text = "Map Downloaded.";
        StartCoroutine("TextTimer");
    }
    private void OnMapStartDownloading()
    {
        warningText.text = "Downloading Map....";
        StartCoroutine("TextTimer");

    }
    private void OnPositionMatched(RelocationResults positionMatched, CoordinateSystem newCoords)
    {
        warningText.text = "Relocation Success!";
        StartCoroutine("TextTimer");
    }

    private void OnPositionMatchFailed()
    {
        warningText.text = "Relocation Failed";
        StartCoroutine("TextTimer");
    }

    private void OnMaximumRequestReached()
    {
        warningText.text = "You've reached Maximum Request Capacity";
        StartCoroutine("TextTimer");
    }

    //simple timer to turn off the text after x seconds.
    private IEnumerator TextTimer()
    {
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(warningTextActiveSeconds);
        warningText.gameObject.SetActive(false);
    }


}
