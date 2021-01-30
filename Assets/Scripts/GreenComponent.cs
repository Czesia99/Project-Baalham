using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenComponent : MonoBehaviour, IComponent
{
    public State [] _pins;

    public Link [] _inputsLinks;

    public void Compute()
    {
        return;
    }

    public void SetLink(int inputToLink, IComponent toLink, int outputToLink)
    {
        return;
    }

    public void Initialize()
    {
        _pins = new State[] {State.Green};
    }

    public State [] GetStates()
    {
        return (_pins);
    }
}
}
