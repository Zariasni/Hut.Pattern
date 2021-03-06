/******************************************************************************
 * Hut Singleton Pattern
 *
 * - implements of Singleton pattern
 *
 * Author : Daegung Kim
 * Version: 1.0.0
 * Update : 2020-04-27
 ******************************************************************************/

namespace Hut
{
    public class HutSingleton<T> where T : class, new()
    {
        protected static T instance;

        protected HutSingleton()
        {
        }

        public static T Instance
        {
            get { return instance ?? (instance = CreateInstance()); }
        }

        protected static T CreateInstance()
        {
            return new T();
        }
    }
}