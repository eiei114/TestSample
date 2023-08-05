using UniRx;
using UnityEngine;

namespace Second
{
    public class TestController : MonoBehaviour
    {
        private TestModel _model;
        private TestPresenter _presenter;
        [SerializeField] private TestView _testView;

        //VContainer使ったらいい感じになりそう
        private void Awake()
        {
            _model = new TestModel();
            
            _model.OnAsyncInitializeObservable
                .Subscribe(model =>
                {
                    _presenter = new TestPresenter(_testView, model);
                }).AddTo(this);
        }

        private void OnDestroy()
        {
            _model.Dispose();
            _presenter.Dispose();
        }
    }
}