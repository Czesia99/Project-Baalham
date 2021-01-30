using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    UNDEFINED,
    R,
    G,
    B,
    NONE
}

public struct Link {
    public IComponent c;
    public int pin;
}

public interface IComponent
{
    void Compute();
    void Initialize();
    State [] GetStates();
    void SetLink(int inputToLink, IComponent toLink, int outputToLink);
}
