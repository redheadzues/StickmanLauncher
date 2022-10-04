using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UICastleDamage : MonoBehaviour
{
    [SerializeField] private TMP_Text _textDamage;

    public void Initialize(float damage)
    {
        _textDamage.text += damage.ToString();
    }

    private IEnumerator Animate()
    {
        while(_textDamage.rectTransform.sizeDelta.x > 0)
        {

        }

        yield return null;
    }
}
