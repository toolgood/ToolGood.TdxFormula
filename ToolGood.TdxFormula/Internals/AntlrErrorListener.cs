using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ToolGood.TdxFormula.Internals
{
	sealed class AntlrErrorListener : IAntlrErrorListener<IToken>
	{
		public bool IsError { get; private set; }
		public string ErrorMsg { get; private set; }

		public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
		{
			IsError = true;
			ErrorMsg = msg;
		}
	}
}
