namespace Dre0Dru.Screens
{
    //TODO подумать, как это органично вписать
    //TODO возможно экстеншены через открытый API и экстеншены + chaining
    public interface IPresenter
    {
        
    }

    public interface IPresentable<T>
        where T : IPresenter
    {

    }
}
