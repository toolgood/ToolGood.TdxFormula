using System.Runtime.InteropServices;
using System.Security.Cryptography;
using ToolGood.ReadyGo3;
using ToolGood.TdxFormula;
using static ToolGood.TdxFormula.TdxMath;

namespace ToolGood.TdxFormulaTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conn = $"Data Source=Files\\stock\\000001.db";
            using (var helper = SqlHelperFactory.OpenDatabase(conn, SqlType.SQLite)) {
                var kday = helper.Select<DbKDay>("order by date desc limit 420");

                TdxNumber CLOSE = kday.Select(q => q.Close).ToArray();
                TdxNumber HIGH = kday.Select(q => q.High).ToArray();
                TdxNumber LOW = kday.Select(q => q.Low).ToArray();
                TdxNumber O = kday.Select(q => q.Open).ToArray();

                int N = 9;
                int M1 = 3;
                int M2 = 3;

                var RSV = (CLOSE - LLV(LOW, N)) / (HHV(HIGH, N) - LLV(LOW, N)) * 100;
                var K = SMA(RSV, M1, 1);
                var D = SMA(K, M2, 1);
                var J = 3 * K - 2 * D;


            }
        }
    }
}
