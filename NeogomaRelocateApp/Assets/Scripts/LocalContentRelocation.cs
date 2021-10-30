using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.Neogoma.Stardust.API.Relocation;
using com.Neogoma.Stardust.Datamodel;
public class LocalContentRelocation : MonoBehaviour
{
    public string uuid;

    public void Relocate()
    {
        MapRelocationManager.Instance.LocateCurrentPosition(uuid);
    }
 
}
