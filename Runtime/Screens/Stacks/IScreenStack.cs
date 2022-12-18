using System;

namespace Dre0Dru.Screens.Stacks
{
    //TODO абстракция в Layer, то есть занаследовать пусто Layer
    //TODO а Stacks сделать как коллецию Layers
    public interface IScreenStack
    {
        
    }
    
    public interface IScreenStackPush<in TScreenBase> : IScreenStack
    {
        void Push(TScreenBase screen);
    }
    
    public interface IScreenStackPush<in TScreenBase, in TOptions> : IScreenStack
    {
        void Push(TScreenBase screen, TOptions options);
    }

    public interface IScreenStackPop : IScreenStack
    {
        void Pop();
    }
    
    public interface IScreenStackPop<in TOptions> : IScreenStack
    {
        void Pop(TOptions options);
    }

    public interface IScreenStackPopAll : IScreenStack
    {
        void PopAll();
    }
    
    public interface IScreenStackPopAll<in TOptions> : IScreenStack
    {
        void PopAll(TOptions options);
    }

    public interface IScreenStackCallbacks<out TScreenBase>
    {
        event Action<TScreenBase> OnPushStart;
        event Action<TScreenBase> OnPushFinish;
        event Action<TScreenBase> OnPopStart;
        event Action<TScreenBase> OnPopFinish;
    }
    
     


}
