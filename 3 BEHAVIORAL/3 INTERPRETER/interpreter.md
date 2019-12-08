# INTERPRETER

 Interpreter Design pattern evaluates/ interprets the instructions written in a language grammar or notations. This pattern involves implementing an expression interface which tells to interpret a particular context. This pattern is used in the compilers or parsers or Macro expansions.

This pattern is commonly used in the menu systems of many applications such as Editor, IDE etc.

# THE PARTICIPANTS:
# Client
This is the class that builds the abstract syntax tree for a set of instructions in the given grammar. This tree builds with the help of instances of NonTerminalExpression and TerminalExpression classes.

## Context
This is a class that contains information (input and output), which is used by the Interpreter.

## Expression
This is an interface that defines the Interpret operation, which must be implemented by each subclass.

## NonTerminal
This is a class that implements the Expression. This can have other instances of Expression.

## Terminal
This is a class that implements the Expression.

## WHEN TO USE
1 Need to interpret a grammar that can be represented as large syntax trees.

2 Parsing tools are available.

3 Efficiency is not a concern.