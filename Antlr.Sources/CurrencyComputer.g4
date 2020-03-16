grammar CurrencyComputer;

input
    : expression ',' conversion
    ;

expression
    : amountComposite expression 
    | amountComposite amountComposite 
    ;

amountComposite
    : (amountSigned | amountSignedConvertible)
    ;

amountSignedConvertible
    : amountSigned ':' conversion
    ;

amountSigned
    : operatorAndSpaces? amount 
    ;

operatorAndSpaces
    : SPACE* operator SPACE*
    ;

operator 
    : ('-'| '+')
    ;

amount 
    : number currency 
    ;

currency 
    : ('eur'| 'r' | '$') 
    ;

number 
    : DIGIT+ ('.' DIGIT+)? 
    ;

DIGIT 
    : [0-9]
    ;

conversion 
    : ('ToEuro' | 'ToDollar' | 'ToRub') 
    ;

SPACE
  :  (' ' | '\t') -> skip
  ;