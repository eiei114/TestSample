using UniRx;
using UnityEngine;

public class TestPresenter : MonoBehaviour
{
    [SerializeField] private TestView _testView;
    [SerializeField] private TestModel _testModel;

    private void Start()
    {
        _testView.TestEnumObservable
            .Where(type => type == TestEnum.First)
            .Subscribe(type => { Debug.Log($"ボタンが押された！ / {type}"); }).AddTo(this);

        _testView.OldTestObservable
            .Subscribe(_ => { Debug.Log($"これまでのボタンが押された！"); }).AddTo(this);
    }
}