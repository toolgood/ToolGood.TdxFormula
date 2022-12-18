grammar tdx;

prog: line+ EOF;

line:
	PARAMETER set = (':' | ':=') expr (COLOR (',' attach)*)? ';'	# line_fun
	| PARAMETER set = (':' | ':=') expr (',' attach)+ ';'			# line_fun
	| expr (COLOR (',' attach)*)? ';'								# none_fun
	| expr (',' attach)+ ';'										# none_fun
	| draw (COLOR (',' attach)*)? ';'								# none_fun
	| draw (',' attach)+ ';'										# none_fun
	| PARAMETER set = (':' | ':=') draw (COLOR (',' attach)*)? ';'	# none_fun
	| PARAMETER set = (':' | ':=') draw (',' attach)+ ';'			# none_fun;

attach:
	color
	| LINETHICK
	| STICK
	| COLORSTICK
	| VOLSTICK
	| LINESTICK
	| CROSSDOT
	| CIRCLEDOT
	| POINTDOT
	| NODRAW
	| DRAWABOVE
	| NOFRAME
	| DOTLINE
	| NOTTEXT
	| PLAYSOUND;

color: COLOR | RGB '(' expr ',' expr ',' expr ')';

draw: // 绘图函数
	DRAWTEXT '(' expr ',' expr ',' STRING ')'
	| DRAWBMP '(' expr ',' expr ',' STRING ')'
	| DRAWTEXT_FIX '(' expr ',' expr ',' expr ',' expr ',' STRING ')'
	| DRAWGBK '(' expr ',' expr ',' expr ',' expr ',' STRING ',' expr ')'
	| DRAWICON '(' expr ',' expr ',' NUM ')'
	| DRAWNUMBER '(' expr ',' expr ',' NUM ')'
	| DRAWNUMBER_FIX '(' expr ',' expr ',' NUM ')'
	| DRAWLINE '(' expr ',' expr ',' expr ',' expr ',' expr ')'
	| DRAWKLINE '(' expr ',' expr ',' expr ',' expr ')'
	| DRAWSL '(' expr ',' expr ',' expr ',' expr ',' expr ')'
	| DRAWBAND '(' expr ',' expr ',' color ')'
	| DRAWRECTREL '(' expr ',' expr ',' expr ',' expr ',' color ')'
	| STICKLINE '(' expr ',' expr ',' expr ',' expr ',' expr ')'
	| PLOYLINE '(' expr ',' expr ')';

expr:
	// 运算符优先级 开始
	'(' expr ')'												# Bracket_fun
	| expr op = ('*' | '/') expr								# MulDiv_fun
	| expr op = ('+' | '-') expr								# AddSub_fun
	| expr op = ('>' | '>=' | '<' | '<=') expr					# Judge_fun
	| expr op = ('=' | '==' | '===' | '!==' | '!=' | '<>') expr	# Judge_fun
	| expr op = ('&&' | AND) expr								# AndOr_fun
	| expr op = ('||' | OR) expr								# AndOr_fun
	// 运算符优先级 结束

	// 引用函数
	| DMA '(' expr ',' expr ')'								# DMA_fun
	| SMA '(' expr ',' expr ',' expr ')'					# SMA_fun
	| MA '(' expr ',' expr ')'								# MA_fun
	| EMA '(' expr ',' expr ')'								# EMA_fun
	| TMA '(' expr ',' expr ',' expr ')'					# TMA_fun
	| MEMA '(' expr ',' expr ')'							# MEMA_fun
	| WMA '(' expr ',' expr ')'								# WMA_fun
	| AMA '(' expr ',' expr ')'								# AMA_fun
	| HHV '(' expr ',' expr ')'								# HHV_fun
	| HHVBARS '(' expr ',' expr ')'							# HHVBARS_fun
	| LLV '(' expr ',' expr ')'								# LLV_fun
	| LLVBARS '(' expr ',' expr ')'							# LLVBARS_fun
	| HOD '(' expr ',' expr ')'								# HOD_fun
	| LOD '(' expr ',' expr ')'								# LOD_fun
	| COUNT '(' expr ',' expr ')'							# COUNT_fun
	| SUM '(' expr ',' expr ')'								# SUM_fun
	| REF '(' expr ',' expr ')'								# REF_fun
	| REFV '(' expr ',' expr ')'							# REFV_fun
	| REVERSE '(' expr ')'									# REVERSE_fun
	| BARSLAST '(' expr ')'									# BARSLAST_fun
	| BARSSINCE '(' expr ')'								# BARSSINCE_fun
	| BARSSINCEN '(' expr ',' expr ')'						# BARSSINCEN_fun
	| BARSLASTCOUNT '(' expr ')'							# BARSLASTCOUNT_fun
	| SUMBARS '(' expr ',' expr ')'							# SUMBARS_fun
	| FILTER '(' expr ',' expr ')'							# FILTER_fun
	| CONST '(' expr ')'									# CONST_fun
	| MULAR '(' expr ',' expr ')'							# MULAR_fun
	| FILTERX '(' expr ',' expr ')'							# FILTERX_fun
	| TOPRANGE '(' expr ')'									# TOPRANGE_fun
	| LOWRANGE '(' expr ')'									# LOWRANGE_fun
	| FINDHIGH '(' expr ',' expr ',' expr ',' expr ')'		# FINDHIGH_fun
	| FINDHIGHBARS '(' expr ',' expr ',' expr ',' expr ')'	# FINDHIGHBARS_fun
	| FINDLOW '(' expr ',' expr ',' expr ',' expr ')'		# FINDLOW_fun
	| FINDLOWBARS '(' expr ',' expr ',' expr ',' expr ')'	# FINDLOWBARS_fun
	| ZTPRICE '(' expr ',' expr ')'							# ZTPRICE_fun
	| DTPRICE '(' expr ',' expr ')'							# DTPRICE_fun
	| BACKSET '(' expr ',' expr ')'							# BACKSET_fun
	| BARSCOUNT '(' expr ')'								# BARSCOUNT_fun
	| HHV '(' expr (',' expr)+ ',' NUM ')'					# HHV_EXT_fun // 扩展
	| LLV '(' expr (',' expr)+ ',' NUM ')'					# LLV_EXT_fun // 扩展
	| HOD '(' expr (',' expr)+ ',' NUM ')'					# HOD_EXT_fun // 扩展
	| LOD '(' expr (',' expr)+ ',' NUM ')'					# LOD_EXT_fun // 扩展
	| SUM '(' expr (',' expr)+ ',' NUM ')'					# SUM_EXT_fun // 扩展

	// 逻辑函数 算术函数
	| IF '(' expr ',' expr ',' expr ')'			# IF_fun
	| IFN '(' expr ',' expr ',' expr ')'		# IFN_fun
	| VALUEWHEN '(' expr ',' expr ')'			# VALUEWHEN_fun
	| CROSS '(' expr ',' expr ')'				# CROSS_fun
	| LONGCROSS '(' expr ',' expr ',' expr ')'	# LONGCROSS_fun
	| UPNDAY '(' expr ',' expr ')'				# UPNDAY_fun
	| DOWNNDAY '(' expr ',' expr ')'			# DOWNNDAY_fun
	| NDAY '(' expr ',' expr ',' expr ')'		# NDAY_fun
	| EXIST '(' expr ',' expr ')'				# EXIST_fun
	| EXISTR '(' expr ',' expr ',' expr ')'		# EXISTR_fun
	| EVERY '(' expr ',' expr ')'				# EVERY_fun
	| LAST '(' expr ',' expr ',' expr ')'		# LAST_fun
	| ISVALID '(' expr ')'						# ISVALID_fun
	| NOT '(' expr ')'							# NOT_fun
	| RANGE '(' expr ',' expr ',' expr ')'		# RANGE_fun

	// 数学函数
	| MAX '(' expr ',' expr ')'											# MAX_fun
	| MAX6 '(' expr ',' expr ',' expr ',' expr ',' expr ',' expr ')'	# MAX6_fun
	| MIN '(' expr ',' expr ')'											# MIN_fun
	| MIN6 '(' expr ',' expr ',' expr ',' expr ',' expr ',' expr ')'	# MIN6_fun
	| ACOS '(' expr ')'													# ACOS_fun
	| ASIN '(' expr ')'													# ASIN_fun
	| ATAN '(' expr ')'													# ATAN_fun
	| COS '(' expr ')'													# COS_fun
	| SIN '(' expr ')'													# SIN_fun
	| TAN '(' expr ')'													# TAN_fun
	| EXP '(' expr ')'													# EXP_fun
	| LN '(' expr ')'													# LN_fun
	| LOG '(' expr ')'													# LOG_fun
	| SQRT '(' expr ')'													# SQRT_fun
	| ABS '(' expr ')'													# ABS_fun
	| POW '(' expr ',' expr ')'											# POW_fun
	| CEILING '(' expr ')'												# CEILING_fun
	| FLOOR '(' expr ')'												# FLOOR_fun
	| INTPART '(' expr ')'												# INTPART_fun
	| BETWEEN '(' expr ',' expr ',' expr ')'							# BETWEEN_fun
	| FRACPART '(' expr ')'												# FRACPART_fun
	| ROUND '(' expr ')'												# ROUND_fun
	| ROUND '(' expr ',' expr ')'										# ROUND2_fun
	| ROUND2 '(' expr ',' expr ')'										# ROUND2_fun
	| SIGN '(' expr ')'													# SIGN_fun
	| MOD '(' expr ',' expr ')'											# MOD_fun
	| LOG '(' expr ',' NUM ')'											# LOG_NUM_fun // 扩展
	| MAX '(' expr ',' expr (',' expr)+ ')'								# MAX_EXT_fun // 扩展
	| MIN '(' expr ',' expr (',' expr)+ ')'								# MIN_EXT_fun // 扩展

	// 统计函数
	| AVEDEV '(' expr ',' expr ')'			# AVEDEV_fun
	| DEVSQ '(' expr ',' expr ')'			# DEVSQ_fun
	| FORCAST '(' expr ',' expr ')'			# FORCAST_fun
	| SLOPE '(' expr ',' expr ')'			# SLOPE_fun
	| STD '(' expr ',' expr ')'				# STD_fun
	| STDP '(' expr ',' expr ')'			# STDP_fun
	| VAR '(' expr ',' expr ')'				# VAR_fun
	| VARP '(' expr ',' expr ')'			# VARP_fun
	| STDDEV '(' expr ',' expr ')'			# STDDEV_fun
	| COVAR '(' expr ',' expr ',' expr ')'	# COVAR_fun
	| RELATE '(' expr ',' expr ',' expr ')'	# RELATE_fun

	// 形态函数
	| COST '(' expr ')'							# COST_fun
	| PEAK '(' expr ',' expr ',' expr ')'		# PEAK_fun
	| PEAKBARS '(' expr ',' expr ',' expr ')'	# PEAKBARS_fun
	| SAR '(' expr ',' expr ',' expr ')'		# SAR_fun
	| SARTURN '(' expr ',' expr ',' expr ')'	# SARTURN_fun
	| TROUGH '(' expr ',' expr ',' expr ')'		# TROUGH_fun
	| TROUGHBARS '(' expr ',' expr ',' expr ')'	# TROUGHBARS_fun
	| WINNER '(' expr ')'						# WINNER_fun
	| LWINNER '(' expr ',' expr ')'				# LWINNER_fun
	| PWINNER '(' expr ',' expr ')'				# PWINNER_fun
	| COSTEX '(' expr ',' expr ')'				# COSTEX_fun
	| PPART '(' expr ')'						# PPART_fun
	| ZIG '(' expr ',' expr ')'					# ZIG_fun
	| ZIGA '(' expr ',' expr ')'				# ZIGA_fun
	// 时间
	| DATETODAY '(' expr ')' # DATETODAY_fun

	// 简化
	| PARAMETER '[' NUM ']'		# PARAMETER_REF_fun
	| TR '[' NUM ']'			# TR_REF_fun
	| CLOSE '[' NUM ']'			# CLOSE_REF_fun
	| HIGH '[' NUM ']'			# HIGH_REF_fun
	| LOW '[' NUM ']'			# LOW_REF_fun
	| OPEN '[' NUM ']'			# OPEN_REF_fun
	| AMOUNT '[' NUM ']'		# AMOUNT_REF_fun
	| VOL '[' NUM ']'			# VOL_REF_fun
	| TURN '[' NUM ']'			# TURN_REF_fun
	| INDEXA '[' NUM ']'		# INDEXA_REF_fun
	| INDEXC '[' NUM ']'		# INDEXC_REF_fun
	| INDEXH '[' NUM ']'		# INDEXH_REF_fun
	| INDEXL '[' NUM ']'		# INDEXL_REF_fun
	| INDEXO '[' NUM ']'		# INDEXO_REF_fun
	| INDEXV '[' NUM ']'		# INDEXV_REF_fun
	| DATE '[' NUM ']'			# DATE_REF_fun
	| TIME '[' NUM ']'			# TIME_REF_fun
	| YEAR '[' NUM ']'			# YEAR_REF_fun
	| MONTH '[' NUM ']'			# MONTH_REF_fun
	| WEEKDAY '[' NUM ']'		# WEEKDAY_REF_fun
	| DAY '[' NUM ']'			# DAY_REF_fun
	| HOUR '[' NUM ']'			# HOUR_REF_fun
	| MINUTE '[' NUM ']'		# MINUTE_REF_fun
	| DAYSTOTODAY '[' NUM ']'	# DAYSTOTODAY_REF_fun
	| TIME2 '[' NUM ']'			# TIME2_REF_fun

	// 技术指标函数 组合
	// | MACD '(' expr ',' expr ',' expr ')'	# MACD_fun // SHORT=12,LONG=26,M=9
	// | KDJ '(' expr ',' expr ',' expr ')'	# KDJ_fun // N=9,M1=3,M2=3
	// | BOLL '(' expr ',' expr ')'			# BOLL_fun // N=20, P=2
	// | DMI '(' expr ',' expr ')'				# DMI_fun // 动向指标：M1=14,M2=6
	// | TAQ '(' expr ')'						# TAQ_fun //唐安奇通道 M1=14,M2=6
	// | KTN '(' expr ',' expr ')'				# KTN_fun // 肯特纳交易通道M1=14,M2=6
	// | BRAR '(' expr ')'						# BRAR_fun // BRAR-ARBR 情绪指标  M1=26
	// | DFMA '(' expr ',' expr ',' expr ')'	# DFMA_fun // N1=10,N2=50,M=10
	// | EXPMA '(' expr ',' expr ')'			# EXPMA_fun // N1=12,N2=50
	// | XSII '(' expr ',' expr ')'			# XSII_fun // 薛斯通道II N=102, M=7

	// 技术指标函数
	| RSI '(' expr ')'								# RSI_fun // RSI N=24
	| WR '(' expr ')'								# WR_fun // W&R 威廉指标  N=10, N1=6
	| BIAS '(' expr ')'								# BIAS_fun // BIAS乖离率  L1=6, L2=12, L3=24
	| CCI '(' expr ')'								# CCI_fun // CCI  N=14
	| ATR '(' expr ')'								# ATR_fun // 真实波动N日平均值  N=20
	| BBI '(' expr ',' expr ',' expr ',' expr ')'	# BBI_fun // BBI多空指标   M1=3,M2=6,M3=12,M4=20
	| VR '(' expr ')'								# VR_fun // VR容量比率    M1=26
	| OBV '(' ')'									# OBV_fun // 能量潮指标   
	| MFI '(' expr ')'								# MFI_fun // MFI指标是成交量的RSI指标   N=14
	| ASI '(' expr ')'								# ASI_fun // 振动升降指标 ASI  ASIT=MA(ASI,M2)   M1=26,M2=10
	| ROC '(' expr ')'								# ROC_fun // 变动率指标 ROC  MAROC=MA(ROC,M)    N=12,M=6
	| MASS '(' expr ',' expr ')'					# MASS_fun // 梅斯线 MASS  MA_MASS=MA(MASS,M)  N1=9,N2=25,M=6
	| MTM '(' expr ',' expr ')'						# MTM_fun // 动量指标 MTMMA=MA(MTM,M)
	| DPO '(' expr ',' expr ')'						# DPO_fun // 区间震荡线 M1=20, M2=10 
	| EMV '(' expr ')'								# EMV_fun // 简易波动指标   MAEMV=MA(EMV,M) N=14,M=9
	| TRIX '(' expr ')'								# TRIX_fun // 三重指数平滑平均线 TRMA = MA(TRIX, M2) M1=12, M2=20
	| PSY '(' expr ')'								# PSY_fun // PSYMA=MA(PSY,M) N=12, M=6

	// TR
	| '-'? NUM		# NUM_fun
	| '-' expr		# REVERSE_fun
	| TR			# TR_fun
	| PARAMETER		# PARAMETER_fun
	| HIGH			# PARAMETER_fun
	| LOW			# PARAMETER_fun
	| CLOSE			# PARAMETER_fun
	| VOL			# PARAMETER_fun
	| OPEN			# PARAMETER_fun
	| AMOUNT		# PARAMETER_fun
	| TURN			# PARAMETER_fun
	| CAPITAL		# PARAMETER_fun
	| INDEXA		# PARAMETER_fun
	| INDEXC		# PARAMETER_fun
	| INDEXH		# PARAMETER_fun
	| INDEXL		# PARAMETER_fun
	| INDEXO		# PARAMETER_fun
	| INDEXV		# PARAMETER_fun
	| DATE			# PARAMETER_fun
	| TIME			# PARAMETER_fun
	| YEAR			# PARAMETER_fun
	| MONTH			# PARAMETER_fun
	| DAY			# PARAMETER_fun
	| HOUR			# PARAMETER_fun
	| MINUTE		# PARAMETER_fun
	| WEEKDAY		# PARAMETER_fun
	| DAYSTOTODAY	# PARAMETER_fun
	| TIME2			# PARAMETER_fun
	| DRAWNULL		# DRAWNULL_fun;

SUB: '-';
NUM:
	'0' ('.' [0-9]+)?
	| [1-9][0-9]* ('.' [0-9]+)?
	| ('0' ('.' [0-9]+)? | [1-9][0-9]* ('.' [0-9]+)?) 'E' [+-]? [0-9][0-9]?;
STRING:
	'\'' (~'\'' | '\\\'')* '\''
	| '"' ( ~'"' | '\\"')* '"'
	| '`' ( ~'`' | '\\`')* '`';
// 技术指标函数
RSI: 'RSI';
WR: 'WR';
BIAS: 'BIAS';
CCI: 'CCI';
ATR: 'ATR';
BBI: 'BBI';
VR: 'VR';
OBV: 'OBV';
MFI: 'MFI';
ASI: 'ASI';
ROC: 'ROC';
MASS: 'MASS';
MTM: 'MTM';
BRAR: 'BRAR';
DPO: 'DPO';
EMV: 'EMV';
TRIX: 'TRIX';
PSY: 'PSY';

// MACD: 'MACD';
// KDJ: 'KDJ';
// BOLL: 'BOLL';
// DMI: 'DMI';
// TAQ: 'TAQ';
// DFMA: 'DFMA';
// KTN: 'KTN';
// EXPMA: 'EXPMA';
// XSII: 'XSII';

//行情函数
HIGH: 'HIGH' | 'H';
LOW: 'LOW' | 'L';
CLOSE: 'CLOSE' | 'C';
VOL: 'VOL' | 'V';
OPEN: 'OPEN' | 'O';
AMOUNT: 'AMOUNT' | 'AMO';
TURN: 'TURN' | 'T';
CAPITAL: 'CAPITAL';

//时间函数
DATE: 'DATE';
TIME: 'TIME';
TIME2: 'TIME2';
YEAR: 'YEAR';
MONTH: 'MONTH';
WEEKDAY: 'WEEKDAY';
DAY: 'DAY';
HOUR: 'HOUR';
MINUTE: 'MINUTE';
FROMOPEN: 'FROMOPEN';
DAYSTOTODAY: 'DAYSTOTODAY';
DATETODAY: 'DATETODAY';

//引用函数
DRAWNULL: 'DRAWNULL';
BARSLAST: 'BARSLAST';
BARSSINCE: 'BARSSINCE';
BARSSINCEN: 'BARSSINCEN';
COUNT: 'COUNT';
DMA: 'DMA';
HHV: 'HHV';
HHVBARS: 'HHVBARS';
LLV: 'LLV';
LLVBARS: 'LLVBARS';
REF: 'REF';
REFV: 'REFV';
SUM: 'SUM';
SUMBARS: 'SUMBARS';
SMA: 'SMA';
MA: 'MA';
EMA: 'EMA' | 'EXPMEMA';
MEMA: 'MEMA';
RANGE: 'RANGE';
REVERSE: 'REVERSE';
FILTER: 'FILTER';
CONST: 'CONST';
BARSLASTCOUNT: 'BARSLASTCOUNT';
HOD: 'HOD';
LOD: 'LOD';
MULAR: 'MULAR';
FILTERX: 'FILTERX';
TR: 'TR';
WMA: 'WMA';
TMA: 'TMA';
AMA: 'AMA';
TOPRANGE: 'TOPRANGE';
LOWRANGE: 'LOWRANGE';
FINDHIGH: 'FINDHIGH';
FINDHIGHBARS: 'FINDHIGHBARS';
FINDLOW: 'FINDLOW';
FINDLOWBARS: 'FINDLOWBARS';
ZTPRICE: 'ZTPRICE';
DTPRICE: 'DTPRICE';

BACKSET: 'BACKSET';

BARSCOUNT: 'BARSCOUNT';

//逻辑函数
CROSS: 'CROSS';
UPNDAY: 'UPNDAY';
DOWNNDAY: 'DOWNNDAY';
NDAY: 'NDAY';
EXIST: 'EXIST';
EXISTR: 'EXISTR';
EVERY: 'EVERY';
LAST: 'LAST';
LONGCROSS: 'LONGCROSS';
ISVALID: 'ISVALID';
NOT: 'NOT';

//算数函数
AND: 'AND';
OR: 'OR';
IF: 'IF' | 'IFF';
IFN: 'IFN';
VALUEWHEN: 'VALUEWHEN';

//数学函数
MAX: 'MAX';
MAX6: 'MAX6';
MIN: 'MIN';
MIN6: 'MIN6';
ACOS: 'ACOS';
ASIN: 'ASIN';
ATAN: 'ATAN';
COS: 'COS';
SIN: 'SIN';
TAN: 'TAN';
EXP: 'EXP';
LN: 'LN';
LOG: 'LOG';
SORT: 'SORT';
POW: 'POW';
ABS: 'ABS';
SQRT: 'SQRT';
CEILING: 'CEILING';
FLOOR: 'FLOOR';
INTPART: 'INTPART';
BETWEEN: 'BETWEEN';
FRACPART: 'FRACPART';
ROUND: 'ROUND';
ROUND2: 'ROUND2';
SIGN: 'SIGN';
MOD: 'MOD';

// 统计函数
AVEDEV: 'AVEDEV';
DEVSQ: 'DEVSQ';
FORCAST: 'FORCAST';
SLOPE: 'SLOPE';
STD: 'STD';
STDP: 'STDP';
VAR: 'VAR';
VARP: 'VARP';
STDDEV: 'STDDEV';
COVAR: 'COVAR';
RELATE: 'RELATE';

// 形态函数
COST: 'COST';
PEAK: 'PEAK';
PEAKBARS: 'PEAKBARS';
SAR: 'SAR';
SARTURN: 'SARTURN';
TROUGH: 'TROUGH';
TROUGHBARS: 'TROUGHBARS';
WINNER: 'WINNER';
ZIG: 'ZIG';
LWINNER: 'LWINNER';
PWINNER: 'PWINNER';
COSTEX: 'COSTEX';
PPART: 'PPART';
ZIGA: 'ZIGA';

// 大盘函数
INDEXA: 'INDEXA';
INDEXC: 'INDEXC';
INDEXH: 'INDEXH';
INDEXL: 'INDEXL';
INDEXO: 'INDEXO';
INDEXV: 'INDEXV';

// 绘图函数
PLOYLINE: 'PLOYLINE';
DRAWLINE: 'DRAWLINE';
DRAWKLINE: 'DRAWKLINE';
STICKLINE: 'STICKLINE';
DRAWICON: 'DRAWICON';
DRAWTEXT: 'DRAWTEXT';
DRAWSL: 'DRAWSL';
DRAWTEXT_FIX: 'DRAWTEXT_FIX';
DRAWNUMBER: 'DRAWNUMBER';
DRAWNUMBER_FIX: 'DRAWNUMBER_FIX';
RGB: 'RGB';
DRAWBAND: 'DRAWBAND';
DRAWBMP: 'DRAWBMP';
DRAWGBK: 'DRAWGBK';
DRAWRECTREL: 'DRAWRECTREL';

COLOR:
	'RGBX' [0-9A-F][0-9A-F][0-9A-F][0-9A-F][0-9A-F][0-9A-F]
	| 'COLOR' [0-9A-F][0-9A-F][0-9A-F][0-9A-F][0-9A-F][0-9A-F]
	| 'COLORBLACK'
	| 'COLORBLUE'
	| 'COLORGREEN'
	| 'COLORCYAN'
	| 'COLORRED'
	| 'COLORMAGENTA'
	| 'COLORBROWN'
	| 'COLORGRAY'
	| 'COLORLIBLUE'
	| 'COLORLIGREEN'
	| 'COLORLICYAN'
	| 'COLORLIRED'
	| 'COLORLIMAGENTA'
	| 'COLORYELLOW'
	| 'COLORWHITE';
LINETHICK: 'LINETHICK' [0-9];
STICK: 'STICK';
COLORSTICK: 'COLORSTICK';
VOLSTICK: 'VOLSTICK';
LINESTICK: 'LINESTICK';
CROSSDOT: 'CROSSDOT';
CIRCLEDOT: 'CIRCLEDOT';
POINTDOT: 'POINTDOT';
NODRAW: 'NODRAW';
DRAWABOVE: 'DRAWABOVE';
NOFRAME: 'NOFRAME';
DOTLINE: 'DOTLINE';
NOTTEXT: 'NOTTEXT';
PLAYSOUND:
	'PLAYSOUND' [0-9]
	| 'PLAYSOUND1' [0-9]
	| 'PLAYSOUND20';

PARAMETER: ([A-Z_] | FullWidthLetter) (
		[A-Z0-9_]
		| FullWidthLetter
	)*;

fragment FullWidthLetter:
	'\u00c0' ..'\u00d6'
	| '\u00d8' ..'\u00f6'
	| '\u00f8' ..'\u00ff'
	| '\u0100' ..'\u1fff'
	| '\u2c00' ..'\u2fff'
	| '\u3040' ..'\u318f'
	| '\u3300' ..'\u337f'
	| '\u3400' ..'\u3fff'
	| '\u4e00' ..'\u9fff'
	| '\ua000' ..'\ud7ff'
	| '\uf900' ..'\ufaff'
	| '\uff00' ..'\ufff0';

WS: [ \t\r\n\u000C]+ -> skip;
COMMENT: '{' .*? '}' -> skip;
