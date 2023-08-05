using UniRx;
using UnityEngine;

namespace First
{
    public class TestPresenter : MonoBehaviour
    {
        [SerializeField] private TestView _testView;
        [SerializeField] private TestModel _testModel;

        private void Awake()
        {
            // _testModel = new TestModel();とか
            // _testModel = GetComponent<TestModel>();
            // こういう処理を書きたい
        }

        private void Start()
        {
            _testView.TestEnumObservable
                .Where(type => type == TestEnum.First)
                .Subscribe(type => { Debug.Log($"ボタンが押された！ / {type}"); }).AddTo(this);

            _testView.OldTestObservable
                .Subscribe(_ => { Debug.Log($"これまでのボタンが押された！ / {TestConstants.TEST_FIRST}"); }).AddTo(this);
        }
    }
}