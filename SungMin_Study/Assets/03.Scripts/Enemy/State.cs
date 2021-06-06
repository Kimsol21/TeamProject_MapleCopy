using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    void OnEnter(Enemy enemy);
    void Update();
    void OnExit();
}
