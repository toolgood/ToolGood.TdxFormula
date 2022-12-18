using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToolGood.TdxFormula.Internals.Models;
using System.Threading.Tasks;


namespace ToolGood.TdxFormula.Internals
{
	public class TdxVisitor : AbstractParseTreeVisitor<Operand>, ItdxVisitor<Operand>
	{
		private static readonly CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");
		public event Func<string, Operand> GetParameter;
		public event Action<string, Operand> SetParameter;
		public event Func<List<Dictionary<int, double>>> GetChipDistribution;
		public event Func<List<Dictionary<int, double>>> GetChip;
		public event Func<List<MyDictionary>> GetChipSumArray;
		public event Func<int, double[]> GetChipN;
		public int ArrayCount;

		#region 主流程
		public Operand VisitProg(tdxParser.ProgContext context)
		{
			var lines = context.line();
			foreach (var line in lines) {
				Visit(line);
			}
			return null;
		}
		public Operand VisitLine_fun(tdxParser.Line_funContext context)
		{
			var result = Visit(context.expr());
			var text = context.PARAMETER().GetText();
			if (SetParameter != null) {
				SetParameter.Invoke(text, result);
			}
			return null;
		}
		public Operand VisitNone_fun(tdxParser.None_funContext context)
		{
			return null;
		}
		public Operand VisitColor(tdxParser.ColorContext context)
		{
			return null;
		}
		public Operand VisitDraw(tdxParser.DrawContext context)
		{
			return null;
		}
		public Operand VisitAttach(tdxParser.AttachContext context)
		{
			return null;
		}
		public Operand VisitDRAWNULL_fun(tdxParser.DRAWNULL_funContext context)
		{
			return Operand.Zero;
		}
		#endregion

		#region 运算符优先级
		public Operand VisitBracket_fun(tdxParser.Bracket_funContext context)
		{
			return Visit(context.expr());
		}
		public Operand VisitMulDiv_fun(tdxParser.MulDiv_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var t = context.op.Text;
			if (CharUtil.Equals(t, "*")) {
				return firstValue * secondValue;
			}
			return firstValue / secondValue;
		}
		public Operand VisitAddSub_fun(tdxParser.AddSub_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var t = context.op.Text;
			if (CharUtil.Equals(t, "+")) {
				return firstValue + secondValue;
			}
			return firstValue - secondValue;
		}
		public Operand VisitAndOr_fun(tdxParser.AndOr_funContext context)
		{
			// 程序 && and || or 与 excel的  AND(x,y) OR(x,y) 有区别
			// 在excel内 AND(x,y) OR(x,y) 先报错，
			// 在程序中，&& and  有true 直接返回true 就不会检测下一个会不会报错
			// 在程序中，|| or  有false 直接返回false 就不会检测下一个会不会报错
			var exprs = context.expr();
			var t = context.op.Text;
			var first = this.Visit(exprs[0]);
			if (CharUtil.Equals(t, "&&", "and")) {
				if (first.Type == OperandType.NUMBER) {
					if (first.BooleanValue == false) {
						return Operand.False;
					}
					return this.Visit(exprs[1]);
				}
				var secondValue = this.Visit(exprs[1]);
				if (secondValue.Type == OperandType.NUMBER) {
					if (secondValue.BooleanValue == false) {
						return Operand.False;
					}
					return first;
				}
				MyList array = new MyList(ArrayCount);
				var length = first.ArrayCount;
				for (int i = 0; i < length; i++) {
					array.Add(first.BooleanArrayValue[i] && secondValue.BooleanArrayValue[i] ? 1 : 0);
				}
				return Operand.Create(array);
			} else {
				if (first.Type == OperandType.NUMBER) {
					if (first.BooleanValue) {
						return Operand.True;
					}
					return this.Visit(exprs[1]);
				}
				var secondValue = this.Visit(exprs[1]);
				if (secondValue.Type == OperandType.NUMBER) {
					if (secondValue.BooleanValue) {
						return Operand.True;
					}
					return first;
				}
				MyList array = new MyList(ArrayCount);
				var length = first.ArrayCount;
				for (int i = 0; i < length; i++) {
					array.Add(first.BooleanArrayValue[i] && secondValue.BooleanArrayValue[i] ? 1 : 0);
				}
				return Operand.Create(array);
			}
		}
		public Operand VisitJudge_fun(tdxParser.Judge_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			string type = context.op.Text;
			if (CharUtil.Equals(type, "<")) {
				return firstValue < secondValue;
			} else if (CharUtil.Equals(type, "<=")) {
				return firstValue <= secondValue;
			} else if (CharUtil.Equals(type, ">")) {
				return firstValue > secondValue;
			} else if (CharUtil.Equals(type, ">=")) {
				return firstValue >= secondValue;
			} else if (CharUtil.Equals(type, "=", "==", "===")) {
				return firstValue == secondValue;
			}
			return firstValue != secondValue;
		}
		#endregion

		#region 自定义
		public Operand VisitPARAMETER_fun(tdxParser.PARAMETER_funContext context)
		{
			string text = null;
			if (string.IsNullOrEmpty(text) && context.PARAMETER() != null) { text = context.PARAMETER().GetText(); }
			if (string.IsNullOrEmpty(text) && context.HIGH() != null) { text = context.HIGH().GetText(); }
			if (string.IsNullOrEmpty(text) && context.LOW() != null) { text = context.LOW().GetText(); }
			if (string.IsNullOrEmpty(text) && context.CLOSE() != null) { text = context.CLOSE().GetText(); }
			if (string.IsNullOrEmpty(text) && context.OPEN() != null) { text = context.OPEN().GetText(); }
			if (string.IsNullOrEmpty(text) && context.AMOUNT() != null) { text = context.AMOUNT().GetText(); }
			if (string.IsNullOrEmpty(text) && context.VOL() != null) { text = context.VOL().GetText(); }
			if (string.IsNullOrEmpty(text) && context.INDEXC() != null) { text = context.INDEXC().GetText(); }
			if (string.IsNullOrEmpty(text) && context.INDEXH() != null) { text = context.INDEXH().GetText(); }
			if (string.IsNullOrEmpty(text) && context.INDEXL() != null) { text = context.INDEXL().GetText(); }
			if (string.IsNullOrEmpty(text) && context.INDEXO() != null) { text = context.INDEXO().GetText(); }
			if (string.IsNullOrEmpty(text) && context.INDEXV() != null) { text = context.INDEXV().GetText(); }
			if (string.IsNullOrEmpty(text) && context.INDEXA() != null) { text = context.INDEXA().GetText(); }
			if (string.IsNullOrEmpty(text) && context.DATE() != null) { text = context.DATE().GetText(); }
			if (string.IsNullOrEmpty(text) && context.TIME() != null) { text = context.TIME().GetText(); }
			if (string.IsNullOrEmpty(text) && context.YEAR() != null) { text = context.YEAR().GetText(); }
			if (string.IsNullOrEmpty(text) && context.MONTH() != null) { text = context.MONTH().GetText(); }
			if (string.IsNullOrEmpty(text) && context.WEEKDAY() != null) { text = context.WEEKDAY().GetText(); }
			if (string.IsNullOrEmpty(text) && context.DAY() != null) { text = context.DAY().GetText(); }
			if (string.IsNullOrEmpty(text) && context.HOUR() != null) { text = context.HOUR().GetText(); }
			if (string.IsNullOrEmpty(text) && context.MINUTE() != null) { text = context.MINUTE().GetText(); }
			if (string.IsNullOrEmpty(text) && context.TIME2() != null) { text = context.TIME2().GetText(); }
			if (string.IsNullOrEmpty(text) && context.DAYSTOTODAY() != null) { text = context.DAYSTOTODAY().GetText(); }
			if (string.IsNullOrEmpty(text) && context.TURN() != null) { text = context.TURN().GetText(); }
			if (string.IsNullOrEmpty(text) && context.CAPITAL() != null) { text = context.CAPITAL().GetText(); }

			if (GetParameter != null) {
				//if (context.expr() != null) {
				//    Operand operand = Visit(context.expr());
				//    text += operand.ToText().TextValue;
				//}
				return GetParameter(text);
			}
			throw new Exception("Function PARAMETER first parameter is error!");
		}
		#region PARAMETER REF
		public Operand VisitTURN_REF_fun(tdxParser.TURN_REF_funContext context)
		{
			var X = GetParameter(context.TURN().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitPARAMETER_REF_fun(tdxParser.PARAMETER_REF_funContext context)
		{
			var X = GetParameter(context.PARAMETER().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitINDEXH_REF_fun(tdxParser.INDEXH_REF_funContext context)
		{
			var X = GetParameter(context.INDEXH().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitOPEN_REF_fun(tdxParser.OPEN_REF_funContext context)
		{
			var X = GetParameter(context.OPEN().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitINDEXO_REF_fun(tdxParser.INDEXO_REF_funContext context)
		{
			var X = GetParameter(context.INDEXO().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitAMOUNT_REF_fun(tdxParser.AMOUNT_REF_funContext context)
		{
			var X = GetParameter(context.AMOUNT().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitTR_REF_fun(tdxParser.TR_REF_funContext context)
		{
			var X = VisitTR_fun(null).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitVOL_REF_fun(tdxParser.VOL_REF_funContext context)
		{
			var X = GetParameter(context.NUM().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitINDEXL_REF_fun(tdxParser.INDEXL_REF_funContext context)
		{
			var X = GetParameter(context.INDEXL().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitHIGH_REF_fun(tdxParser.HIGH_REF_funContext context)
		{
			var X = GetParameter(context.HIGH().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitINDEXA_REF_fun(tdxParser.INDEXA_REF_funContext context)
		{
			var X = GetParameter(context.INDEXA().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitINDEXV_REF_fun(tdxParser.INDEXV_REF_funContext context)
		{
			var X = GetParameter(context.INDEXV().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitCLOSE_REF_fun(tdxParser.CLOSE_REF_funContext context)
		{
			var X = GetParameter(context.CLOSE().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitLOW_REF_fun(tdxParser.LOW_REF_funContext context)
		{
			var X = GetParameter(context.LOW().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitINDEXC_REF_fun(tdxParser.INDEXC_REF_funContext context)
		{
			var X = GetParameter(context.INDEXC().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitMINUTE_REF_fun(tdxParser.MINUTE_REF_funContext context)
		{
			var X = GetParameter(context.MINUTE().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitTIME_REF_fun(tdxParser.TIME_REF_funContext context)
		{
			var X = GetParameter(context.TIME().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitMONTH_REF_fun(tdxParser.MONTH_REF_funContext context)
		{
			var X = GetParameter(context.MONTH().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitWEEKDAY_REF_fun(tdxParser.WEEKDAY_REF_funContext context)
		{
			var X = GetParameter(context.WEEKDAY().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitDAY_REF_fun(tdxParser.DAY_REF_funContext context)
		{
			var X = GetParameter(context.DAY().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitHOUR_REF_fun(tdxParser.HOUR_REF_funContext context)
		{
			var X = GetParameter(context.HOUR().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitYEAR_REF_fun(tdxParser.YEAR_REF_funContext context)
		{
			var X = GetParameter(context.YEAR().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitDATE_REF_fun(tdxParser.DATE_REF_funContext context)
		{
			var X = GetParameter(context.DATE().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitTIME2_REF_fun(tdxParser.TIME2_REF_funContext context)
		{
			var X = GetParameter(context.TIME2().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		public Operand VisitDAYSTOTODAY_REF_fun(tdxParser.DAYSTOTODAY_REF_funContext context)
		{
			var X = GetParameter(context.DAYSTOTODAY().GetText()).NumberArrayValue;
			var N = (int)double.Parse(context.NUM().GetText());
			return MyMath.REF(X, N);
		}
		#endregion
		public Operand VisitNUM_fun(tdxParser.NUM_funContext context)
		{
			var sub = context.SUB()?.GetText() ?? "";
			var t = context.NUM().GetText();
			var d = double.Parse(sub + t, NumberStyles.Any, cultureInfo);
			return Operand.Create(d);
		}
		/// <summary>
		/// 求真实波幅.
		/// 用法:
		/// TR,求真实波幅.
		/// 例如:ATR:=MA(TR,10);
		/// 表示求真实波幅的10周期均值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitTR_fun(tdxParser.TR_funContext context)
		{
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;

			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < ArrayCount; i++) {
				var c = i > 0 ? CLOSE[i - 1] : CLOSE[0];
				var t = MyMath.Max(HIGH[i] - LOW[i], Math.Abs(c - HIGH[i]), Math.Abs(c - LOW[i]));
				array.Add(t);
			}
			return Operand.Create(array);
		}
		#endregion
		#region 引用函数
		/// <summary>
		/// 上一次条件成立到当前的周期数.
		/// 用法:
		/// BARSLAST(X) :上一次X不为0到现在的周期数
		/// 例如:
		/// BARSLAST(CLOSE/REF(CLOSE,1)>=1.1)表示上一个涨停板到当前的周期数
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitBARSLAST_fun(tdxParser.BARSLAST_funContext context)
		{
			var firstValue = Visit(context.expr());
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			int count = 0;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (X[i]) {
					count = 0;
				} else {
					count++;
				}
				array.Add((double)count);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 统计连续满足条件的周期数.
		/// 用法:
		/// BARSLASTCOUNT(X),统计连续满足X条件的周期数.
		/// 例如:
		/// BARSLASTCOUNT(CLOSE>OPEN)表示统计连续收阳的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitBARSLASTCOUNT_fun(tdxParser.BARSLASTCOUNT_funContext context)
		{
			var firstValue = Visit(context.expr());
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			int count = 0;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (X[i] == false) {
					count = 0;
				} else {
					count++;
				}
				array.Add((double)count);
			}
			return Operand.Create(array);
		}
		public Operand VisitBARSCOUNT_fun(tdxParser.BARSCOUNT_funContext context)
		{
			var firstValue = Visit(context.expr());
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			bool b = false;
			int count = -1;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (b) {
					count++;
				} else if (X[i]) {
					count++;
					b = true;
				}
				array.Add((double)count);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 第一个条件成立到当前的周期数.
		/// 用法:
		/// BARSSINCE(X) :第一次X不为0到现在的周期数
		/// 例如:
		/// BARSSINCE(HIGH>10)表示股价超过10元时到当前的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitBARSSINCE_fun(tdxParser.BARSSINCE_funContext context)
		{
			var firstValue = Visit(context.expr());
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			int count = -1;
			bool first = false;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (first) {
					count++;
				} else if (X[i]) {
					first = true;
					count = 0;
				}
				array.Add((double)count);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// N周期内第一个条件成立到当前的周期数.
		/// 用法:
		/// BARSSINCEN(X, N) :N周期内第一次X不为0到现在的周期数,N为常量
		/// 例如:
		/// BARSSINCEN(HIGH>10,10)表示10个周期内股价超过10元时到当前的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitBARSSINCEN_fun(tdxParser.BARSSINCEN_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.BARSSINCEN(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 统计满足条件的周期数.
		/// 用法:
		/// COUNT(X, N),统计N周期中满足X条件的周期数,若N<0则从第一个有效值开始.
		/// 例如:
		/// COUNT(CLOSE>OPEN,20)表示统计20周期内收阳的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitCOUNT_fun(tdxParser.COUNT_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.COUNT(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求最高值.
		/// 用法:
		/// HHV(X, N),求N周期内X最高值,N=0则从第一个有效值开始.
		/// 例如:
		/// HHV(HIGH,30)表示求30日最高价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitHHV_fun(tdxParser.HHV_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.HHV(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求上一高点到当前的周期数.
		/// 用法:
		/// HHVBARS(X, N) :求N周期内X最高值到当前周期数,N=0表示从第一个有效值开始统计
		/// 例如:
		/// HHVBARS(HIGH,0)求得历史新高到到当前的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitHHVBARS_fun(tdxParser.HHVBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.HHVBARS(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求最低值.
		/// 用法:
		///  LLV(X, N),求N周期内X最低值,N=0则从第一个有效值开始.
		/// 例如:
		/// LLV(LOW,0)表示求历史最低价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLLV_fun(tdxParser.LLV_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.LLV(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求上一低点到当前的周期数.
		/// 用法:
		/// LLVBARS(X, N) :求N周期内X最低值到当前周期数,N=0表示从第一个有效值开始统计
		/// 例如:
		/// LLVBARS(HIGH,20)求得20日最低点到当前的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLLVBARS_fun(tdxParser.LLVBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.LLVBARS(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求相反数.
		/// 用法:
		/// REVERSE(X)返回-X.
		/// 例如:
		/// REVERSE(CLOSE)返回-CLOSE
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitREVERSE_fun(tdxParser.REVERSE_funContext context)
		{
			var first = Visit(context.expr());
			MyList array = new MyList(ArrayCount);
			foreach (var item in first.NumberArrayValue) {
				array.Add(-item);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 引用若干周期前的数据.
		/// 用法:
		/// REF(X, A),引用A周期前的X值.A可以是变量.
		/// 例如:
		/// REF(CLOSE, BARSCOUNT(C)-1)表示第二根K线的收盘价.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitREF_fun(tdxParser.REF_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.REF(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 引用若干周期前的数据(平滑处理).
		/// 用法:
		/// REFV(X, A),引用A周期前的X值.A可以是变量.
		/// 例如:
		/// REFV(CLOSE, BARSCOUNT(C)-1)表示第二根K线的收盘价.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitREFV_fun(tdxParser.REFV_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var A = secondValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(X[Math.Max(i - (int)A[i], 0)]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求总和.
		/// 用法:
		/// SUM(X, N),统计N周期中X的总和,N=0则从第一个有效值开始.
		///  例如:
		/// SUM(VOL,0)表示统计从上市第一天以来的成交量总和
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSUM_fun(tdxParser.SUM_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.SUM(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 向前累加到指定值到现在的周期数.
		/// 用法:
		/// SUMBARS(X, A) :将X向前累加直到大于等于A,返回这个区间的周期数,若所有的数据都累加后还不能达到A,则返回此时前面的总周期数.
		/// 例如:SUMBARS(VOL, CAPITAL)求完全换手到现在的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSUMBARS_fun(tdxParser.SUMBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.SUMBARS(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回移动平均
		/// 用法:
		/// SMA(X, N, M) :X的N日移动平均,M为权重,如Y=(X* M+Y'*(N-M))/N
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSMA_fun(tdxParser.SMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var N = secondValue.IntValue;
			var M = thirdValue.NumberValue;
			MyList array = new MyList(ArrayCount);
			double Y = 0.0;
			for (int i = 0; i < length; i++) {
				Y = (X[i] * M + Y * (N - M)) / N;
				array.Add(Y);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回简单移动平均
		/// 用法:
		/// MA(X, N) :X的N日简单移动平均,算法(X1+X2+X3+...+Xn)/N,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMA_fun(tdxParser.MA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.MA(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回移动平均
		/// 用法:
		/// TMA(X, A, B),A和B必须小于1,算法 Y = (A * Y'+B*X),其中Y'表示上一周期Y值.初值为X
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitTMA_fun(tdxParser.TMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var A = secondValue.NumberValue;
			if (A >= 1) { throw new Exception("Function TMA parameter A is error."); }
			var B = thirdValue.NumberValue;
			if (B >= 1) { throw new Exception("Function TMA parameter B is error."); }
			MyList array = new MyList(ArrayCount);
			double Y = 0.0;
			for (int i = 0; i < length; i++) {
				Y = (A * Y + B * X[i]);
				array.Add(Y);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回指数移动平均
		/// 用法:
		/// EMA(X, N) :X的N日指数移动平均.算法:Y=(X*2+Y'*(N-1))/(N+1)
		/// EMA(X, N)相当于SMA(X, N+1,2),N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitEMA_fun(tdxParser.EMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.EMA(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回平滑移动平均
		/// 用法:
		/// MEMA(X, N) :X的N日平滑移动平均,如Y=(X+Y'*(N-1))/N
		/// MEMA(X, N)相当于SMA(X, N,1)
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMEMA_fun(tdxParser.MEMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.MEMA(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求自适应均线值.
		/// 用法:
		/// AMA(X, A),A为自适应系数,必须小于1.
		/// 算法:
		/// Y=Y'+A*(X-Y').初值为X
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitAMA_fun(tdxParser.AMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var A = secondValue.NumberValue;
			if (A >= 1 || A < 0) { throw new Exception("Function TMA parameter B is error."); }
			MyList array = new MyList(ArrayCount);
			double Y = X[0];
			for (int i = 0; i < length; i++) {
				Y += A * (X[i] - Y);
				array.Add(Y);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求动态移动平均.
		/// 用法:
		/// DMA(X, A),求X的动态移动平均.
		/// 算法:Y=A* X+(1-A)*Y',其中Y'表示上一周期Y值,A必须大于0且小于1.A支持变量.
		/// 例如:
		/// DMA(CLOSE, VOL/CAPITAL)表示求以换手率作平滑因子的平均价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitDMA_fun(tdxParser.DMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			if (secondValue.Type == OperandType.ARRARY_NUMBER) {
				return Operand.Create(MyMath.DMA(X, secondValue.NumberArrayValue));
			}
			return Operand.Create(MyMath.DMA(X, secondValue.NumberValue));
		}
		/// <summary>
		/// 返回加权移动平均
		/// 用法:
		/// WMA(X, N) :X的N日加权移动平均.算法:Yn=(1*X1+2*X2+...+n* Xn)/(1+2+...+n)
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitWMA_fun(tdxParser.WMA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.WMA(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// RANGE(A,B,C):A在B和C范围之间,B<A<C.
		/// 用法:
		/// RANGE(A, B, C)表示A大于B同时小于C时返回1,否则返回0
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitRANGE_fun(tdxParser.RANGE_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var B = secondValue.NumberValue;
			var C = thirdValue.NumberValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(X[i] > B && X[i] < C ? 1 : 0);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 当前值是近多少周期内的最小值.
		/// 用法:
		/// LOWRANGE(X) :X是近多少周期内X的最小值
		/// 例如:
		/// LOWRANGE(LOW)表示当前最低价是近多少周期内最低价的最小值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLOWRANGE_fun(tdxParser.LOWRANGE_funContext context)
		{
			var firstValue = Visit(context.expr());
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				int index = 0;
				var num = X[i];
				for (int j = i - 1; j >= 0; j--) {
					if (num >= X[j]) {
						break;
					}
					index++;
				}
				array.Add(index);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 当前值是近多少周期内的最大值.
		/// 用法:
		/// TOPRANGE(X) :X是近多少周期内X的最大值
		/// 例如:
		/// TOPRANGE(HIGH)表示当前最高价是近多少周期内最高价的最大值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitTOPRANGE_fun(tdxParser.TOPRANGE_funContext context)
		{
			var firstValue = Visit(context.expr());
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				int index = 0;
				var num = X[i];
				for (int j = i - 1; j >= 0; j--) {
					if (num <= X[j]) {
						break;
					}
					index++;
				}
				array.Add(index);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 过滤连续出现的信号.
		/// 用法:FILTER(X, N) :X满足条件后,将其后N周期内的数据置为0,N为常量.
		/// 例如:
		/// FILTER(CLOSE>OPEN,5)查找阳线,5天内再次出现的阳线不被记录在内
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFILTER_fun(tdxParser.FILTER_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.FILTER(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 反向过滤连续出现的信号.
		/// 用法:FILTERX(X, N) :X满足条件后,将其前N周期内的数据置为0,N为常量.
		/// 例如:
		/// FILTERX(CLOSE>OPEN,5)查找阳线,前5天内出现过的阳线不被记录在内
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFILTERX_fun(tdxParser.FILTERX_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.FILTERX(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// CONST(A):取A最后的值为常量.
		/// 用法:
		/// CONST(INDEXC)表示取指数现价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitCONST_fun(tdxParser.CONST_funContext context)
		{
			var firstValue = Visit(context.expr());
			var X = firstValue.NumberArrayValue;
			var length = firstValue.ArrayCount;
			var x = X[length - 1];
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(x);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求高值名次.
		/// 用法:
		/// HOD(X, N) :求当前X数据是N周期内的第几个高值,N=0则从第一个有效值开始.
		/// 例如:
		/// HOD(HIGH,20)返回是20日的第几个高价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitHOD_fun(tdxParser.HOD_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.HOD(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求低值名次.
		/// 用法:
		/// LOD(X, N) :求当前X数据是N周期内的第几个低值,N=0则从第一个有效值开始.
		/// 例如:
		/// LOD(LOW,20)返回是20日的第几个低价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLOD_fun(tdxParser.LOD_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.LOD(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 求累乘.
		/// 用法:
		/// MULAR(X, N),统计N周期中X的乘积.N=0则从第一个有效值开始.
		/// 例如:
		/// MULAR(C/REF(C,1),0)表示统计从上市第一天以来的复利
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMULAR_fun(tdxParser.MULAR_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.MULAR(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// N周期前的M周期内的第T个最大值.
		/// 用法:
		/// FINDHIGH(VAR, N, M, T) :VAR在N日前的M天内第T个最高价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFINDHIGH_fun(tdxParser.FINDHIGH_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var fourthValue = args[3];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var N = secondValue.IntValue;
			var M = thirdValue.IntValue;
			var T = fourthValue.IntValue;
			MyList array = new MyList(ArrayCount);
			MyList temp = new MyList(ArrayCount);
			for (int i = 0; i < M - 1; i++) {
				MyMath.InsertArray_Max2Min(temp, X[i]);
				array.Add(0);
			}
			var e = M + N;
			for (int i = M - 1; i < e - 1; i++) {
				array.Add(0);
			}
			for (int i = e - 1; i < length; i++) {
				//var x = X[i - N];
				MyMath.InsertArray_Max2Min(temp, X[i - N]);
				var t = temp[T - 1];
				array.Add(t);
				temp.Remove(X[i - e + 1]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// N周期前的M周期内的第T个最小值.
		/// 用法:
		/// FINDLOW(VAR, N, M, T) :VAR在N日前的M天内第T个最低价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFINDLOW_fun(tdxParser.FINDLOW_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var fourthValue = args[3];
			var length = firstValue.ArrayCount;
			var X = firstValue.NumberArrayValue;
			var N = secondValue.IntValue;
			var M = thirdValue.IntValue;
			var T = fourthValue.IntValue;
			MyList array = new MyList(ArrayCount);
			MyList temp = new MyList(ArrayCount);
			for (int i = 0; i < M - 1; i++) {
				var x = X[i];
				MyMath.InsertArray_Min2Max(temp, x);
				array.Add(0);
			}
			var e = M + N;
			for (int i = M - 1; i < e - 1; i++) {
				array.Add(0);
			}
			for (int i = e - 1; i < length; i++) {
				MyMath.InsertArray_Min2Max(temp, X[i - N]);
				var t = temp[T - 1];
				array.Add(t);
				temp.Remove(X[i - e + 1]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// N周期前的M周期内的第T个最大值到当前周期的周期数.
		/// 用法:
		/// FINDHIGHBARS(VAR, N, M, T) :VAR在N日前的M天内第T个最高价到当前周期的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFINDHIGHBARS_fun(tdxParser.FINDHIGHBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var fourthValue = args[3];
			var X = firstValue.NumberArrayValue;
			var length = firstValue.ArrayCount;
			var N = secondValue.IntValue;
			var M = thirdValue.IntValue;
			var T = fourthValue.IntValue;
			MyList array = new MyList(ArrayCount);
			MyList temp = new MyList(ArrayCount);
			for (int i = 0; i < M - 1; i++) {
				MyMath.InsertArray_Max2Min(temp, X[i]);
				array.Add(-1);
			}
			var e = M + N;
			for (int i = M - 1; i < e - 1; i++) {
				array.Add(-1);
			}
			for (int i = e - 1; i < length; i++) {
				MyMath.InsertArray_Max2Min(temp, X[i - N]);
				var t = temp[T - 1];
				int count = N;
				for (int j = i - N; j >= Math.Max(0, i - e); j--) {
					var y = X[j];
					if (Math.Round(y - t, 12, MidpointRounding.AwayFromZero) == 0) break;
					count++;
				}
				array.Add(count);
				temp.Remove(X[i - e + 1]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// N周期前的M周期内的第T个最小值到当前周期的周期数.
		/// 用法:
		/// FINDLOWBARS(VAR, N, M, T) :VAR在N日前的M天内第T个最低价到当前周期的周期数.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFINDLOWBARS_fun(tdxParser.FINDLOWBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var fourthValue = args[3];
			var X = firstValue.NumberArrayValue;
			var length = firstValue.ArrayCount;
			var N = secondValue.IntValue;
			var M = thirdValue.IntValue;
			var T = fourthValue.IntValue;
			MyList array = new MyList(ArrayCount);
			MyList temp = new MyList(ArrayCount);
			for (int i = 0; i < M - 1; i++) {
				MyMath.InsertArray_Min2Max(temp, X[i]);
				array.Add(-1);
			}
			var e = M + N;
			for (int i = M - 1; i < e - 1; i++) {
				array.Add(-1);
			}
			for (int i = e - 1; i < length; i++) {
				MyMath.InsertArray_Min2Max(temp, X[i - N]);
				var t = temp[T - 1];
				int count = N;
				for (int j = i - N; j >= Math.Max(0, i - e); j--) {
					var y = X[j];
					if (Math.Round(y - t, 12, MidpointRounding.AwayFromZero) == 0) break;
					count++;
				}
				array.Add(count);
				temp.Remove(X[i - e + 1]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回涨停价
		/// 用法:
		/// ZTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的涨停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与涨停价不符)
		/// 比如:
		/// ZTPrice(REF(QHJSJ,1),0.1),得到期货的涨停价
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitZTPRICE_fun(tdxParser.ZTPRICE_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = DoubleFunc(secondValue, (N) => {
				return MyMath.ZTPRICE(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回跌停价
		/// 用法:
		/// DTPRICE(REF(CLOSE,1),0.1):按10%计算得到在昨收盘基础上的跌停价(对于复权序列K线, 由于复权处理, 根据前一天的收盘价计算结果可能与跌停价不符)
		/// 比如:
		/// DTPrice(REF(QHJSJ,1),0.6),得到期货的跌停价(跌停比例为0.6的话)
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitDTPRICE_fun(tdxParser.DTPRICE_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = DoubleFunc(secondValue, (N) => {
				return MyMath.DTPRICE(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,将当前位置到若干周期前的数据设为1.
		/// 用法:
		/// BACKSET(X, N),若X非0,则将当前位置到N周期前的数值设为1.
		/// 例如:
		/// BACKSET(CLOSE>OPEN,2)若收阳则将该周期及前一周期数值设为1,否则为0
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitBACKSET_fun(tdxParser.BACKSET_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var N = secondValue.NumberValue;
			MyList array = new MyList(0, ArrayCount);

			for (int i = ArrayCount - 1; i >= 0; i--) {
				if (X[i]) {
					for (int j = 0; j < N; j++) {
						array[i - j] = 1;
					}
				}
			}
			return Operand.Create(array);
		}
		public Operand VisitLOD_EXT_fun(tdxParser.LOD_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) { args[i] = args[i].ToNumber(length); }
			var N = (int)double.Parse(context.GetText());
			MyList array = new MyList(ArrayCount);
			MyList temp = new MyList(ArrayCount); // 从小到大
			if (N == 0) {
				for (int i = 0; i < length; i++) {
					for (int j = args.Count - 1; j >= 0; j--) {
						var x = args[j].NumberArrayValue[i];
						var sort = MyMath.InsertArray_Min2Max(temp, x);
						if (j == 0) {
							array.Add(sort);
						}
					}
				}
				return Operand.Create(array);
			}
			for (int i = 0; i < Math.Min(N, length); i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					var x = args[j].NumberArrayValue[i];
					var sort = MyMath.InsertArray_Min2Max(temp, x);
					if (j == 0) {
						array.Add(sort);
					}
				}
			}
			for (int i = N; i < length; i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					temp.Remove(args[j].NumberArrayValue[i - N]);
					var x = args[j].NumberArrayValue[i];
					var sort = MyMath.InsertArray_Min2Max(temp, x);
					if (j == 0) {
						array.Add(sort);
					}
				}
			}
			return Operand.Create(array);
		}
		public Operand VisitHOD_EXT_fun(tdxParser.HOD_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) { args[i] = args[i].ToNumber(length); }
			var N = (int)double.Parse(context.NUM().GetText());
			MyList array = new MyList(ArrayCount);
			MyList temp = new MyList(ArrayCount); // 从小到大
			if (N == 0) {
				for (int i = 0; i < length; i++) {
					for (int j = args.Count - 1; j >= 0; j--) {
						var x = args[j].NumberArrayValue[i];
						var sort = MyMath.InsertArray_Max2Min(temp, x);
						if (j == 0) {
							array.Add(sort);
						}
					}
				}
				return Operand.Create(array);
			}
			for (int i = 0; i < Math.Min(N, length); i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					var x = args[j].NumberArrayValue[i];
					var sort = MyMath.InsertArray_Max2Min(temp, x);
					if (j == 0) {
						array.Add(sort);
					}
				}
			}
			for (int i = N; i < length; i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					temp.Remove(args[j].NumberArrayValue[i - N]);
					var x = args[j].NumberArrayValue[i];
					var sort = MyMath.InsertArray_Max2Min(temp, x);
					if (j == 0) {
						array.Add(sort);
					}
				}
			}
			return Operand.Create(array);
		}
		public Operand VisitSUM_EXT_fun(tdxParser.SUM_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) { args[i] = args[i].ToNumber(length); }
			var N = (int)double.Parse(context.GetText());
			MyList array = new MyList(ArrayCount);
			double sum = 0;
			if (N <= 0) {
				for (int i = 0; i < length; i++) {
					for (int j = args.Count - 1; j >= 0; j--) {
						sum += args[j].NumberArrayValue[i];
						if (j == 0) {
							array.Add(sum);
						}
					}
				}
				return Operand.Create(array);
			}
			for (int i = 0; i < Math.Min(N, length); i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					sum += args[j].NumberArrayValue[i];
					if (j == 0) {
						array.Add(sum);
					}
				}
			}
			for (int i = N; i < length; i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					sum += args[j].NumberArrayValue[i];
					sum -= args[j].NumberArrayValue[i - N];
					if (j == 0) {
						array.Add(sum);
					}
				}
			}
			return Operand.Create(array);
		}
		public Operand VisitLLV_EXT_fun(tdxParser.LLV_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) { args[i] = args[i].ToNumber(length); }
			var N = (int)double.Parse(context.GetText());
			MyList array = new MyList(ArrayCount);
			double min = double.MaxValue;
			if (N <= 0) {
				for (int i = 0; i < length; i++) {
					for (int j = args.Count - 1; j >= 0; j--) {
						var x = args[j].NumberArrayValue[i];
						if (x < min) { min = x; }
						if (j == 0) {
							array.Add(min);
						}
					}
				}
				return Operand.Create(array);
			}
			for (int i = 0; i < Math.Min(N, length); i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					var x = args[j].NumberArrayValue[i];
					if (x < min) { min = x; }
					if (j == 0) {
						array.Add(min);
					}
				}
			}
			for (int i = N; i < length; i++) {
				double[] temp = new double[args.Count];
				for (int j = 0; j < args.Count; j++) {
					temp[j] = args[j].NumberArrayValue[i - N];
				}
				if (temp.Min() < min) {
					min = temp.Min();
				} else if (temp.Contains(min)) {
					min = double.MaxValue;
					for (int j = i - N + 1; j <= i; j++) {
						for (int k = args.Count - 1; k >= 0; k--) {
							if (args[k].NumberArrayValue[j] < min) min = args[k].NumberArrayValue[j];
						}
					}
				}
				array.Add(min);
			}
			return Operand.Create(array);
		}
		public Operand VisitHHV_EXT_fun(tdxParser.HHV_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) { args[i] = args[i].ToNumber(length); }
			var N = (int)double.Parse(context.GetText());
			MyList array = new MyList(ArrayCount);
			double max = 0;
			if (N <= 0) {
				for (int i = 0; i < length; i++) {
					for (int j = args.Count - 1; j >= 0; j--) {
						var x = args[j].NumberArrayValue[i];
						if (x > max) { max = x; }
						if (j == 0) {
							array.Add(max);
						}
					}
				}
				return Operand.Create(array);
			}
			for (int i = 0; i < Math.Min(N, length); i++) {
				for (int j = args.Count - 1; j >= 0; j--) {
					var x = args[j].NumberArrayValue[i];
					if (x > max) { max = x; }
					if (j == 0) {
						array.Add(max);
					}
				}
			}
			for (int i = N; i < length; i++) {
				double[] temp = new double[args.Count];
				for (int j = 0; j < args.Count; j++) {
					temp[j] = args[j].NumberArrayValue[i - N];
				}
				if (temp.Min() < max) {
					max = temp.Min();
				} else if (temp.Contains(max)) {
					max = double.MaxValue;
					for (int j = i - N + 1; j <= i; j++) {
						for (int k = args.Count - 1; k >= 0; k--) {
							if (args[k].NumberArrayValue[j] > max) max = args[k].NumberArrayValue[j];
						}
					}
				}
				array.Add(max);
			}
			return Operand.Create(array);
		}
		#endregion
		#region 逻辑函数
		/// <summary>
		/// 两条线交叉.
		/// 用法:
		/// CROSS(A, B)表示当A从下方向上穿过B时返回1,否则返回0
		/// 例如:
		/// CROSS(MA(CLOSE,5),MA(CLOSE,10))表示5日均线与10日均线交金叉
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitCROSS_fun(tdxParser.CROSS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount);
			var X = firstValue.ToNumber(length).NumberArrayValue;
			var Y = secondValue.ToNumber(length).NumberArrayValue;
			List<double> array = new List<double> { 0 };
			for (int i = 1; i < length; i++) {
				bool b = false;
				if (X[i - 1] < Y[i - 1]) {
					if (X[i] >= Y[i]) {
						b = true;
					}
				}
				array.Add(b ? 1 : 0);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 两条线维持一定周期后交叉.
		/// 用法:LONGCROSS(A, B, N)表示A在N周期内都小于B,本周期从下方向上穿过B时返回1,否则返回0
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLONGCROSS_fun(tdxParser.LONGCROSS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var A = firstValue.NumberArrayValue;
			var length = A.Count;
			var B = secondValue.NumberArrayValue;
			var N = thirdValue.IntValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i <= N; i++) {
				array.Add(0);
			}
			for (int i = N + 1; i < length; i++) {
				bool b = false;
				if (A[i] >= B[i]) {
					b = true;
					for (int j = 0; j < N; j++) {
						if (A[i - 1 - j] >= B[i - 1 - j]) {
							b = false;
							break;
						}
					}
				}
				array.Add(b ? 1 : 0);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回周期数内是否连涨.
		/// 用法:
		/// UPNDAY(CLOSE, M)
		/// 表示连涨M个周期,M为常量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitUPNDAY_fun(tdxParser.UPNDAY_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.UPNDAY(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回周期数内是否连跌.
		/// 用法:
		/// DOWNNDAY(CLOSE, M)
		/// 表示连跌M个周期,M为常量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitDOWNNDAY_fun(tdxParser.DOWNNDAY_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.DOWNNDAY(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 返回周期数内是否连涨.
		/// 用法:
		/// UPNDAY(CLOSE, M)
		/// 表示连涨M个周期,M为常量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitNDAY_fun(tdxParser.NDAY_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var X = firstValue.NumberArrayValue;
			var Y = secondValue.NumberArrayValue;
			var array = IntFunc(thirdValue, (N) => {
				return MyMath.NDAY(X, Y, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 是否存在.
		/// 例如:
		/// EXIST(CLOSE>OPEN,10)
		/// 表示10日内存在着阳线,第2个参数为常量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitEXIST_fun(tdxParser.EXIST_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.EXIST(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// EXISTR(X,A,B):是否存在(前几日到前几日间).
		/// 例如:
		/// EXISTR(CLOSE>OPEN,10,5)
		/// 表示从前10日内到前5日内存在着阳线
		/// 若A为0, 表示从第一天开始, B为0, 表示到最后日止, 第2,3个参数为常量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitEXISTR_fun(tdxParser.EXISTR_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			var N = secondValue.IntValue;
			var M = thirdValue.IntValue;
			MyList array = new MyList(ArrayCount);
			if (M > N) {
				(M, N) = (N, M);
			}
			for (int i = 0; i < length; i++) {
				bool b = false;
				for (int j = MyMath.Max(i - N, 0); j <= MyMath.Max(i - M, 0); j++) {
					if (X[j]) {
						b = true;
						break;
					}
				}
				array.Add(b ? 1 : 0);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 一直存在.
		/// 例如:
		/// EVERY(CLOSE>OPEN, N)
		/// 表示N日内一直阳线(N应大于0, 小于总周期数, N支持变量)
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitEVERY_fun(tdxParser.EVERY_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.EVERY(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// LAST(X,A,B):持续存在.
		/// 例如:
		/// LAST(CLOSE>OPEN,10,5)
		/// 表示从前10日到前5日内一直阳线
		/// 若A为0, 表示从第一天开始, B为0, 表示到最后日止
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLAST_fun(tdxParser.LAST_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			var N = secondValue.IntValue;
			var M = thirdValue.IntValue;
			MyList array = new MyList(ArrayCount);
			if (M > N) {
				(M, N) = (N, M);
			}
			for (int i = 0; i < length; i++) {
				bool b = true;
				for (int j = MyMath.Max(i - N, 0); j <= MyMath.Max(i - M, 0); j++) {
					if (X[j] == false) {
						b = false;
						break;
					}
				}
				array.Add(b ? 1 : 0);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 判断是否是有效数值.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitISVALID_fun(tdxParser.ISVALID_funContext context)
		{
			var firstValue = Visit(context.expr());
			var length = firstValue.ArrayCount;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(1);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求逻辑非.
		/// 用法:
		/// NOT(X)返回非X,即当X=0时返回1,否则返回0
		/// 例如:
		/// NOT(ISUP)表示平盘或收阴
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitNOT_fun(tdxParser.NOT_funContext context)
		{
			var firstValue = Visit(context.expr());
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				bool b = !X[i];
				array.Add(b ? 1 : 0);
			}
			return Operand.Create(array);
		}
		#endregion
		#region 算术函数
		/// <summary>
		/// 根据条件求不同的值.
		/// 用法:
		/// IF(X, A, B)若X不为0则返回A,否则返回B
		/// 例如:
		/// IF(CLOSE>OPEN, HIGH, LOW)表示该周期收阳则返回最高值,否则返回最低值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitIF_fun(tdxParser.IF_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			if (firstValue.Type == OperandType.NUMBER) {
				return (firstValue.BooleanValue ? secondValue : thirdValue);
			}
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			var A = secondValue.ToNumber(length).NumberArrayValue;
			var B = thirdValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (X[i]) {
					array.Add(A[i]);
				} else {
					array.Add(B[i]);
				}
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 根据条件求不同的值,同IF判断相反.
		/// 用法:
		/// IFN(X, A, B)若X不为0则返回B,否则返回A
		/// 例如:
		/// IFN(CLOSE>OPEN, HIGH, LOW)表示该周期收阴则返回最高值,否则返回最低值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitIFN_fun(tdxParser.IFN_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			if (firstValue.Type == OperandType.NUMBER) {
				return (firstValue.BooleanValue ? thirdValue : secondValue);
			}
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			var A = secondValue.ToNumber(length).NumberArrayValue;
			var B = thirdValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (X[i] == false) {
					array.Add(A[i]);
				} else {
					array.Add(B[i]);
				}
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// VALUEWHEN(COND,X) 
		/// 当COND条件成立时,取X的当前值,否则取VALUEWHEN的上个值.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitVALUEWHEN_fun(tdxParser.VALUEWHEN_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.BooleanArrayValue;
			var length = firstValue.ArrayCount;
			var A = secondValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			double last = -1;
			for (int i = 0; i < length; i++) {
				if (X[i]) {
					last = A[i];
				}
				array.Add(last);
			}
			return Operand.Create(array);
		}
		#endregion
		#region 数学函数
		/// <summary>
		/// 求最大值.
		/// 用法:
		/// MAX(A, B)返回A和B中的较大值
		/// 例如:
		/// MAX(CLOSE-OPEN,0)表示若收盘价大于开盘价返回它们的差值,否则返回0
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMAX_fun(tdxParser.MAX_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount);
			if (length == -1) {
				return (firstValue.NumberValue > secondValue.NumberValue ? firstValue : secondValue);
			}
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (A[i] > B[i]) {
					array.Add(A[i]);
				} else {
					array.Add(B[i]);
				}
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求6个参数中的最大值.
		/// 用法:
		/// MAX6(A, B, C, D, E, F)返回较大值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMAX6_fun(tdxParser.MAX6_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var fourthValue = args[3];
			var fifthValue = args[4];
			var sixthValue = args[5];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount, thirdValue.ArrayCount, fourthValue.ArrayCount, fifthValue.ArrayCount, sixthValue.ArrayCount);
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			var C = thirdValue.ToNumber(length).NumberArrayValue;
			var D = fourthValue.ToNumber(length).NumberArrayValue;
			var E = fifthValue.ToNumber(length).NumberArrayValue;
			var F = sixthValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(MyMath.Max(A[i], B[i], C[i], D[i], E[i], F[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 取得该周期的分钟数.
		/// 用法:
		/// MINUTE
		/// 函数返回有效值范围为(0-59),对于日线及更长的分析周期值为0
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMIN_fun(tdxParser.MIN_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount);
			if (length == -1) {
				return (firstValue.NumberValue < secondValue.NumberValue ? firstValue : secondValue);
			}
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				if (A[i] < B[i]) {
					array.Add(A[i]);
				} else {
					array.Add(B[i]);
				}
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求6个参数中的最小值.
		/// 用法:
		/// MIN6(A, B, C, D, E, F)返回较小值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMIN6_fun(tdxParser.MIN6_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var fourthValue = args[3];
			var fifthValue = args[4];
			var sixthValue = args[5];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount, thirdValue.ArrayCount, fourthValue.ArrayCount, fifthValue.ArrayCount, sixthValue.ArrayCount);
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			var C = thirdValue.ToNumber(length).NumberArrayValue;
			var D = fourthValue.ToNumber(length).NumberArrayValue;
			var E = fifthValue.ToNumber(length).NumberArrayValue;
			var F = sixthValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(MyMath.Min(A[i], B[i], C[i], D[i], E[i], F[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 反余弦值.
		/// 用法:
		/// ACOS(X)返回X的反余弦值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitACOS_fun(tdxParser.ACOS_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Acos(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Acos(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 反正弦值.
		/// 用法:
		/// ASIN(X)返回X的反正弦值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitASIN_fun(tdxParser.ASIN_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Asin(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Asin(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 反正切值.
		/// 用法:
		/// ATAN(X)返回X的反正切值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitATAN_fun(tdxParser.ATAN_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Atan(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Atan(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 反余弦值.
		/// 用法:
		/// ACOS(X)返回X的反余弦值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitCOS_fun(tdxParser.COS_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Cos(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Cos(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 正弦值.
		/// 用法:
		/// SIN(X)返回X的正弦值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSIN_fun(tdxParser.SIN_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Sin(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Sin(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 正切值.
		/// 用法:
		/// TAN(X)返回X的正切值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitTAN_fun(tdxParser.TAN_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Tan(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Tan(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 指数.
		/// 用法:
		/// EXP(X)为e的X次幂
		/// 例如:
		/// EXP(CLOSE)返回e的CLOSE次幂
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitEXP_fun(tdxParser.EXP_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Exp(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Exp(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求自然对数.
		/// 用法:
		/// LN(X)以e为底的对数
		/// 例如:
		/// LN(CLOSE)求收盘价的对数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLN_fun(tdxParser.LN_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Log(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Log(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求10为底的对数.
		/// 用法:
		/// LOG(X)取得X的对数
		/// 例如:
		/// LOG(100)等于2
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitLOG_fun(tdxParser.LOG_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Log(firstValue.NumberValue, 10));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Log(A[i], 10));
			}
			return Operand.Create(array);
		}
		public Operand VisitLOG_NUM_fun(tdxParser.LOG_NUM_funContext context)
		{
			var firstValue = Visit(context.expr());
			double N = double.Parse(context.NUM().GetText());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Log(firstValue.NumberValue, N));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Log(A[i], N));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 开平方.
		/// 用法:
		/// SQRT(X)为X的平方根
		/// 例如:
		/// SQRT(CLOSE)收盘价的平方根
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSQRT_fun(tdxParser.SQRT_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Sqrt(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Sqrt(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 求绝对值.
		/// 用法:
		/// ABS(X)返回X的绝对值
		/// 例如:
		/// ABS(-34)返回34
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitABS_fun(tdxParser.ABS_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Abs(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Abs(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 乘幂.
		/// 用法:
		/// POW(A, B)返回A的B次幂
		/// 例如:
		/// POW(CLOSE,3)求得收盘价的3次方
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitPOW_fun(tdxParser.POW_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount);
			if (length == -1) {
				return (Math.Pow(firstValue.NumberValue, secondValue.NumberValue));
			}
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Pow(A[i], B[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 向上舍入.
		/// 用法:
		/// CEILING(A)返回沿A数值增大方向最接近的整数
		/// 例如:
		/// CEILING(12.3)求得13,CEILING(-3.5)求得-3
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitCEILING_fun(tdxParser.CEILING_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Ceiling(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Ceiling(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 向下舍入.
		/// 用法:
		/// FLOOR(A)返回沿A数值减小方向最接近的整数
		/// 例如:
		/// FLOOR(12.3)求得12,FLOOR(-3.5)求得-4
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFLOOR_fun(tdxParser.FLOOR_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Floor(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Floor(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 取整.
		/// 用法:
		/// INTPART(A)返回沿A绝对值减小方向最接近的整数
		/// 例如:
		/// INTPART(12.3)求得12,INTPART(-3.5)求得-3
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitINTPART_fun(tdxParser.INTPART_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return ((int)(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add((int)(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 介于.
		/// 用法:
		/// BETWEEN(A, B, C)表示A处于B和C之间时返回1,B<A<C或C<A<B, 否则返回0
		/// 例如:
		/// BETWEEN(CLOSE, MA(CLOSE,10),MA(CLOSE,5))表示收盘价介于5日均线和10日均线之间
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitBETWEEN_fun(tdxParser.BETWEEN_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount, thirdValue.ArrayCount);
			if (length == -1) {
				var a = firstValue.NumberValue;
				var b = secondValue.NumberValue;
				var c = thirdValue.NumberValue;
				if (b > c) {
					(b, c) = (c, b);
				}
				return (b < a && a < c ? 1 : 0);
			}
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			var C = thirdValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				var a = A[i];
				var b = B[i];
				var c = C[i];
				if (b > c) {
					(b, c) = (c, b);
				}
				array.Add(b < a && a < c ? 1 : 0);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 小数部分.
		/// 用法:
		/// FRACPART(X),返回X的小数部分
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFRACPART_fun(tdxParser.FRACPART_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (firstValue.NumberValue - (int)(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(A[i] - (int)(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 四舍五入.
		/// 用法:
		/// ROUND(X),返回X四舍五入到个位的数值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitROUND_fun(tdxParser.ROUND_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Round(firstValue.NumberValue, 0, MidpointRounding.AwayFromZero));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Round(A[i], 0, MidpointRounding.AwayFromZero));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 四舍五入.
		/// 用法:
		/// ROUND2(X, N),返回X四舍五入到N位小数的数值
		/// 由于精度问题, 数据越大误差可能越大
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitROUND2_fun(tdxParser.ROUND2_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount);
			if (length == -1) {
				return (Math.Round(firstValue.NumberValue, secondValue.IntValue, MidpointRounding.AwayFromZero));
			}
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Round(A[i], (int)B[i], MidpointRounding.AwayFromZero));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 取符号.
		/// 用法:
		/// SIGN(X),返回X的符号.当X>0,X=0,X<0分别返回1,0,-1
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSIGN_fun(tdxParser.SIGN_funContext context)
		{
			var firstValue = Visit(context.expr());
			if (firstValue.Type == OperandType.NUMBER) {
				return (Math.Sign(firstValue.NumberValue));
			}
			var length = firstValue.ArrayCount;
			var A = firstValue.NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Sign(A[i]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 取模.
		/// 用法:
		/// MOD(M, N),返回M关于N的模(M除以N的余数)
		/// 例如:
		/// MOD(5,3)返回2 注意:公式系统对有效数字部分有要求,如果数字部分超过7-8位,会有精度丢失
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitMOD_fun(tdxParser.MOD_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var length = MyMath.Max(firstValue.ArrayCount, secondValue.ArrayCount);
			if (length == -1) {
				return (firstValue.NumberValue % secondValue.NumberValue);
			}
			var A = firstValue.ToNumber(length).NumberArrayValue;
			var B = secondValue.ToNumber(length).NumberArrayValue;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				array.Add(Math.Round(A[i] % B[i]));
			}
			return Operand.Create(array);
		}
		public Operand VisitMIN_EXT_fun(tdxParser.MIN_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) {
				args[i] = args[i].ToNumber(length);
			}
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				var a = args[0].NumberArrayValue[i];
				for (int j = 0; j < args.Count; j++) {
					var b = args[j].NumberArrayValue[i];
					if (b < a) { a = b; }
				}
				array.Add(a);
			}
			return Operand.Create(array);
		}
		public Operand VisitMAX_EXT_fun(tdxParser.MAX_EXT_funContext context)
		{
			var args = new List<Operand>();
			List<int> lengths = new List<int>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); lengths.Add(aa.ArrayCount); }
			var length = lengths.Max();
			for (int i = 0; i < args.Count; i++) {
				args[i] = args[i].ToNumber(length);
			}
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < length; i++) {
				var a = args[0].NumberArrayValue[i];
				for (int j = 0; j < args.Count; j++) {
					var b = args[j].NumberArrayValue[i];
					if (b > a) { a = b; }
				}
				array.Add(a);
			}
			return Operand.Create(array);
		}
		#endregion
		#region 统计函数
		/// <summary>
		/// AVEDEV(X,N) 返回平均绝对偏差
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitAVEDEV_fun(tdxParser.AVEDEV_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.AVEDEV(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// DEVSQ(X,N) 返回数据偏差平方和
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitDEVSQ_fun(tdxParser.DEVSQ_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.DEVSQ(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// FORCAST(X,N) 返回线性回归预测值,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitFORCAST_fun(tdxParser.FORCAST_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.FORCAST(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// SLOPE(X,N) 返回线性回归斜率,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSLOPE_fun(tdxParser.SLOPE_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.SLOPE(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// STD(X,N) 返回估算标准差,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSTD_fun(tdxParser.STD_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.STD(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// STDP(X,N) 返回总体标准差,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSTDP_fun(tdxParser.STDP_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.STDP(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// STDDEV(X,N) 返回标准偏差
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitSTDDEV_fun(tdxParser.STDDEV_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.STDDEV(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// VAR(X,N) 返回估算样本方差,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitVAR_fun(tdxParser.VAR_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.VAR(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// VARP(X,N) 返回总体样本方差,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitVARP_fun(tdxParser.VARP_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var X = firstValue.NumberArrayValue;
			var array = IntFunc(secondValue, (N) => {
				return MyMath.VARP(X, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// COVAR(X,Y,N) 返回X和Y的N周期的协方差,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitCOVAR_fun(tdxParser.COVAR_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var X = firstValue.ToNumber(ArrayCount).NumberArrayValue;
			var Y = secondValue.ToNumber(ArrayCount).NumberArrayValue;
			var array = IntFunc(thirdValue, (N) => {
				return MyMath.COVAR(X, Y, N);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// RELATE(X,Y,N) 返回X和Y的N周期的相关系数,N支持变量
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitRELATE_fun(tdxParser.RELATE_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var X = firstValue.ToNumber(ArrayCount).NumberArrayValue;
			var Y = secondValue.ToNumber(ArrayCount).NumberArrayValue;
			var array = IntFunc(thirdValue, (N) => {
				return MyMath.RELATE(X, Y, N);
			});
			return Operand.Create(array);
		}
		#endregion
		#region 形态函数
		private List<Dictionary<int, double>> CreateChipDistribution()
		{
			return GetChipDistribution();
		}
		/// <summary>
		/// 成本分布情况.
		/// 用法:
		/// COST(10),表示10%获利盘的价格是多少,即有10%的持仓量在该价格以下,其余90%在该价格以上,为套牢盘
		/// 该函数仅对日线分析周期有效
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitCOST_fun(tdxParser.COST_funContext context)
		{
			var firstValue = Visit(context.expr());
			var array = GetChipN(firstValue.IntValue);
			return Operand.Create(array);
		}
		/// <summary>
		/// 获利盘比例.
		/// 用法:
		/// WINNER(CLOSE),表示以当前收市价卖出的获利盘比例,例如返回0.1表示10%获利盘;WINNER(10.5)表示10.5元价格的获利盘比例
		/// 该函数仅对日线分析周期有效
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitWINNER_fun(tdxParser.WINNER_funContext context)
		{
			var firstValue = Visit(context.expr());
			var chips = GetChipSumArray();
			var array = new MyList(0, ArrayCount);
			var NewForeAdjustFactor = GetParameter.Invoke("NewForeAdjustFactor").NumberArrayValue;

			Parallel.For(0, ArrayCount, (i) => {
				var oldCost = chips[i];
				int top = (int)((firstValue.Type == OperandType.NUMBER ? firstValue.NumberValue : firstValue.NumberArrayValue[i]) / NewForeAdjustFactor[i] * 100);
				array[i] = oldCost.Winner(top);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 近期获利盘比例.
		/// 用法: LWINNER(5, CLOSE),表示最近5天的那部分成本以当前收市价卖出的获利盘比例
		/// 例如:
		/// 返回0.1表示10%获利盘
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitLWINNER_fun(tdxParser.LWINNER_funContext context)
		{
			var exprs = context.expr();
			var firstValue = Visit(exprs[0]);
			var secondValue = Visit(exprs[1]);
			var T = GetParameter.Invoke("T").NumberArrayValue;
			var OldForeAdjustFactor = GetParameter.Invoke("OldForeAdjustFactor").NumberArrayValue;
			var NewForeAdjustFactor = GetParameter.Invoke("NewForeAdjustFactor").NumberArrayValue;
			var chipDistribution = CreateChipDistribution();
			var array = new List<double>();
			for (int i = 0; i < ArrayCount; i++) {
				var N = firstValue.Type == OperandType.NUMBER ? firstValue.NumberValue : firstValue.NumberArrayValue[i];
				Dictionary<int, double> oldCost = new Dictionary<int, double>();
				for (int j = (int)N - 1; j >= 0; j--) {
					if (i - j < 0) { continue; }
					var newCost = chipDistribution[i];
					oldCost = MyMath.CalcChip(oldCost, newCost, OldForeAdjustFactor[i], NewForeAdjustFactor[i], T[i]);
				}
				var sum = oldCost.Sum(q => q.Value);
				var top = (int)((secondValue.Type == OperandType.NUMBER ? secondValue.NumberValue : secondValue.NumberArrayValue[i]) / NewForeAdjustFactor[i] * 100);
				double x = 0;
				foreach (var item in oldCost.OrderBy(q => q.Key)) {
					if (item.Key <= top) {
						x += item.Value;
					} else {
						break;
					}
				}
				var t = x / sum;
				array.Add(t);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 远期获利盘比例.
		/// 用法: PWINNER(5, CLOSE),表示5天前的那部分成本以当前收市价卖出的获利盘比例
		/// 例如:
		/// 返回0.1表示10%获利盘
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitPWINNER_fun(tdxParser.PWINNER_funContext context)
		{
			var exprs = context.expr();

			var firstValue = Visit(exprs[0]);
			var secondValue = Visit(exprs[1]);
			var chips = GetChipSumArray();
			var N = firstValue.Type == OperandType.NUMBER ? firstValue.NumberValue : firstValue.NumberArrayValue[0];
			var NewForeAdjustFactor = GetParameter.Invoke("NewForeAdjustFactor").NumberArrayValue;

			var array = new MyList(0, ArrayCount);
			Parallel.For(0, ArrayCount, (i) => {
				int k = i - (int)N;
				if (k < 0) { return; }
				var oldCost = chips[k];
				var top = (int)((secondValue.Type == OperandType.NUMBER ? secondValue.NumberValue : secondValue.NumberArrayValue[i]) / NewForeAdjustFactor[i] * 100);

				array[i] = oldCost.Winner(top);
			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 区间成本.
		/// 用法:
		/// 例如COSTEX(CLOSE, REF(CLOSE,1)),表示近两日收盘价格间筹码的成本
		/// 该函数仅对日线分析周期有效
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitCOSTEX_fun(tdxParser.COSTEX_funContext context)
		{
			var exprs = context.expr();

			var firstValue = Visit(exprs[0]);
			var secondValue = Visit(exprs[1]);
			var chips = GetChip();
			var NewForeAdjustFactor = GetParameter.Invoke("NewForeAdjustFactor").NumberArrayValue;

			var array = new MyList(0, ArrayCount);
			Parallel.For(0, ArrayCount, (i) => {
				var oldCost = chips[i];
				var min = (firstValue.Type == OperandType.NUMBER ? firstValue.NumberValue : firstValue.NumberArrayValue[i]) / NewForeAdjustFactor[i] * 100;
				var max = (secondValue.Type == OperandType.NUMBER ? secondValue.NumberValue : secondValue.NumberArrayValue[i]) / NewForeAdjustFactor[i] * 100;
				if (min > max) {
					(max, min) = (min, max);
				}

				double x = 0;
				double vol = 0;
				foreach (var item in oldCost.OrderBy(q => q.Key)) {
					if (min <= item.Key && item.Key <= max) {
						x += item.Key * item.Value;
						vol += item.Value;
					}
				}
				array[i] = x / vol;

			});
			return Operand.Create(array);
		}
		/// <summary>
		/// 远期成本分布比例.
		/// 用法:
		/// PPART(10),表示10个周期前的成本占总成本的比例,0.2表示20%
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitPPART_fun(tdxParser.PPART_funContext context)
		{
			var firstValue = Visit(context.expr());
			var N = firstValue.Type == OperandType.NUMBER ? firstValue.NumberValue : firstValue.NumberArrayValue[0];
			var Vol = GetParameter.Invoke("Vol").NumberArrayValue;
			var T = GetParameter.Invoke("T").NumberArrayValue;
			double array1 = 0;//当前的
			double array2 = 0;
			var array = new List<double>();
			for (int i = 0; i < ArrayCount; i++) {
				// 当日成本*（换手率*历史换手衰减系数）+上一日成本分布图*（1-换手率*历史换手衰减系数）
				array1 = array1 * (1 - T[i]) + Vol[i] * T[i];
				var k = i - (int)N;
				if (k < 0) {
					array.Add(0);
					continue;
				}
				array2 = array2 * (1 - T[k]) + Vol[k] * T[k];
				double temp = array2;
				for (int j = k + 1; j <= i; j++) {
					temp = temp * (1 - T[j]);
				}
				array.Add(temp / array1);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 抛物转向.
		/// 用法:
		/// SAR(N, S, M),N为计算周期,S为步长,M为极值
		/// 例如:
		/// SAR(10,2,20)表示计算10日抛物转向,步长为2%,极限值为20%
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitSAR_fun(tdxParser.SAR_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var length = firstValue.ArrayCount;
			var N = firstValue.IntValue;
			var S = secondValue.NumberValue / 100;
			var M = thirdValue.NumberValue / 100;
			var High = GetParameter.Invoke("high").NumberArrayValue;
			var Low = GetParameter.Invoke("low").NumberArrayValue;
			List<SarModel> models = MyMath.GetParabolicSar(High, Low, S, M);
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < ArrayCount; i++) {
				if (models[i].Sar == null) {
					array.Add(0);
				} else {
					array.Add(models[i].Sar.Value);
				}
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 抛物转向点.
		/// 用法:
		/// SARTURN(N, S, M),N为计算周期,S为步长,M为极值,若发生向上转向则返回1,若发生向下转向则返回-1,否则为0
		/// 其用法与SAR函数相同
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitSARTURN_fun(tdxParser.SARTURN_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var N = firstValue.IntValue;
			var S = secondValue.NumberValue / 100;
			var M = thirdValue.NumberValue / 100;
			var High = GetParameter.Invoke("high").NumberArrayValue;
			var Low = GetParameter.Invoke("low").NumberArrayValue;
			List<SarModel> models = MyMath.GetParabolicSar(High, Low, S, M);
			List<double> array = new List<double> { 0 };
			for (int i = 1; i < ArrayCount; i++) {
				if (models[i].Sar == null) {
					array.Add(0);
				} else if (models[i - 1].Sar == null) {
					array.Add(0);
				} else if (models[i].IsReversal.Value) {
					if (models[i].Sar > models[i - 1].Sar) {
						array.Add(-1);
					} else {
						array.Add(1);
					}
				} else {
					array.Add(0);
				}
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,之字转向.
		/// 用法:
		/// ZIG(K, N),当价格变化量超过N%时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
		/// 例如:
		/// ZIG(3,5)表示收盘价的5%的ZIG转向
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitZIG_fun(tdxParser.ZIG_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var operand = GetZigOperand(firstValue);
			List<double> temp = operand.NumberArrayValue;
			var N = secondValue.NumberValue;
			var array = MyMath.Zig(temp, N / 100);
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,之字转向.
		/// 用法:
		/// ZIGA(K, X),当价格变化超过X时转向,K表示0:开盘价,1:最高价,2:最低价,3:收盘价,其余:数组信息
		/// 例如:
		/// ZIGA(3,1.5)表示收盘价变化1.5元的ZIGA转向
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitZIGA_fun(tdxParser.ZIGA_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var operand = GetZigOperand(firstValue);
			List<double> temp = operand.NumberArrayValue;
			var N = secondValue.NumberValue;
			var array = MyMath.Ziga(temp, N);
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,前M个ZIG转向波峰值.
		/// 用法:
		/// PEAK(K, N, M)表示之字转向ZIG(K, N)的前M个波峰的数值,M必须大于等于1
		/// 例如:
		/// PEAK(1,5,1)表示%5最高价ZIG转向的上一个波峰的数值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Operand VisitPEAK_fun(tdxParser.PEAK_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var operand = GetZigOperand(firstValue);
			List<double> temp = operand.NumberArrayValue;
			var N = secondValue.NumberValue;
			var peeks = MyMath.ZigPeek(temp, N / 100);
			var peeks2 = new List<int>();
			if (temp[peeks[0]] > temp[peeks[1]]) {
				for (int i = 0; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			} else {
				for (int i = 1; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			}
			peeks2.Add(temp.Count - 1);
			int[] peeks3 = new int[temp.Count];
			for (int i = 0; i < peeks2.Count - 1; i++) {
				var p1 = peeks2[i];
				var p2 = peeks2[i + 1];
				for (int j = p1; j <= p2; j++) {
					peeks3[j] = p1;
				}
			}
			var M = thirdValue.IntValue - 1;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < temp.Count; i++) {
				array.Add(temp[peeks3[Math.Max(0, i - M)]]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,前M个ZIG转向波峰到当前距离.
		/// 用法:
		/// PEAKBARS(K, N, M)表示之字转向ZIG(K, N)的前M个波峰到当前的周期数,M必须大于等于1
		/// 例如:
		/// PEAKBARS(0,5,1)表示%5开盘价ZIG转向的上一个波峰到当前的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitPEAKBARS_fun(tdxParser.PEAKBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var operand = GetZigOperand(firstValue);
			List<double> temp = operand.NumberArrayValue;
			var N = secondValue.NumberValue;
			var peeks = MyMath.ZigPeek(temp, N / 100);
			var peeks2 = new List<int>();
			if (temp[peeks[0]] > temp[peeks[1]]) {
				for (int i = 0; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			} else {
				for (int i = 1; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			}
			peeks2.Add(temp.Count - 1);
			int[] peeks3 = new int[temp.Count];
			for (int i = 0; i < peeks2.Count - 1; i++) {
				var p1 = peeks2[i];
				var p2 = peeks2[i + 1];
				for (int j = p1; j <= p2; j++) {
					peeks3[j] = i;
				}
			}
			var M = thirdValue.IntValue - 1;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < temp.Count; i++) {
				array.Add(i - Math.Max(0, peeks2[Math.Max(0, peeks3[i] - M)]));
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,前M个ZIG转向波谷值.
		/// 用法:
		/// TROUGH(K, N, M)表示之字转向ZIG(K, N)的前M个波谷的数值,M必须大于等于1
		/// 例如:
		/// TROUGH(2,5,2)表示%5最低价ZIG转向的前2个波谷的数值
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitTROUGH_fun(tdxParser.TROUGH_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var operand = GetZigOperand(firstValue);
			List<double> temp = operand.NumberArrayValue;
			var N = secondValue.NumberValue;
			var peeks = MyMath.ZigPeek(temp, N / 100);
			var peeks2 = new List<int>();
			if (temp[peeks[0]] < temp[peeks[1]]) {
				for (int i = 0; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			} else {
				for (int i = 1; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			}
			peeks2.Add(temp.Count - 1);
			int[] peeks3 = new int[temp.Count];
			for (int i = 0; i < peeks2.Count - 1; i++) {
				var p1 = peeks2[i];
				var p2 = peeks2[i + 1];
				for (int j = p1; j <= p2; j++) {
					peeks3[j] = p1;
				}
			}
			var M = thirdValue.IntValue - 1;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < temp.Count; i++) {
				array.Add(temp[peeks3[Math.Max(0, i - M)]]);
			}
			return Operand.Create(array);
		}
		/// <summary>
		/// 属于未来函数,前M个ZIG转向波谷到当前距离.
		/// 用法:
		/// TROUGHBARS(K, N, M)表示之字转向ZIG(K, N)的前M个波谷到当前的周期数,M必须大于等于1
		/// 例如:
		/// TROUGHBARS(2,5,2)表示%5最低价ZIG转向的前2个波谷到当前的周期数
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>

		public Operand VisitTROUGHBARS_fun(tdxParser.TROUGHBARS_funContext context)
		{
			var args = new List<Operand>();
			foreach (var item in context.expr()) { var aa = this.Visit(item); args.Add(aa); }
			var firstValue = args[0];
			var secondValue = args[1];
			var thirdValue = args[2];
			var operand = GetZigOperand(firstValue);
			List<double> temp = operand.NumberArrayValue;
			var N = secondValue.NumberValue;
			var peeks = MyMath.ZigPeek(temp, N / 100);
			var peeks2 = new List<int>();
			if (temp[peeks[0]] < temp[peeks[1]]) {
				for (int i = 0; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			} else {
				for (int i = 1; i < peeks.Count; i += 2) {
					peeks2.Add(peeks[i]);
				}
			}
			peeks2.Add(temp.Count - 1);
			int[] peeks3 = new int[temp.Count];
			for (int i = 0; i < peeks2.Count - 1; i++) {
				var p1 = peeks2[i];
				var p2 = peeks2[i + 1];
				for (int j = p1; j <= p2; j++) {
					peeks3[j] = i;
				}
			}
			var M = thirdValue.IntValue - 1;
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < temp.Count; i++) {
				array.Add(i - Math.Max(0, peeks2[Math.Max(0, peeks3[i] - M)]));
			}
			return Operand.Create(array);
		}
		#endregion
		#region 时间
		public Operand VisitDATETODAY_fun(tdxParser.DATETODAY_funContext context)
		{
			var firstValue = this.Visit(context.expr());
			MyList array = new MyList(ArrayCount);
			var dt = new DateTime(1990, 12, 19);
			var X = firstValue.NumberArrayValue;
			for (int i = 0; i < firstValue.ArrayCount; i++) {
				var x = X[i] + 19000000;
				var day = (int)x % 100;
				var month = (int)(x / 100) % 100;
				var year = (int)(x / 10000);
				var date = new DateTime(year, month, day);
				var days = (date - dt).TotalDays;
				array.Add(days);
			}
			return Operand.Create(array);
		}
		#endregion
		#region 技术指标函数
		public Operand VisitMTM_fun(tdxParser.MTM_funContext context)
		{
			//def MTM(CLOSE,N=12,M=6):                             #动量指标
			//    MTM=CLOSE-REF(CLOSE,N);         MTMMA=MA(MTM,M)
			//    return MTM,MTMMA
			var exprs = context.expr();
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var N = Visit(exprs[0]).IntValue;
			var M = Visit(exprs[1]).IntValue;
			return CLOSE - MyMath.REF(CLOSE, N);
			//var MTMMA = MyMath.MA(MTM, M);
			//SetParameter(tempName + ".MTM", MTM);
			//SetParameter(tempName + ".MTMMA", MTMMA);
			//return null;
		}
		public Operand VisitRSI_fun(tdxParser.RSI_funContext context)
		{
			//def RSI(CLOSE, N=24):                           # RSI指标,和通达信小数点2位相同
			//    DIF = CLOSE-REF(CLOSE,1) 
			//    return RD(SMA(MAX(DIF,0), N) / SMA(ABS(DIF), N) * 100)  
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			var DIF = CLOSE - MyMath.REF(CLOSE, 1);
			return MyMath.SMA(MyMath.MAX(DIF, 0), N) / MyMath.SMA(MyMath.ABS(DIF), N) * 100;
		}
		public Operand VisitWR_fun(tdxParser.WR_funContext context)
		{
			// WR = (HHV(HIGH, N) - CLOSE) / (HHV(HIGH, N) - LLV(LOW, N)) * 100
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			var HHV_HIGH = MyMath.HHV(HIGH, N);
			return (HHV_HIGH - CLOSE) / (HHV_HIGH - MyMath.LLV(LOW, N)) * 100;
		}
		public Operand VisitBIAS_fun(tdxParser.BIAS_funContext context)
		{
			// BIAS1 = (CLOSE - MA(CLOSE, L1)) / MA(CLOSE, L1) * 100
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var L1 = Visit(context.expr()).IntValue;
			var MA_CLOSE = MyMath.MA(CLOSE, L1);
			return (CLOSE - MA_CLOSE) / MA_CLOSE * 100;
		}
		public Operand VisitPSY_fun(tdxParser.PSY_funContext context)
		{
			// PSY=COUNT(CLOSE>REF(CLOSE,1),N)/N*100
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			return MyMath.COUNT(CLOSE > MyMath.REF(CLOSE, 1), N) / N * 100;
		}
		public Operand VisitCCI_fun(tdxParser.CCI_funContext context)
		{
			//        TP = (HIGH + LOW + CLOSE) / 3
			//return (TP - MA(TP, N)) / (0.015 * AVEDEV(TP, N))
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			var TP = (HIGH + LOW + CLOSE) / 3;
			return (TP - MyMath.MA(TP, N)) / (0.015 * MyMath.AVEDEV(TP, N));
		}
		public Operand VisitATR_fun(tdxParser.ATR_funContext context)
		{
			//        TR = MAX(MAX((HIGH - LOW), ABS(REF(CLOSE, 1) - HIGH)), ABS(REF(CLOSE, 1) - LOW))
			//return MA(TR, N)
			var TR = GetParameter("TR").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			return MyMath.MA(TR, N);
		}
		public Operand VisitBBI_fun(tdxParser.BBI_funContext context)
		{
			// (MA(CLOSE,M1)+MA(CLOSE,M2)+MA(CLOSE,M3)+MA(CLOSE,M4))/4    
			var exprs = context.expr();
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var M1 = Visit(exprs[0]).IntValue;
			var M2 = Visit(exprs[1]).IntValue;
			var M3 = Visit(exprs[2]).IntValue;
			var M4 = Visit(exprs[3]).IntValue;
			return (MyMath.MA(CLOSE, M1) + MyMath.MA(CLOSE, M2) + MyMath.MA(CLOSE, M3) + MyMath.MA(CLOSE, M4)) / 4;
		}
		public Operand VisitTRIX_fun(tdxParser.TRIX_funContext context)
		{
			// TR = EMA(EMA(EMA(CLOSE, M1), M1), M1)
			// TRIX = (TR - REF(TR, 1)) / REF(TR, 1) * 100
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var M1 = Visit(context.expr()).IntValue;
			var TR = MyMath.EMA(MyMath.EMA(MyMath.EMA(CLOSE, M1), M1), M1);
			return (TR - MyMath.REF(TR, 1)) / MyMath.REF(TR, 1) * 100;
		}
		public Operand VisitVR_fun(tdxParser.VR_funContext context)
		{
			//        LC = REF(CLOSE, 1)
			//return SUM(IF(CLOSE > LC, VOL, 0), M1) / SUM(IF(CLOSE <= LC, VOL, 0), M1) * 100
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var VOL = GetParameter("VOL").NumberArrayValue;
			var M1 = Visit(context.expr()).IntValue;
			var LC = MyMath.REF(CLOSE, 1);
			return MyMath.SUM(MyMath.IF(CLOSE > LC, VOL, 0), M1) / MyMath.SUM(MyMath.IF(CLOSE <= LC, VOL, 0), M1) * 100;
		}
		public Operand VisitEMV_fun(tdxParser.EMV_funContext context)
		{
			//        VOLUME = MA(VOL, N) / VOL; MID = 100 * (HIGH + LOW - REF(HIGH + LOW, 1)) / (HIGH + LOW)
			//EMV = MA(MID * VOLUME * (HIGH - LOW) / MA(HIGH - LOW, N), N);
			var VOL = GetParameter("VOL").NumberArrayValue;
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			var VOLUME = MyMath.MA(VOL, N) / VOL;
			var HL = HIGH + LOW;
			var HL2 = HIGH - LOW;
			var MID = 100 * (HL - MyMath.REF(HL, 1)) / HL;
			return MyMath.MA(MID * VOLUME * HL2 / MyMath.MA(HL2, N), N);
		}
		public Operand VisitDPO_fun(tdxParser.DPO_funContext context)
		{
			// DPO = CLOSE - REF(MA(CLOSE, M1), M2);  
			var exprs = context.expr();
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var M1 = Visit(exprs[0]).IntValue;
			var M2 = Visit(exprs[1]).IntValue;
			return CLOSE - MyMath.REF(MyMath.MA(CLOSE, M1), M2);
		}
		public Operand VisitMASS_fun(tdxParser.MASS_funContext context)
		{
			//def MASS(HIGH,LOW,N1=9,N2=25,M=6):                   #梅斯线
			//    MASS=SUM(MA(HIGH-LOW,N1)/MA(MA(HIGH-LOW,N1),N1),N2)
			//    MA_MASS=MA(MASS,M)
			//    return MASS,MA_MASS
			var exprs = context.expr();
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var N1 = Visit(exprs[0]).IntValue;
			var N2 = Visit(exprs[1]).IntValue;
			var HL = HIGH - LOW;
			var HLMA = MyMath.MA(HL, N1);
			return MyMath.SUM(HLMA / MyMath.MA(HLMA, N1), N2);
		}
		public Operand VisitROC_fun(tdxParser.ROC_funContext context)
		{
			//def ROC(CLOSE,N=12,M=6):                             #变动率指标
			//    ROC=100*(CLOSE-REF(CLOSE,N))/REF(CLOSE,N);    MAROC=MA(ROC,M)
			//    return ROC,MAROC  
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			var CREF = MyMath.REF(CLOSE, N);
			return Operand.Create(100 * (CLOSE - CREF) / CREF);
		}
		public Operand VisitOBV_fun(tdxParser.OBV_funContext context)
		{
			//return SUM(IF(CLOSE>REF(CLOSE,1),VOL,IF(CLOSE<REF(CLOSE,1),-VOL,0)),0)/10000
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var VOL = GetParameter("VOL").NumberArrayValue;
			return MyMath.SUM(MyMath.IF(CLOSE > MyMath.REF(CLOSE, 1), VOL, MyMath.IF(CLOSE < MyMath.REF(CLOSE, 1), -1 * VOL, 0)), 0) / 10000;
		}
		public Operand VisitMFI_fun(tdxParser.MFI_funContext context)
		{
			//        TYP = (HIGH + LOW + CLOSE) / 3
			//V1 = SUM(IF(TYP > REF(TYP, 1), TYP * VOL, 0), N) / SUM(IF(TYP < REF(TYP, 1), TYP * VOL, 0), N)
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var VOL = GetParameter("VOL").NumberArrayValue;
			var N = Visit(context.expr()).IntValue;
			var TYP = (HIGH + LOW + CLOSE) / 3;
			var TYPREF = MyMath.REF(TYP, 1);
			var TYPVOL = TYP * VOL;
			var V1 = MyMath.SUM(MyMath.IF(TYP > TYPREF, TYPVOL, 0), N) / MyMath.SUM(MyMath.IF(TYP < TYPREF, TYPVOL, 0), N);
			return 100 - (100 / (1 + V1));
		}
		public Operand VisitASI_fun(tdxParser.ASI_funContext context)
		{
			//LC = REF(CLOSE, 1); AA = ABS(HIGH - LC); BB = ABS(LOW - LC);
			//CC = ABS(HIGH - REF(LOW, 1)); DD = ABS(LC - REF(OPEN, 1));
			//R = IF((AA > BB) & (AA > CC), AA + BB / 2 + DD / 4, IF((BB > CC) & (BB > AA), BB + AA / 2 + DD / 4, CC + DD / 4));
			//X = (CLOSE - LC + (CLOSE - OPEN) / 2 + LC - REF(OPEN, 1));
			//SI = 16 * X / R * MAX(AA, BB); ASI = SUM(SI, M1);
			var CLOSE = GetParameter("CLOSE").NumberArrayValue;
			var HIGH = GetParameter("HIGH").NumberArrayValue;
			var LOW = GetParameter("LOW").NumberArrayValue;
			var OPEN = GetParameter("OPEN").NumberArrayValue;
			var M1 = Visit(context.expr()).IntValue;
			var LC = MyMath.REF(CLOSE, 1);
			var AA = MyMath.ABS(HIGH - LC);
			var BB = MyMath.ABS(LOW - LC);
			var CC = MyMath.ABS(HIGH - MyMath.REF(LOW, 1));
			var DD = MyMath.ABS(LC - MyMath.REF(OPEN, 1));
			var R = MyMath.IF((AA > BB) + (AA > CC) == 2, AA + BB / 2 + DD / 4, MyMath.IF((BB > CC) + (BB > AA) == 2, BB + AA / 2 + DD / 4, CC + DD / 4));
			var X = (CLOSE - LC + (CLOSE - OPEN) / 2 + LC - MyMath.REF(OPEN, 1));
			var SI = 16 * X / R * MyMath.MAX(AA, BB);
			return MyMath.SUM(SI, M1);
		}
		#endregion
		public Operand GetZigOperand(Operand firstValue)
		{
			if (firstValue.Type == OperandType.NUMBER) {
				var K = firstValue.IntValue;
				string p = "open";
				if (K == 0) {
					p = "open";
				} else if (K == 1) {
					p = "high";
				} else if (K == 2) {
					p = "low";
				} else if (K == 3) {
					p = "close";
				}
				var operand = GetParameter.Invoke(p);
				return operand;
			}
			return firstValue;
		}
		private MyList IntFunc(Operand operand, Func<int, MyList> func)
		{
			if (operand.Type == OperandType.NUMBER) {
				var N = MyMath.Max(operand.IntValue, 0);
				return func(N);
			}
			var NS = operand.NumberArrayValue;
			var NS2 = NS.Select(q => q).Distinct().ToList();
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < NS.Count; i++) { array.Add(0); }
			foreach (var N in NS2) {
				var array2 = func((int)N);
				for (int i = 0; i < NS.Count; i++) {
					if (NS[i] == N) {
						array[i] = array2[i];
					}
				}
			}
			return array;
		}
		private MyList DoubleFunc(Operand operand, Func<double, MyList> func)
		{
			if (operand.Type == OperandType.NUMBER) {
				var N = MyMath.Max(operand.NumberValue, 0);
				return func(N);
			}
			var NS = operand.NumberArrayValue;
			var NS2 = NS.Select(q => q).Distinct().ToList();
			MyList array = new MyList(ArrayCount);
			for (int i = 0; i < NS.Count; i++) { array.Add(0); }
			foreach (var N in NS2) {
				var array2 = func(N);
				for (int i = 0; i < NS.Count; i++) {
					if (NS[i] == N) {
						array[i] = array2[i];
					}
				}
			}
			return array;
		}


	}
}
