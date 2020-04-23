namespace Hut
{
    public class HutSingleton<T> where T : class, new()
    {
        protected static T instance;

        protected HutSingleton()
        {
        }

        public static T Instance()
        {
            return instance ?? (instance = createInstance());
        }

        protected static T createInstance()
        {
            return new T();
        }
    }
}