using System.Collections.Generic;

namespace StrategyGame.GameCore.MVC
{
    public interface IMVCDriver
    {
        IEnumerable<IMVC> GenerateMVC();
    }
}
