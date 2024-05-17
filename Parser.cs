
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_WHITESPACE  =  2, // Whitespace
        SYMBOL_MINUS       =  3, // '-'
        SYMBOL_MINUSMINUS  =  4, // '--'
        SYMBOL_EXCLAMEQ    =  5, // '!='
        SYMBOL_NUM         =  6, // '#'
        SYMBOL_PERCENT     =  7, // '%'
        SYMBOL_LPAREN      =  8, // '('
        SYMBOL_RPAREN      =  9, // ')'
        SYMBOL_TIMES       = 10, // '*'
        SYMBOL_TIMESTIMES  = 11, // '**'
        SYMBOL_COMMA       = 12, // ','
        SYMBOL_DIV         = 13, // '/'
        SYMBOL_QUESTION    = 14, // '?'
        SYMBOL_LBRACE      = 15, // '{'
        SYMBOL_RBRACE      = 16, // '}'
        SYMBOL_PLUS        = 17, // '+'
        SYMBOL_PLUSPLUS    = 18, // '++'
        SYMBOL_LT          = 19, // '<'
        SYMBOL_LTEQ        = 20, // '<='
        SYMBOL_EQ          = 21, // '='
        SYMBOL_EQEQ        = 22, // '=='
        SYMBOL_GT          = 23, // '>'
        SYMBOL_MINUSGT     = 24, // '->'
        SYMBOL_GTEQ        = 25, // '>='
        SYMBOL_BYE         = 26, // Bye
        SYMBOL_DIGIT       = 27, // Digit
        SYMBOL_DOUBLE      = 28, // double
        SYMBOL_FLOAT       = 29, // float
        SYMBOL_HI          = 30, // Hi
        SYMBOL_ID          = 31, // Id
        SYMBOL_INT         = 32, // int
        SYMBOL_OTHERWISE   = 33, // OTHERWISE
        SYMBOL_PROC        = 34, // PROC
        SYMBOL_REPEAT      = 35, // REPEAT
        SYMBOL_STRING      = 36, // string
        SYMBOL_UNTIL       = 37, // UNTIL
        SYMBOL_WHEN        = 38, // WHEN
        SYMBOL_ARG         = 39, // <Arg>
        SYMBOL_ARGS        = 40, // <Args>
        SYMBOL_ASSIGN      = 41, // <Assign>
        SYMBOL_COND        = 42, // <Cond>
        SYMBOL_DEC         = 43, // <Dec>
        SYMBOL_DECLERATION = 44, // <Decleration>
        SYMBOL_DT          = 45, // <DT>
        SYMBOL_EXP         = 46, // <Exp>
        SYMBOL_EXPR        = 47, // <Expr>
        SYMBOL_FACTOR      = 48, // <Factor>
        SYMBOL_FUNC_CALL   = 49, // <Func_call>
        SYMBOL_FUNC_NAME   = 50, // <Func_name>
        SYMBOL_INC         = 51, // <Inc>
        SYMBOL_MY_COND     = 52, // <My_cond>
        SYMBOL_MY_FUNC     = 53, // <My_func>
        SYMBOL_MY_LOOP     = 54, // <My_loop>
        SYMBOL_OP          = 55, // <Op>
        SYMBOL_PROGRAM     = 56, // <Program>
        SYMBOL_STATMENT    = 57, // <Statment>
        SYMBOL_STATMENTS   = 58, // <Statments>
        SYMBOL_TERM        = 59  // <Term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_HI_LBRACE_RBRACE_BYE            =  0, // <Program> ::= Hi '{' <Statments> '}' Bye
        RULE_STATMENTS                               =  1, // <Statments> ::= <Statment>
        RULE_STATMENTS2                              =  2, // <Statments> ::= <Statment> <Statments>
        RULE_STATMENT                                =  3, // <Statment> ::= <Decleration>
        RULE_STATMENT2                               =  4, // <Statment> ::= <Assign>
        RULE_STATMENT3                               =  5, // <Statment> ::= <My_cond>
        RULE_STATMENT4                               =  6, // <Statment> ::= <My_loop>
        RULE_STATMENT5                               =  7, // <Statment> ::= <My_func>
        RULE_STATMENT6                               =  8, // <Statment> ::= <Func_call>
        RULE_DECLERATION_ID                          =  9, // <Decleration> ::= <DT> Id
        RULE_DT_INT                                  = 10, // <DT> ::= int
        RULE_DT_FLOAT                                = 11, // <DT> ::= float
        RULE_DT_DOUBLE                               = 12, // <DT> ::= double
        RULE_DT_STRING                               = 13, // <DT> ::= string
        RULE_ASSIGN_ID_EQ                            = 14, // <Assign> ::= <DT> Id '=' <Expr>
        RULE_EXPR_PLUS                               = 15, // <Expr> ::= <Expr> '+' <Term>
        RULE_EXPR_MINUS                              = 16, // <Expr> ::= <Expr> '-' <Term>
        RULE_EXPR                                    = 17, // <Expr> ::= <Term>
        RULE_TERM_TIMES                              = 18, // <Term> ::= <Term> '*' <Factor>
        RULE_TERM_DIV                                = 19, // <Term> ::= <Term> '/' <Factor>
        RULE_TERM_PERCENT                            = 20, // <Term> ::= <Term> '%' <Factor>
        RULE_TERM                                    = 21, // <Term> ::= <Factor>
        RULE_FACTOR_TIMESTIMES                       = 22, // <Factor> ::= <Factor> '**' <Exp>
        RULE_FACTOR                                  = 23, // <Factor> ::= <Exp>
        RULE_EXP_LPAREN_RPAREN                       = 24, // <Exp> ::= '(' <Expr> ')'
        RULE_EXP                                     = 25, // <Exp> ::= <Inc>
        RULE_EXP2                                    = 26, // <Exp> ::= <Dec>
        RULE_EXP_ID                                  = 27, // <Exp> ::= Id
        RULE_EXP_DIGIT                               = 28, // <Exp> ::= Digit
        RULE_INC_ID_PLUSPLUS                         = 29, // <Inc> ::= Id '++'
        RULE_INC_PLUSPLUS_ID                         = 30, // <Inc> ::= '++' Id
        RULE_DEC_ID_MINUSMINUS                       = 31, // <Dec> ::= Id '--'
        RULE_DEC_MINUSMINUS_ID                       = 32, // <Dec> ::= '--' Id
        RULE_MY_COND_WHEN_QUESTION_NUM               = 33, // <My_cond> ::= WHEN <Cond> '?' <Statments> '#'
        RULE_MY_COND_WHEN_QUESTION_NUM_OTHERWISE_NUM = 34, // <My_cond> ::= WHEN <Cond> '?' <Statments> '#' OTHERWISE <Statments> '#'
        RULE_COND                                    = 35, // <Cond> ::= <Expr> <Op> <Expr>
        RULE_OP_LT                                   = 36, // <Op> ::= '<'
        RULE_OP_GT                                   = 37, // <Op> ::= '>'
        RULE_OP_EQEQ                                 = 38, // <Op> ::= '=='
        RULE_OP_EXCLAMEQ                             = 39, // <Op> ::= '!='
        RULE_OP_GTEQ                                 = 40, // <Op> ::= '>='
        RULE_OP_LTEQ                                 = 41, // <Op> ::= '<='
        RULE_MY_LOOP_UNTIL_REPEAT_NUM                = 42, // <My_loop> ::= UNTIL <Cond> REPEAT <Statments> '#'
        RULE_MY_FUNC_PROC_LPAREN_RPAREN_MINUSGT_NUM  = 43, // <My_func> ::= <Func_name> PROC '(' <Args> ')' '->' <Statments> '#'
        RULE_FUNC_NAME_ID                            = 44, // <Func_name> ::= Id
        RULE_ARGS                                    = 45, // <Args> ::= <Arg>
        RULE_ARGS_COMMA                              = 46, // <Args> ::= <Arg> ',' <Args>
        RULE_ARG                                     = 47, // <Arg> ::= <Decleration>
        RULE_ARG_DIGIT                               = 48, // <Arg> ::= Digit
        RULE_FUNC_CALL_LPAREN_RPAREN                 = 49  // <Func_call> ::= <Func_name> '(' <Args> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //'#'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSGT :
                //'->'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYE :
                //Bye
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HI :
                //Hi
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE :
                //OTHERWISE
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROC :
                //PROC
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REPEAT :
                //REPEAT
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTIL :
                //UNTIL
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHEN :
                //WHEN
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARG :
                //<Arg>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGS :
                //<Args>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<Assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<Cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEC :
                //<Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLERATION :
                //<Decleration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DT :
                //<DT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<Expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC_CALL :
                //<Func_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC_NAME :
                //<Func_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INC :
                //<Inc>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MY_COND :
                //<My_cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MY_FUNC :
                //<My_func>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MY_LOOP :
                //<My_loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<Op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENT :
                //<Statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENTS :
                //<Statments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<Term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_HI_LBRACE_RBRACE_BYE :
                //<Program> ::= Hi '{' <Statments> '}' Bye
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENTS :
                //<Statments> ::= <Statment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENTS2 :
                //<Statments> ::= <Statment> <Statments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT :
                //<Statment> ::= <Decleration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT2 :
                //<Statment> ::= <Assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT3 :
                //<Statment> ::= <My_cond>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT4 :
                //<Statment> ::= <My_loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT5 :
                //<Statment> ::= <My_func>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT6 :
                //<Statment> ::= <Func_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLERATION_ID :
                //<Decleration> ::= <DT> Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_INT :
                //<DT> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_FLOAT :
                //<DT> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_DOUBLE :
                //<DT> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DT_STRING :
                //<DT> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_ID_EQ :
                //<Assign> ::= <DT> Id '=' <Expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<Expr> ::= <Expr> '+' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<Expr> ::= <Expr> '-' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<Expr> ::= <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<Term> ::= <Term> '*' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<Term> ::= <Term> '/' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<Term> ::= <Term> '%' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<Term> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<Factor> ::= <Factor> '**' <Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<Exp> ::= '(' <Expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<Exp> ::= <Inc>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<Exp> ::= <Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_ID :
                //<Exp> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_DIGIT :
                //<Exp> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_ID_PLUSPLUS :
                //<Inc> ::= Id '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_PLUSPLUS_ID :
                //<Inc> ::= '++' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEC_ID_MINUSMINUS :
                //<Dec> ::= Id '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEC_MINUSMINUS_ID :
                //<Dec> ::= '--' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MY_COND_WHEN_QUESTION_NUM :
                //<My_cond> ::= WHEN <Cond> '?' <Statments> '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MY_COND_WHEN_QUESTION_NUM_OTHERWISE_NUM :
                //<My_cond> ::= WHEN <Cond> '?' <Statments> '#' OTHERWISE <Statments> '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<Cond> ::= <Expr> <Op> <Expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<Op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<Op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<Op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<Op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<Op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<Op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MY_LOOP_UNTIL_REPEAT_NUM :
                //<My_loop> ::= UNTIL <Cond> REPEAT <Statments> '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MY_FUNC_PROC_LPAREN_RPAREN_MINUSGT_NUM :
                //<My_func> ::= <Func_name> PROC '(' <Args> ')' '->' <Statments> '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_NAME_ID :
                //<Func_name> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGS :
                //<Args> ::= <Arg>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGS_COMMA :
                //<Args> ::= <Arg> ',' <Args>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG :
                //<Arg> ::= <Decleration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG_DIGIT :
                //<Arg> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNC_CALL_LPAREN_RPAREN :
                //<Func_call> ::= <Func_name> '(' <Args> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
