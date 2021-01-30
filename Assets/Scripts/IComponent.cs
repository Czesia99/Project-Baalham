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
    IComponent c;
    int pin;
}

public interface IComponent
{
    State [] _pins{ get; set; }
    Link [] _inputsLinks{ get; set; }
    void Compute();
    void Initialize();
    State [] GetStates();
    void SetLink(int inputToLink, IComponent toLink, int outputToLink);
}
