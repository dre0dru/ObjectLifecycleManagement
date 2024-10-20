namespace Dre0Dru.DestroyStrategy
{
    //TODO может не как компоненты, а как обычная имплементация через SerializeReference?
    //TODO DelegateStrategy
	
	//TODO BindTo(gameObject) for lifecycle Link
    public interface IDestroyStrategy
    {
        void Destroy();
    }
}