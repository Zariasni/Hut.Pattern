using System;
using Hut;

namespace Hut
{
    // ����� Ÿ���� ���𰡸� �׳� ���� T �� �׻� �θ� Ŭ�����̰ų� �������̽�����.
    // animal->lion, cheetah, bison etc.
    public class HutAbstractFactory<T> where T : class, new()
    {
        public T Create()
        {
            return new T();
        }
    }

    // ���� ������ ����� �Ǵ� �ǹ�
    public interface IHutBuilding
    {
        T initialize<T>();
    }

    // ���డ
    // ���������� ������ ����-����� �� ���� ����(matrix, vector �� �׷���)
    public class HutAbstractBuilder<T> where T : IHutBuilding, new()

    {
        public T Build()
        {
            return new T().initialize<T>(); // with init
        }
    }
}