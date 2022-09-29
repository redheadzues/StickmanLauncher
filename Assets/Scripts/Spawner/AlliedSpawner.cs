using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AlliedSpawner : ObjectsPool
{
    [SerializeField] private List<UISkin> _templates;
    [SerializeField] private StickmanLauncher _launcher;
    [SerializeField] private Transform _startMovePosition;

    private GameObject _template;

    public event UnityAction<GameObject> Instantiated;

    private void Awake()
    {
        ChooseTemplate();
        InitializePool(_template);
    }

    private void OnEnable()
    {
        _launcher.Successfully += OnLaunched;
    }

    private void Start()
    {
        Spawn();
    }

    private void OnDisable()
    {
        _launcher.Successfully -= OnLaunched;
    }

    public GameObject GetTemplate()
    {
        if (TryGetObject(out GameObject stickman))
            return stickman;

        return null;
    }

    private void ChooseTemplate()
    {
        for(int i = 0; i < _templates.Count; i++)
            if (_templates[i].Id == SaveProgress.EquipedSkinId)
            {
                _template = _templates[i].gameObject;
                return;
            }
    }

    private void Spawn()
    {
        if (TryGetObject(out GameObject stickman))
        {
            if(stickman.TryGetComponent<StickmanAppearer>(out StickmanAppearer appearer))
                appearer.SetTarget(_startMovePosition);

            SetStickman(stickman);
            Instantiated?.Invoke(stickman);
        }
    }
    
    private void SetStickman(GameObject stickman)
    {
        stickman.transform.position = transform.position;
        stickman.transform.rotation = Quaternion.Euler(Vector3.zero);
        stickman.SetActive(true);
    }

    private void OnLaunched()
    {
        Spawn();
    }
}
