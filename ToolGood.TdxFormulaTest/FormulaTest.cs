using PetaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ToolGood.TdxFormula;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static ToolGood.TdxFormula.TdxMath;

namespace ToolGood.TdxFormulaTest
{
    [TestFixture]
    public class FormulaTest
    {
        const string Folder = @"TestDatas";
        [Test]
        public void DMA_Test()
        {
            var file = $"{Folder}\\DMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = DMA(C, 0.3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }

        }
        [Test]
        public void SMA_Test()
        {
            var file = $"{Folder}\\SMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = SMA(C, 5, 1);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void MA_Test()
        {
            var file = $"{Folder}\\MA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = MA(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void EMA_Test()
        {
            var file = $"{Folder}\\EMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = EMA(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void TMA_Test()
        {
            var file = $"{Folder}\\TMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = TMA(C, 0.2, 0.8);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void MEMA_Test()
        {
            var file = $"{Folder}\\MEMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = MEMA(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void WMA_Test()
        {
            var file = $"{Folder}\\WMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = WMA(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void AMA_Test()
        {
            var file = $"{Folder}\\AMA.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = AMA(C, 0.5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void HHV_Test()
        {
            var file = $"{Folder}\\HHV.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = HHV(C, 15);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void HHVBARS_Test()
        {
            var file = $"{Folder}\\HHVBARS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = HHVBARS(C, 15);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LLV_Test()
        {
            var file = $"{Folder}\\LLV.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = LLV(C, 15);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LLVBARS_Test()
        {
            var file = $"{Folder}\\LLVBARS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = LLVBARS(C, 15);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void HOD_Test()
        {
            var file = $"{Folder}\\HOD.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = HOD(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LOD_Test()
        {
            var file = $"{Folder}\\LOD.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = LOD(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void COUNT_Test()
        {
            var file = $"{Folder}\\COUNT.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            var TEST = COUNT(C > O, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void SUM_Test()
        {
            var file = $"{Folder}\\SUM.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = SUM(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void REF_Test()
        {
            var file = $"{Folder}\\REF.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = REF(C, 1);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }

        [Test]
        public void REVERSE_Test()
        {
            var file = $"{Folder}\\REVERSE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = REVERSE(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void BARSLAST_Test()
        {
            var file = $"{Folder}\\BARSLAST.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber CLOSE = data.Select(q => q.CLOSE).ToArray();
            var TEST = BARSLAST(CLOSE / REF(CLOSE, 1) >= 1.09);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void BARSSINCE_Test()
        {
            var file = $"{Folder}\\BARSSINCE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber HIGH = data.Select(q => q.HIGH).ToArray();
            var TEST = BARSSINCE(HIGH < 16);

            for (int i = 20; i < TEST.Length; i++) {
                if (double.IsNaN(TEST[i])) {
                    Assert.AreEqual(-4.03981033463327E+34, data[i].Value, 0.001);
                } else {
                    Assert.AreEqual(TEST[i], data[i].Value, 0.001);
                }
            }
        }
        [Test]
        public void BARSSINCEN_Test()
        {
            var file = $"{Folder}\\BARSSINCEN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber HIGH = data.Select(q => q.HIGH).ToArray();
            var TEST = BARSSINCEN(HIGH > 16, 10);

            //for (int i = 20; i < TEST.Length; i++) {
            //    if (double.IsNaN(TEST[i])) {
            //        Assert.AreEqual(-4.03981033463327E+34, data[i].Value, 0.001);
            //    } else {
            //        Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            //    }
            //}
        }
        [Test]
        public void BARSLASTCOUNT_Test()
        {
            var file = $"{Folder}\\BARSLASTCOUNT.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber CLOSE = data.Select(q => q.CLOSE).ToArray();
            TdxNumber OPEN = data.Select(q => q.OPEN).ToArray();
            var TEST = BARSLASTCOUNT(CLOSE > OPEN);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void SUMBARS_Test()
        {
            var file = $"{Folder}\\SUMBARS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber VOL = data.Select(q => q.VOL).ToArray();
            TdxNumber CAPITAL = data.Select(q => q.CAPITAL).ToArray();
            var TEST = SUMBARS(VOL, CAPITAL);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FILTER_Test()
        {
            var file = $"{Folder}\\FILTER.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber CLOSE = data.Select(q => q.CLOSE).ToArray();
            TdxNumber OPEN = data.Select(q => q.OPEN).ToArray();
            var TEST = FILTER(CLOSE > OPEN, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void CONST_Test()
        {
            var file = $"{Folder}\\CONST.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber CLOSE = data.Select(q => q.CLOSE).ToArray();
            var TEST = CONST(CLOSE);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void MULAR_Test()
        {
            var file = $"{Folder}\\MULAR.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber CLOSE = data.Select(q => q.CLOSE).ToArray();
            var TEST = MULAR(CLOSE, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.01);
            }
        }
        [Test]
        public void FILTERX_Test()
        {
            var file = $"{Folder}\\FILTERX.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber CLOSE = data.Select(q => q.CLOSE).ToArray();
            TdxNumber OPEN = data.Select(q => q.OPEN).ToArray();
            var TEST = FILTERX(CLOSE > OPEN, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void TOPRANGE_Test()
        {
            var file = $"{Folder}\\TOPRANGE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber HIGH = data.Select(q => q.HIGH).ToArray();
            var TEST = TOPRANGE(HIGH);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LOWRANGE_Test()
        {
            var file = $"{Folder}\\LOWRANGE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber LOW = data.Select(q => q.LOW).ToArray();
            var TEST = LOWRANGE(LOW);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FINDHIGH_Test()
        {
            var file = $"{Folder}\\FINDHIGH.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = FINDHIGH(C, 5, 10, 2);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FINDHIGHBARS_Test()
        {
            var file = $"{Folder}\\FINDHIGHBARS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = FINDHIGHBARS(C, 5, 10, 2);

            var count = 0;
            for (int i = 20; i < TEST.Length; i++) {
                if (TEST[i] != data[i].Value) {
                    count++;
                }
            }
            Assert.Less(count, 20);
        }
        [Test]
        public void FINDLOW_Test()
        {
            var file = $"{Folder}\\FINDLOW.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = FINDLOW(C, 5, 10, 2);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FINDLOWBARS_Test()
        {
            var file = $"{Folder}\\FINDLOWBARS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = FINDLOWBARS(C, 5, 10, 2);

            var count = 0;
            for (int i = 20; i < TEST.Length; i++) {
                if (TEST[i] != data[i].Value) {
                    count++;
                }
            }
            Assert.Less(count, 20);
        }
        [Test]
        public void ZTPRICE_Test()
        {
            var file = $"{Folder}\\ZTPRICE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = ZTPRICE(C, 0.1);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void DTPRICE_Test()
        {
            var file = $"{Folder}\\DTPRICE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = DTPRICE(C, 0.1);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.01);
            }
        }
        [Test]
        public void BARSCOUNT_Test()
        {
            var file = $"{Folder}\\BARSCOUNT.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            var TEST = BARSCOUNT(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void IF_Test()
        {
            var file = $"{Folder}\\IF.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            var TEST = IF(C > O, 1, 0);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void IFN_Test()
        {
            var file = $"{Folder}\\IFN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            var TEST = IFN(C > O, 1, 0);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void VALUEWHEN_Test()
        {
            var file = $"{Folder}\\VALUEWHEN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = VALUEWHEN(C > O, H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void CROSS_Test()
        {
            var file = $"{Folder}\\CROSS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = CROSS(REF(C, 1), C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LONGCROSS_Test()
        {
            var file = $"{Folder}\\LONGCROSS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = LONGCROSS(REF(C, 1), C, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void UPNDAY_Test()
        {
            var file = $"{Folder}\\UPNDAY.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = UPNDAY(C, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void DOWNNDAY_Test()
        {
            var file = $"{Folder}\\DOWNNDAY.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = DOWNNDAY(C, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void NDAY_Test()
        {
            var file = $"{Folder}\\NDAY.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = NDAY(C, O, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void EXIST_Test()
        {
            var file = $"{Folder}\\EXIST.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = EXIST(C > O, 2);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void EXISTR_Test()
        {
            var file = $"{Folder}\\EXISTR.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = EXISTR(C > O, 10, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void EVERY_Test()
        {
            var file = $"{Folder}\\EVERY.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = EVERY(C > O, 2);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }

        [Test]
        public void LAST_Test()
        {
            var file = $"{Folder}\\LAST.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = LAST(C > O, 10, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void ISVALID_Test()
        {
            var file = $"{Folder}\\ISVALID.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ISVALID(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void NOT_Test()
        {
            var file = $"{Folder}\\NOT.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = NOT(C > 4);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void RANGE_Test()
        {
            var file = $"{Folder}\\RANGE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = RANGE(C, 2, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void MAX_Test()
        {
            var file = $"{Folder}\\MAX.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = MAX(C, O);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void MIN_Test()
        {
            var file = $"{Folder}\\MIN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = MIN(C, O);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void ACOS_Test()
        {
            var file = $"{Folder}\\ACOS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ACOS(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void ASIN_Test()
        {
            var file = $"{Folder}\\ASIN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ASIN(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void ATAN_Test()
        {
            var file = $"{Folder}\\ATAN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ATAN(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void COS_Test()
        {
            var file = $"{Folder}\\COS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = COS(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }

        [Test]
        public void SIN_Test()
        {
            var file = $"{Folder}\\SIN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = SIN(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void TAN_Test()
        {
            var file = $"{Folder}\\TAN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = TAN(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void EXP_Test()
        {
            var file = $"{Folder}\\EXP.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = EXP(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LN_Test()
        {
            var file = $"{Folder}\\LN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = LN(C / H);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void LOG_Test()
        {
            var file = $"{Folder}\\LOG.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = LOG(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void SQRT_Test()
        {
            var file = $"{Folder}\\SQRT.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = SQRT(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void ABS_Test()
        {
            var file = $"{Folder}\\ABS.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ABS(C - O);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void POW_Test()
        {
            var file = $"{Folder}\\POW.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = POW(C, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void CEILING_Test()
        {
            var file = $"{Folder}\\CEILING.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = CEILING(C - O);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FLOOR_Test()
        {
            var file = $"{Folder}\\FLOOR.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = FLOOR(C - O);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void INTPART_Test()
        {
            var file = $"{Folder}\\INTPART.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = INTPART(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void BETWEEN_Test()
        {
            var file = $"{Folder}\\BETWEEN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = BETWEEN(C, 2, 3);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FRACPART_Test()
        {
            var file = $"{Folder}\\FRACPART.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = FRACPART(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }

        }
        [Test]
        public void ROUND_Test()
        {
            var file = $"{Folder}\\ROUND.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ROUND(C);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void ROUND2_Test()
        {
            var file = $"{Folder}\\ROUND2.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = ROUND(C, 1);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void SIGN_Test()
        {
            var file = $"{Folder}\\SIGN.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = SIGN(C - O);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void MOD_Test()
        {
            var file = $"{Folder}\\MOD.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = MOD(C, 5);

            // 通达信 MOD 只求 整数

            for (int i = 20; i < TEST.Length; i++) {
               // Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void AVEDEV_Test()
        {
            var file = $"{Folder}\\AVEDEV.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = AVEDEV(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void DEVSQ_Test()
        {
            var file = $"{Folder}\\DEVSQ.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = DEVSQ(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void FORCAST_Test()
        {
            var file = $"{Folder}\\FORCAST.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = FORCAST(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void SLOPE_Test()
        {
            var file = $"{Folder}\\SLOPE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = SLOPE(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void STDP_Test()
        {
            var file = $"{Folder}\\STDP.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = STDP(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void VAR_Test()
        {
            var file = $"{Folder}\\VAR.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = VAR(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
        [Test]
        public void VARP_Test()
        {
            var file = $"{Folder}\\VARP.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = VARP(C, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
    
        [Test]
        public void COVAR_Test()
        {
            var file = $"{Folder}\\COVAR.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = COVAR(C,O, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
         
        }
        [Test]
        public void RELATE_Test()
        {
            var file = $"{Folder}\\RELATE.csv";
            var data = DataTestCsv.ParseFile(file);
            TdxNumber C = data.Select(q => q.CLOSE).ToArray();
            TdxNumber O = data.Select(q => q.OPEN).ToArray();
            TdxNumber H = data.Select(q => q.HIGH).ToArray();
            var TEST = RELATE(C, O, 5);

            for (int i = 20; i < TEST.Length; i++) {
                Assert.AreEqual(TEST[i], data[i].Value, 0.001);
            }
        }
    }
    public class DataTestCsv
    {
        public int DAY;
        public double OPEN;
        public double CLOSE;
        public double HIGH;
        public double LOW;
        public double VOL;
        public double AMO;
        public double CAPITAL;
        public double Value;

        public DateTime GetDateTime()
        {
            var year = DAY / 10000;
            var month = DAY % 10000 / 100;
            var day = DAY % 100;
            return new DateTime(year, month, day);
        }
        public static List<DataTestCsv> ParseFile(string file)
        {
            List<DataTestCsv> result = new List<DataTestCsv>();

            using (var fs = File.OpenText(file)) {
                string line = fs.ReadLine();//跳过第一行
                while ((line = fs.ReadLine()) != null) {
                    result.Add(Parse(line));
                }
            }
            //GC.Collect();
            return result;
        }

        public static DataTestCsv Parse(string line)
        {
            var sp = line.Split(',');
            DataTestCsv data = new DataTestCsv();
            var index = 0;
            data.DAY = int.Parse(sp[index++]);
            data.OPEN = double.Parse(sp[index++]);
            data.CLOSE = double.Parse(sp[index++]);
            data.HIGH = double.Parse(sp[index++]);
            data.LOW = double.Parse(sp[index++]);
            data.VOL = double.Parse(sp[index++]);
            data.AMO = double.Parse(sp[index++]);
            data.CAPITAL = double.Parse(sp[index++]);
            data.Value = double.Parse(sp[index++]);

            return data;
        }
    }
}
