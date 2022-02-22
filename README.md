# PwmTableGenerator
Generates a value table - either linear or logarithmic - to use with PWM. Initially made to help with DALI/DMX controllers' firmware.

Logarithmic curve calculations are based on the formula defined in DALI standards. For more info, you can check the pdf link below (page 9):
http://ww1.microchip.com/downloads/en/appnotes/atmel-42071-dali-slave-reference_design_application-note_at01244.pdf

'Maximum' TextBox should be set as (PWM_Period_In_Ticks + 1).

'Count' defines the length of the generated array. Two things to keep in mind about 'Count':
1) DALI uses value 0xFF in a 'Direct Arc Power Control' frame as the 'Stop Fade' command. So the 'Count' TextBox should be set as 254.
2) DMX uses full range of 0-0xFF, so the 'Count' should be set as 255.
