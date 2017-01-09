@echo off
cd C:\multifacturas_sdk
set OPENSSL_CONF=c:\openssl-win64\bin\openssl.cfg
C:\multifacturas_sdk\php -c C:\multifacturas_sdk\php.ini -f C:\multifacturas_sdk\multifacturas.so %1
ECHO ************************************
ECHO *****    PROCESO FINALIZADO    *****
ECHO ************************************
