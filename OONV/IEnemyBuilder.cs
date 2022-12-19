using System;
namespace OONV
{
    public interface IEnemyBuilder
    {
        Enemy CreateSmall();
        Enemy CreateMedium();
        Enemy CreateLarge();
    }
}
