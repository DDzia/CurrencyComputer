grammar CurrencyComputer;

input
    : expression ',' conversion ;

expression
    : amount operator expression 
    | amount operator amount 
    ;

operator 
    : ('-'| '+') ;

amount 
    : number currency  ;

currency 
    : ('eur'| 'r' | '$') 
    ;

/*
number 
    : (INTEGER | DECIMAL) 
    ;
*/
number : DECIMAL
    ;

DECIMAL
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
/*
INTEGER 
    : (INTEGER_WITHOUT_SIGN | INTEGER_WITH_NEGATIVE_SIGN | '0') 
    ;

INTEGER_WITH_NEGATIVE_SIGN
    : '-' INTEGER_WITHOUT_SIGN
    ;

INTEGER_WITHOUT_SIGN 
    : DIGIT_19+ 
    ;
*/

DIGIT_19 
    : [1-9] 
    ;

conversion 
    : ('ToEuro' | 'ToDollar' | 'ToRub') 
    ;

Space
  :  (' ' | '\t') -> skip
  ;