grammar CurrencyComputer;

input
    : expression ',' conversion ;

expression
    : amountComposite operator expression 
    | amountComposite operator amountComposite 
    ;

operator 
    : ('-'| '+') ;

amountComposite
    : (amount | amountConvertible)
    ;

amountConvertible
    : amountConvertibleBase ':' conversion
    ;

amountConvertibleBase 
    : number currency  ;

amount 
    : number currency  ;

currency 
    : ('eur'| 'r' | '$') 
    ;

number
    : (DECIMAL_WITHOUT_SIGN | DECIMAL_WITH_NEGATIVE_SIGN) 
    ;

DECIMAL_WITH_NEGATIVE_SIGN 
    : '-' DECIMAL_WITHOUT_SIGN 
    ;

DECIMAL_WITHOUT_SIGN 
    : DIGIT+ ('.' DIGIT+)? 
    ;

DIGIT 
    : (DIGIT_19 | '0') 
    ;

DIGIT_19 
    : [1-9] 
    ;

conversion 
    : ('ToEuro' | 'ToDollar' | 'ToRub') 
    ;

Space
  :  (' ' | '\t') -> skip
  ;