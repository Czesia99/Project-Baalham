using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuit : MonoBehaviour, IComponent
{
    public IComponent [] _components;
    public State [] _pins;
    public Link [] _inputsLinks;
    private State [] _patern;
    public bool _completed;

    public void Compute()
    {
        // foreach (_pins)
        if (_pins[0] == State.UNDEFINED)
        {
            _inputsLinks[0].c.Initialize();
            _inputsLinks[0].c.Compute();
            _pins[0] = _inputsLinks[0].c.GetStates()[_inputsLinks[0].pin];
        }
    }

    public void SetLink(int inputToLink, IComponent comp, int outputToLink)
    {
        _inputsLinks[inputToLink].c = comp;
        _inputsLinks[inputToLink].pin = outputToLink;
    }

    private void Check()
    {
        // foreach(_pins)
        if (_pins[0] == _patern[0])
        {
            _completed = true;
        } else {
            _completed = false;
        }
    }

    public void Initialize()
    {
        _completed = false;
        _patern = new State [] {State.G};
        _pins = new State [] {State.UNDEFINED};
        _inputsLinks = new Link [1];
        _components = new IComponent [] {
            new ConserveStateComponent(),
            new GreenComponent()
        };
        _components[0].SetLink(0, _components[1], 0);
        this.SetLink(0, _components[0], 2);
    }

    public State [] GetStates()
    {
        return (_pins);
    }
    // Start is called before the first frame update


}
