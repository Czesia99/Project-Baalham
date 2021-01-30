using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConserveStateComponent : MonoBehaviour, IComponent
{
    public State [] _pins;

    public Link [] _inputsLinks;

    public void Compute()
    {
        if (_pins[0] != State.UNDEFINED)
        {
            _pins[2] = _pins[0];
        } else {
            _inputsLinks[0].c.Initialize();
            _inputsLinks[0].c.Compute();
            _pins[2] = _inputsLinks[0].c.GetStates()[_inputsLinks[0].pin];
        }
        if (_pins[1] != State.UNDEFINED)
        {
            _pins[3] = _pins[1];
        } else {
            _inputsLinks[1].c.Initialize();
            _inputsLinks[1].c.Compute();
            _pins[3] = _inputsLinks[1].c.GetStates()[_inputsLinks[1].pin];
        }
        if (_pins[2] == State.UNDEFINED)
            _pins[2] = State.NONE;
        if (_pins[3] == State.UNDEFINED)
            _pins[3] = State.NONE;
    }

    public void SetLink(int inputToLink, IComponent toLink, int outputToLink)
    {
        _inputsLinks[inputToLink].c = toLink;
        _inputsLinks[inputToLink].pin = outputToLink;
    }

    public void Initialize()
    {
        _pins = new State[4] {State.UNDEFINED, State.UNDEFINED, State.UNDEFINED, State.UNDEFINED};
        _inputsLinks = new Link [2];
    }

    public State [] GetStates()
    {
        return (_pins);
    }
}
