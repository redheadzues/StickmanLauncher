using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AlliedSpawner : ObjectsPool, IDoJob
{
    [SerializeField] private List<UISkin> _templates;
    [SerializeField] private StickmanLauncher _launcher;
    [SerializeField] private Transform _startMovePosition;

    private GameObject _template;

    private void Awake()
    {
        ChooseTemplate();
        InitializePool(_template);
    }

    public StickmanFlightOperator DoJob()
    {
        if (TryGetObject(out GameObject stickman))
        {
            if (stickman.TryGetComponent<StickmanAppearer>(out StickmanAppearer appearer))
                appearer.SetTarget(_startMovePosition);

            SetStickman(stickman);

            StickmanFlightOperator flyOperator = stickman.GetComponent<StickmanFlightOperator>();

            return flyOperator;
        }

        return null;
    }

    private void ChooseTemplate()
    {
        for(int i = 0; i < _templates.Count; i++)
            if (_templates[i].IsEquiped == true)
            {
                _template = _templates[i].gameObject;
                return;
            }
    }
  
    private void SetStickman(GameObject stickman)
    {
        stickman.transform.position = transform.position;
        stickman.transform.rotation = Quaternion.Euler(Vector3.zero);
        stickman.SetActive(true);
    }
}
