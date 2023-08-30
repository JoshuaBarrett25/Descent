using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoading : MonoBehaviour
{ 
    public bool _isresumeSelected;
    public bool[] _loadSlotSelected; 

    public void SetResumeSelected(bool isResume)
    {
        _isresumeSelected = isResume;
    }
}
