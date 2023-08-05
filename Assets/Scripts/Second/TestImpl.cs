using UnityEngine;

namespace Second
{
    public class TestImpl : MonoBehaviour
    {
        private TestModel _model;
        private TestPresenter _presenter;
        [SerializeField] private TestView _testView;

        //VContainer使ったらいい感じになりそう
        private void Awake()
        {
            _model = new TestModel();
            _presenter = new TestPresenter(_testView, _model);
        }

        private void OnDestroy()
        {
            _model.Dispose();
            _presenter.Dispose();
        }
    }
}